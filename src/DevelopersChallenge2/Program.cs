using System;
using System.Collections.Generic;

namespace DevelopersChallenge2

{
    class Program
    {

        static void Main(string[] args)
        {
            List<string> paths = ReadPath.toList();

            List<Transaction> transactions = ImportOfx.toList(paths);

            ExportOfx.exportTransaction(transactions);

        }
    }
}
