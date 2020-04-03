using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Patterns.ChainOfResponsibility;
using Patterns.Memento;
using Patterns.models;

namespace Patterns
{
    class Program
    {

        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task<MyHtmlModel> Proxy(string path)
        {
           
            HtmlStoreProxy proxyOb = new HtmlStoreProxy();
            var model = await proxyOb.GetMyHtmlModel(path);
            Console.WriteLine(model.HTML);
            return model;
        }

        static void ChainOfResponsibility()
        {
            var fileLoad = new FromFileLoader();
            var webload = new FromWebLoader();
            fileLoad.SetNext(webload);
            Console.WriteLine("Chain: File->Web");
            Client.ClientLoader(fileLoad);
        }

        static async Task Strategy(string path)
        {
            //crawler.Retriever = new LinkRetriever();
            //var elems1 = await crawler.Retriever.GetElems(crawler.Path, html);
            //Console.WriteLine("-------------Links-------------");
            //crawler.Print(elems1);
            //crawler.Retriever = new ButtonRetriever();
            //Console.WriteLine("-------------Buttons html-------------");
            //var elems2 = await crawler.Retriever.GetElems(crawler.Path, html);
            //crawler.Print(elems2);
        }

        static async Task Memento(string path)
        {
            CareTaker careTaker = CareTaker.RestoreFromFile().Result;
            Originator originator = null;
            WebCrawler webcrawler = WebCrawler.GetInstance();
            if (careTaker != null)
            {
                originator = careTaker.Originator;
            }
            if (careTaker == null)
            {
                var model = webcrawler.LoadFromFile(path);
                originator = new Originator(model);
                careTaker = new CareTaker(originator);
            }

            //careTaker.Restore("nkbrrk");
            //Console.WriteLine($"Originator stateName {originator.StateName}");

            careTaker.Compare("citmxv");

            //originator.MakeChanges(webcrawler);
            //await careTaker.Save();

            //Console.WriteLine("History");
            //careTaker.ShowHistory();


        }
        static async Task MainAsync(string[] args)
        {
            //singleton
            //string path = @"https://getbootstrap.com/docs/4.4/examples/album/";
            //string path = @"https://codebeautify.org/all-number-converter";
            string path = @"E:/filesFromCDisk/templates/startbootstrap-grayscale-gh-pages/index.html";
            
            //memento
            await Memento(path);

            //proxy
            //await Proxy(path);

            //chain of responsibility
            //ChainOfResponsibility();

            //strategy
            //await Strategy(path);


        }
    }
}
