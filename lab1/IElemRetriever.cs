using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;


namespace lab1
{
    public interface IElemRetriever
    {
        Task<IEnumerable<string>> GetElems(string path,HtmlDocument html);
    }
}
