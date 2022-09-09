using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessModel.Modelos;

namespace PracticaFinal_ModuloI.Utils
{
    public static class Utils
    {
        public const int STATUS_OK = 0;
        public const int STATUS_ERR = 2;
        public static (string, string) ParseArguments()
        {
            return ($"C:/Users/d78650/Desktop/transferencias.txt", $"C:/Users/d78650/Desktop/transferencias_completo.txt");
        }
        public static void ValidarArchivos(string file1, string file2)
        {
            ;
        }
        public static async void CompletarTransferencias(List<Transferencia> transferencias)
        {
            foreach (Transferencia transferencia in transferencias)
            {
                transferencia.ClaveTributaria = await GetClaveTributaria(transferencia.ClaveTributaria);
            }
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
                int posicion = 0;
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
        public static void EscribirTransferencias(string outputFilePath)
        {
            ;
        }
        internal static async Task<string> GetClaveTributaria(string CUIL)
        {
            await Task.Run(() => System.Threading.Thread.Sleep(1000));
            return "27432258201";
        }
    }
}