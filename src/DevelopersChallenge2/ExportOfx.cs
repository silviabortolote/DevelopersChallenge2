

using System;
using System.Collections.Generic;

namespace DevelopersChallenge2
{
    class ExportOfx
    {
        //export the transaction for the archive extrato.ofx
        public static void exportTransaction(List<Transaction> transactions)
        {
           using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"C:\Users\silvi\Desktop\Nibo\DevelopersChallenge2\src\DevelopersChallenge2\Properties\extrato.ofx"))
            {
                file.WriteLine("OFXHEADER:100" +
                      "\nDATA: OFXSGML" +
                      "\n VERSION: 102" +
                      "\nSECURITY: NONE" +
                      "\nENCODING: USASCII" +
                      "\nCHARSET: 1252" +
                      "\nCOMPRESSION: NONE" +
                      "\nOLDFILEUID: NONE" +
                      "\nNEWFILEUID: NONE" +
                      "\n" +
                      "\n<OFX>" +
                      "\n<SIGNONMSGSRSV1>" +
                      "\n<SONRS>" +
                      "\n<STATUS>" +
                      "\n<CODE> 0" +
                      "\n<SEVERITY> INFO" +
                      "\n</STATUS>" +
                      "\n<DTSERVER> 20140318100000[-03:EST]" +
                      "\n<LANGUAGE> POR" +
                      "\n</SONRS>" +
                      "\n</SIGNONMSGSRSV1>" +
                      "\n<BANKMSGSRSV1>" +
                      "\n<STMTTRNRS>" +
                      "\n<TRNUID> 1001" +
                      "\n<STATUS>" +
                      "\n<CODE> 0" +
                      "\n<SEVERITY> INFO" +
                      "\n</STATUS>" +
                      "\n<STMTRS>" +
                      "\n<CURDEF> BRL" +
                      "\n<BANKACCTFROM>" +
                      "\n<BANKID> 0341" +
                      "\n<ACCTID> 7037300576" +
                      "\n<ACCTTYPE> CHECKING" +
                      "\n</BANKACCTFROM>" +
                      "\n<BANKTRANLIST>" +
                      "\n<DTSTART> 20140201100000[-03:EST]" +
                      "\n<DTEND> 2014020100000[-03:EST]" +
                      "\n"
                      );

                foreach (Transaction transaction in transactions)
                {
                    file.WriteLine(
                      "\n<STMTTRN>" +
                      "\n<TRNTYPE> " + transaction.Type +
                      "\n<DTPOSTED> " + transaction.DtPosted +
                      "\n<TRNAMT> " + transaction.Trnamt +
                      "\n<MEMO> " + transaction.Memo +
                      "\n</STMTTRN>"
                     );
                }

                file.WriteLine("\n" +
                      "\n</BANKTRANLIST>" +
                      "\n<LEDGERBAL>" +
                      "\n<BALAMT> -4021.44" +
                      "\n<DTASOF> 20140318100000[-03:EST]" +
                      "\n</LEDGERBAL>" +
                      "\n</STMTRS>" +
                      "\n</STMTTRNRS>" +
                      "\n</BANKMSGSRSV1>" +
                      "\n</OFX>"
                      );
            }



        }
    }

}
