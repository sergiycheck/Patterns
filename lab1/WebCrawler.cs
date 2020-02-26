using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using System.Threading.Tasks;

namespace lab1
{
    public class WebCrawler
    {
        public string Path { get; set; }
        private HtmlWeb web;
        private static WebCrawler instance;
        private static object syncRoot = new Object();
        public IElemRetriever Retriever { get; set; }
        private WebCrawler(string path)
        {
            this.Path = path;
            web = new HtmlWeb();
        }

        public async Task<HtmlDocument> Download()
        {
            try
            {
                return await web.LoadFromWebAsync(Path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

            return null;

        }

        public void Print(IEnumerable<string> elems)
        {
            List<string> elsList = new List<string>(elems);
            foreach (var VARIABLE in elsList)
            {
                Console.WriteLine(VARIABLE);
            }
        }
        private WebCrawler()
        {
            web = new HtmlWeb();
        }

        public static WebCrawler GetInstance(string path)
        {
            Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new WebCrawler(path);
                }
            }
            return instance;
        }

    }
}
