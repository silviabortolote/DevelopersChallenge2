using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DevelopersChallenge2
{
    class Program
    {

        static void Main(string[] args)
        {
            string pathToOfx = "C:/Users/silvi/Desktop/Nibo/DevelopersChallenge2/src/DevelopersChallenge2/Properties/extrato1.ofx";

            XElement doc = ImportOfx.toXElement(pathToOfx);

            IEnumerable<XElement> imps = doc.DescendantsAndSelf("STMTTRN");

            List<string> listOfx = imps.Select(item => item.ToString()).ToList();

            //Console.WriteLine(listOfx.Count);

            /*foreach (XElement item in doc.Elements())
            {
                Console.WriteLine(item.Value);
               
                Console.WriteLine(item.Name);

                //abc = item.Elements().Where(x => x.Name.LocalName == "Entry").Select(x => x).Where(x => x.Attribute("Fulfiller") == null || fulfillerClaims.Contains(x.Attribute("Fulfiller").Value));
            }

            List<string> listOfx = imps.Select(item => item.ToString()).ToList();
            Console.WriteLine(listOfx.Count);

            foreach (var i in listOfx)
            {
                Console.WriteLine(i);
            }*/


        }
    }
}
