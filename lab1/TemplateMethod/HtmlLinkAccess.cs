using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.TemplateMethod
{
    public class HtmlLinkAccess:HtmlDataAccess
    {
        public HtmlLinkAccess(string path,string nameOfTheFile) : base(path, nameOfTheFile)
        {
            ElemRetriever = new LinkRetriever();
        }

        public override void GetElements()
        {
            ElemList = ElemRetriever.GetElems(Path,Html).ToList();
        }

        public override void Save(string type = "binary")
        {
            base.Save(type);
        }
    }
}
