using BusinessModel.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompletadorDeTransferencias
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            try
            {
                (string inputFilePath, string outputFilePath) = Utils.Utils.ParseArguments(args);
                if (inputFilePath == null && outputFilePath == null)
                    return Utils.Utils.STATUS_ERR;
                Utils.Utils.ValidarArchivos(inputFilePath, outputFilePath);
                List<Transferencia> transferencias = Utils.Utils.LeerTransferencias(inputFilePath);
                transferencias = await Utils.Utils.CompletarTransferencias(transferencias);
                Utils.Utils.EscribirTransferencias(transferencias, outputFilePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
                return Utils.Utils.STATUS_ERR;
            }
            return Utils.Utils.STATUS_OK;
        }
    }
}