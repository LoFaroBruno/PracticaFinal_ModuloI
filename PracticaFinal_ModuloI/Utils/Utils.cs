using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BusinessModel.Modelos;
using System.Net.Http;
using Newtonsoft.Json;

namespace PracticaFinal_ModuloI.Utils
{
    public static class Utils
    {
        public const int STATUS_OK = 0;
        public const int STATUS_ERR = 2;

        public static (string, string) ParseArguments(string[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException("Se requieren dos parametros.");
            return (args[0], args[1]);
        }

        public static void ValidarArchivos(string file1, string file2)
        {
            if (!File.Exists(file1))
                throw new ArgumentException($"El Archivo {file1} no existe.");
            if (!File.Exists(file2))
                throw new ArgumentException($"El Archivo {file2} no existe.");
        }

        public static async Task<List<Transferencia>> CompletarTransferencias(List<Transferencia> transferencias)
        {
            foreach (Transferencia transferencia in transferencias)
            {
                transferencia.CodigoActividadAFIP = await GetClaveCodigoDeActividad(transferencia.ClaveTributaria);
            }
            return transferencias;
        }

        public static List<Transferencia> LeerTransferencias(string inputFilePath)
        {
            int linea = 0;
            string entrada;
            EntradaDeArchivo entradaDeArchivo = new EntradaDeArchivo(inputFilePath);
            List<Transferencia> transferencias = new List<Transferencia>();

            while ((entrada = entradaDeArchivo.ObtenerLinea()) != null)
            {
                if (entrada.Length != 117)
                    throw new FormatException("La linea debe tener 117 caracteres.");
                try
                {
                    transferencias.Add(ParseTransferencia(entrada));
                }
                catch(FormatException ex)
                {
                    throw new FormatException($"Linea invalida {linea}.", ex);
                }
                linea++;
            }
            return transferencias;
        }

        public static Transferencia ParseTransferencia(string entrada)
        {
            Transferencia transferencia = new Transferencia();
            try
            {
                transferencia.Nombre = entrada.Substring(0, 31);
                int length = transferencia.Nombre.Length;
                transferencia.Monto = float.Parse(entrada.Substring(31, 10));
                string fechaString = entrada.Substring(41, 14);
                transferencia.HoraFecha = DateTime.ParseExact(fechaString, "yyyyMMddHHmmss", null);
                if (String.Equals(entrada.Substring(55, 1), "T"))
                    transferencia.Inmediata = true;
                else if (String.Equals(entrada.Substring(55, 1), "F"))
                    transferencia.Inmediata = false;
                else
                    throw new FormatException($"Inmediata invalida");
                transferencia.CBUOrigen = entrada.Substring(56, 22);
                transferencia.CBUDestino = entrada.Substring(78, 22);
                transferencia.CodigoActividadAFIP = entrada.Substring(100, 6);
                transferencia.ClaveTributaria = entrada.Substring(106, 11);
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            return transferencia;
        }
        public static string TransferenciaParseString(Transferencia transferencia)
        {
            string linea = "";
            linea += transferencia.Nombre.ToString().PadLeft(31,'0');
            linea += transferencia.Monto.ToString().PadLeft(10, '0');
            linea += transferencia.HoraFecha.ToString(@"yyyyMMddHHmmss");
            if(transferencia.Inmediata)
                linea += 'T';//31,10,14,1,1,22,22,6,11
            else
                linea += 'F';
            linea += transferencia.CBUOrigen;
            linea += transferencia.CBUDestino;
            linea += transferencia.CodigoActividadAFIP;
            linea += transferencia.ClaveTributaria;
            return linea;
        }
        public static async void EscribirTransferencias(List<Transferencia> transferencias, string outputFilePath)
        {
            try
            {
                using (StreamWriter writer = File.CreateText("C:/Users/D78650/Desktop/transferencias_completas.txt"))
                {
                    foreach (Transferencia tr in transferencias)
                    {
                        await writer.WriteLineAsync(TransferenciaParseString(tr));
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("error al leer el archivo", Ex);
            }
        }
        internal static async Task<string> GetClaveCodigoDeActividad(string CUIL)
        {
            string baseURL;
            HttpClient client = new HttpClient();
            string urlRequest = "";
            CodActividad codActividad;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(urlRequest),
            };
            using (var response = await client.SendAsync(request).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                if (string.Equals(content, "{}"))
                    throw new Exception("Invalid address.");
                //CodActividadId, 
                dynamic location = JsonConvert.DeserializeObject(content);
                double.Parse(location[0]["lat"].ToString().Replace(".", ","));
                double.Parse(location[0]["lon"].ToString().Replace(".", ","));
            }
            return "001322";
        }
    }
}