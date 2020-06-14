

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DevelopersChallenge2
{
    class LeituraPath
    {
        public static List<string> toList()
        {
            List<string> paths = new List<string>();
            string path;

            Console.WriteLine("Informe a path do arquivo que deseja importar:");
            path = Console.ReadLine();

            while (path!="0")
            {
                paths.Add(path);
                Console.WriteLine("Informe outra path do arquivo que deseja importar, digite '0' caso deseja finalizar:");
                path = Console.ReadLine();               
            }

            return paths;

        }
    }

}
