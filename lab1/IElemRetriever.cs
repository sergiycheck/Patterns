using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Patterns
{
    public interface IElemRetriever
    {
        Task<IEnumerable<string>> GetElems(string path,HtmlDocument html);
    }
}
