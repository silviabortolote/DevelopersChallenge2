using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System;
using System.Collections.Generic;

namespace DevelopersChallenge2
{
    public static class ImportOfx
    {
   
        public static void toList(List<string> paths)
        {
            List<Transaction> transactions = new List<Transaction>();
            Transaction transaction = new Transaction();

            foreach (string pathToOfxFile in paths)
            {
                if (!System.IO.File.Exists(pathToOfxFile))
                {
                    throw new FileNotFoundException();
                }

                var tags = from line in File.ReadAllLines(pathToOfxFile)
                           where line.Contains("<STMTTRN>") ||
                           line.Contains("<TRNTYPE>") ||
                           line.Contains("<DTPOSTED>") ||
                           line.Contains("<TRNAMT>") ||
                           line.Contains("<MEMO>")
                           select line;


                foreach (var l in tags)
                {
                    if (l.IndexOf("<STMTTRN>") != -1)
                    {
                        transactions.Add(transaction);
                        transaction = new Transaction();
                        continue;

                    }

                    if (getTagName(l) == "TRNTYPE")
                    {
                        transaction.Type = getTagValue(l);
                    }
                    else
                    {
                        if (getTagName(l) == "DTPOSTED")
                        {
                            transaction.DtPosted = getTagValue(l);
                        }
                        else
                        {
                            if (getTagName(l) == "TRNAMT")
                            {
                                transaction.Trnamt = getTagValue(l);
                            }
                            else
                            {
                                if (getTagName(l) == "MEMO")
                                {
                                    transaction.Memo = getTagValue(l);
                                }
                            }
                        }
                    }
                }

            }

        }
      
        private static string getTagName(string line)
        {
            int pos_init = line.IndexOf("<")+1;
            int pos_end = line.IndexOf(">");
            pos_end = pos_end - pos_init;
            return line.Substring(pos_init, pos_end);
        }
       
        private static string getTagValue(string line)
        {
            int pos_init = line.IndexOf(">")+1;
            string retValue=line.Substring(pos_init).Trim();
            return retValue;
        }
    }
}
