using BusinessModel.Modelos;
using System;
using System.Collections.Generic;

namespace PracticaFinal_ModuloI
{
    internal class Program
    {
        static int Main(string[] args)
        {
            try
            {
                (string inputFilePath, string outputFilePath) = Utils.Utils.ParseArguments(args);
                Utils.Utils.ValidarArchivos(inputFilePath, outputFilePath);
                List<Transferencia> transferencias = Utils.Utils.LeerTransferencias(inputFilePath);
                Utils.Utils.CompletarTransferencias(transferencias);
                Utils.Utils.EscribirTransferencias(outputFilePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
                return Utils.Utils.STATUS_ERR;
            }
            Console.ReadKey();
            return Utils.Utils.STATUS_OK;
        }
    }
}