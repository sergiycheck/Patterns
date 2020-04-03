using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Patterns.models;

namespace Patterns
{
    public class WebCrawler
    {
        public string Path { get; set; }
        private HtmlWeb web;
        private static WebCrawler instance;
        private static object syncRoot = new Object();
        public IElemRetriever Retriever { get; set; }

        private WebCrawler()
        {
            
            web = new HtmlWeb();
        }

        public async Task<HtmlDocument> Download(string path)
        {
            this.Path = path;
            try
            {
                var doc = await web.LoadFromWebAsync(Path);
                if (doc != null)
                {
                    return doc;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

            try
            {
                var docf = new HtmlDocument();
                docf.Load(path);
                if(docf!=null)
                    return docf;
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }


            return null;
        }

        public MyHtmlModel LoadFromFile(string path)
        {
            try
            {
                var docf = new HtmlDocument();
                docf.Load(path);
                if (docf != null)
                    return new MyHtmlModel()
                    {
                        HTML = docf.Text,
                        Name = path
                    };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

            return null;
        }

        public async Task<MyHtmlModel> GetMyHtmlModel(string path)
        {
            HtmlDocument html = await Download(path);
            return new MyHtmlModel()
            {
                HTML = html.Text,
                Name = path
            };

        }

        public void Print(IEnumerable<string> elems)
        {
            List<string> elsList = new List<string>(elems);
            foreach (var VARIABLE in elsList)
            {
                Console.WriteLine(VARIABLE);
            }
        }


        public static WebCrawler GetInstance()
        {
            Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new WebCrawler();
                }
            }
            return instance;
        }

    }
}
