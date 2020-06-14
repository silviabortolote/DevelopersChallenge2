

using System;
using System.Collections.Generic;

namespace DevelopersChallenge2
{
    class ReadPath
    {

        //save the paths list that the user want to import
        public static List<string> toList()
        {
            List<string> paths = new List<string>();
            string path;

            Console.WriteLine("\nInforme a path do arquivo que deseja importar (a path completa do arquivo .ofx Ex.: C:/Temp/extrato1.ofx )");
            path = Console.ReadLine().Trim();

            while (path!="0")
            {
                paths.Add(path);
                Console.WriteLine("\nInforme a path do arquivo que deseja importar (a path completa do arquivo .ofx Ex.: C:/Temp/extrato1.ofx ), digite '0' caso deseja finalizar:");
                path = Console.ReadLine().Trim();
            }

            return paths;

        }
    }

}
