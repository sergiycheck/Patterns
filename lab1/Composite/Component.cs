using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using Patterns.models;

namespace Patterns.Composite
{
    public abstract class Component
    {
        public MyHtmlModel MyHtmlmodel { get; set; }

        public HtmlNode Node { get; set; }

        public Component(MyHtmlModel myHtmlModel)
        {
            MyHtmlmodel = myHtmlModel;
        }

        public virtual void Display()
        {
            if (MyHtmlmodel != null)
            {
                Console.WriteLine(MyHtmlmodel.Name);
                //Console.WriteLine(MyHtmlmodel.HTML);
            }
            
        }

        public virtual void Add(Component component) { }

        public virtual void Remove(Component component) { }
    }
}
