using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace lab1
{
    class LinkRetriever : IElemRetriever
    {
        public async Task<IEnumerable<string>> GetElems(string path, HtmlDocument html)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                

                var linkList = html.DocumentNode
                    .Descendants("a")
                    .Select(a => a.GetAttributeValue("href", null))
                    .Where(u => !string.IsNullOrEmpty(u))
                    .Distinct();
                return linkList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

            return null;

        }
    }
}
