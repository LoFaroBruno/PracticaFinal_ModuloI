using System;
using System.IO;
using System.Linq;

namespace CompletadorDeTransferencias.Utils
{
    public static class ArgsParse
    {
        public static (string, string) ParseArguments(string[] args)
        {
            string outputFilePath = null;
            string inputFilePath = null;
            string listaParametros = "";
            if (args.Length > 5 || args.Length < 1)
                throw new ArgumentException("Cantidad de parametros incorrecta. --h para informacion sobre parametros");
            if (args.Any("-h".Contains) || args.Any("--help".Contains))
                Console.WriteLine(listaParametros);
            else
            {
                if (args.Length != 4)
                    throw new ArgumentException("Cantidad de parametros incorrecta. --h para informacion sobre parametros");
                for (int i = 0; i < args.Length; i += 2)
                {
                    if ((Equals(args[i], "-i") || Equals(args[i], "--inputfilePath")) && inputFilePath == null)
                        inputFilePath = args[i + 1];
                    if ((Equals(args[i], "-o") || Equals(args[i], "--outputfilePath")) && outputFilePath == null)
                        outputFilePath = args[i + 1];
                }
            }
            return (inputFilePath, outputFilePath);
        }

        public static void ValidarArchivos(string file1, string file2)
        {
            if (!File.Exists(file1))
                throw new ArgumentException($"El Archivo {file1} no existe.");
        }
    }
}