using System;
using System.Collections.Generic;

namespace DevelopersChallenge2

{
    class Program
    {

        static void Main(string[] args)
        {
            List<string> paths = ReadPath.toList();

            ImportOfx.toList(paths);

        }
    }
}
