using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System;

namespace DevelopersChallenge2
{
    public static class ImportOfx
    {
        public static XElement toXElement(string pathToOfxFile)
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


            //Console.WriteLine(tags.c);

            Console.WriteLine("****************************************************");

            XElement el=new XElement("root");
            XElement son = null;
          
            foreach (var l in tags)
            {
                if (l.IndexOf("<STMTTRN>") != -1)
                {
                    son = new XElement("STMTTRN");
                    el.Add(son);
                    continue;
                }
              
                var tagName = getTagName(l);
                var elSon= new XElement(tagName);
                elSon.Value = getTagValue(l);
                son.Add(elSon);
            }
           return el;
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
            if (retValue.IndexOf("[")!=-1)
            {
                retValue = retValue.Substring(0, 8);
            }
            return retValue;
        }
    }
}
