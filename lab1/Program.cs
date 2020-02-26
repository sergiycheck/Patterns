using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {

        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            //singleton
            var crawler = WebCrawler.GetInstance(@"https://getbootstrap.com/docs/4.4/examples/album/");
            HtmlDocument html = await crawler.Download();
            Console.WriteLine(html.Text);

            //strategy
            crawler.Retriever = new LinkRetriever();
            var elems1 = await crawler.Retriever.GetElems(crawler.Path, html);
            Console.WriteLine("-------------Links-------------");
            crawler.Print(elems1);
            crawler.Retriever = new ButtonRetriever();
            Console.WriteLine("-------------Buttons html-------------");
            var elems2 = await crawler.Retriever.GetElems(crawler.Path, html);
            crawler.Print(elems2);

            
        }
    }
}
