using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patterns.models;

namespace Patterns.TemplateMethod
{
    public class HtmlButtonAccess:HtmlDataAccess
    {
        public HtmlButtonAccess(string path,string nameOfTheFile):base(path, nameOfTheFile)
        {
            ElemRetriever = new ButtonRetriever();
        }

        public override void GetElements()
        {
            ElemList = ElemRetriever.GetElems(Path, Html).ToList();
        }
        public override void Save(string type = "binary")
        {
            base.Save(type);
        }
    }
}
