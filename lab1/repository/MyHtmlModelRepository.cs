using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab1.models;

namespace lab1.repository
{
    public class MyHtmlModelRepository<TEntity>:GenericRepository<TEntity> where TEntity:MyHtmlModel
    {
        public MyHtmlModelRepository(MyAppContext context) : base(context)
        {

        }

        public MyHtmlModel GetHtmlModelAsNoTracking(int id)
            => this.GetAll().FirstOrDefault(e => e.Id == id);

        public MyHtmlModel GetHtmlModelByLink(string path)
            => this.GetAll().FirstOrDefault(e => e.Name == path);
    }
}
