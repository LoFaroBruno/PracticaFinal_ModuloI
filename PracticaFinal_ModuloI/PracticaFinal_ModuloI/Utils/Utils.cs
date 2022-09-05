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
        public static List<Transferencia> LeerTransferencias()
        {
            return new List<Transferencia>();
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