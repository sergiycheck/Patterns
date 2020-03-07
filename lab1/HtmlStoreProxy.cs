using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using lab1.models;
using lab1.repository;

namespace lab1
{
    public class HtmlStoreProxy
    {
        private WebCrawler crawler;
        private MyHtmlModelRepository<MyHtmlModel> repository;
        public HtmlStoreProxy()
        {
            repository = new MyHtmlModelRepository<MyHtmlModel>(new MyAppContext());
        }

        public async Task<MyHtmlModel> GetMyHtmlModel(string path)
        {
            MyHtmlModel model = repository.GetHtmlModelByLink(path);
            if (model == null)
            {
                crawler = WebCrawler.GetInstance();
                model = await crawler.GetMyHtmlModel(path);
                await repository.Create(model);
            }

            return model;
        }

    }
}
