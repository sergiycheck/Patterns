using HtmlAgilityPack;
using lab1.models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using lab1.repository;

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
            //string path = @"https://getbootstrap.com/docs/4.4/examples/album/";
            string path = @"https://codebeautify.org/all-number-converter";

            HtmlStoreProxy proxyOb = new HtmlStoreProxy();
            var model = await proxyOb.GetMyHtmlModel(path);
            Console.WriteLine(model.HTML);



            //strategy
            //crawler.Retriever = new LinkRetriever();
            //var elems1 = await crawler.Retriever.GetElems(crawler.Path, html);
            //Console.WriteLine("-------------Links-------------");
            //crawler.Print(elems1);
            //crawler.Retriever = new ButtonRetriever();
            //Console.WriteLine("-------------Buttons html-------------");
            //var elems2 = await crawler.Retriever.GetElems(crawler.Path, html);
            //crawler.Print(elems2);


        }
    }
}
