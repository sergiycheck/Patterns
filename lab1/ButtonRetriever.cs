using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Patterns
{
    public class ButtonRetriever : IElemRetriever
    {
        public async Task<IEnumerable<string>> GetElems(string path, HtmlDocument html)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                var linkList = html.DocumentNode.SelectNodes("//button");
                List<string> nodes = new List<string>();
                foreach (var node in linkList)
                {
                    nodes.Add(node.OuterHtml);
                }

                return nodes;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

            return null;
        }
    }
}
