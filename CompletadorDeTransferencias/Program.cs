using BusinessModel.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompletadorDeTransferencias.Utils;

namespace CompletadorDeTransferencias
{
    internal class Program
    {
        public const int STATUS_OK = 0;
        public const int STATUS_ERR = 2;
        static async Task<int> Main(string[] args)
        {
            try
            {
                (string inputFilePath, string outputFilePath) = ArgsParse.ParseArguments(args);
                if (inputFilePath == null && outputFilePath == null)
                    return STATUS_ERR;
                ArgsParse.ValidarArchivos(inputFilePath, outputFilePath);
                List<Transferencia> transferencias = Transferencias.LeerTransferencias(inputFilePath);
                transferencias = await Transferencias.CompletarTransferencias(transferencias);
                Transferencias.EscribirTransferencias(transferencias, outputFilePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
                return STATUS_ERR;
            }
            return STATUS_OK;
        }
    }
}