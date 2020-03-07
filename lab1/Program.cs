using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Patterns.ChainOfResponsibility;

namespace Patterns
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
            //string path = @"https://codebeautify.org/all-number-converter";
            //string pathfile = @"E:/filesFromCDisk/templates/startbootstrap-grayscale-gh-pages/index.html#";

            //proxy
            //HtmlStoreProxy proxyOb = new HtmlStoreProxy();
            //var model = await proxyOb.GetMyHtmlModel(path);
            //Console.WriteLine(model.HTML);


            //chain of responsibility
            var fileLoad = new FromFileLoader();
            var webload = new FromWebLoader();
            fileLoad.SetNext(webload);
            Console.WriteLine("Chain: File->Web");
            Client.ClientLoader(fileLoad);



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
