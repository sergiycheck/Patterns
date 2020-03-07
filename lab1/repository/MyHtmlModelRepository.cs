using System.Linq;
using Patterns.models;

namespace Patterns.repository
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
