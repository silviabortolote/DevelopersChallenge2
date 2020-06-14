

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DevelopersChallenge2
{
    class ConvertOfx
    {
        public List<string> Convert(IEnumerable<XElement> items)
        {
            return items.Select(item => item.ToString()).ToList();
        }
    }

}
