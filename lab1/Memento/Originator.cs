using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using Patterns.models;

namespace Patterns.Memento
{
    [DataContract]
    public class Originator
    {
        [DataMember]
        public MyHtmlModel MyHtmlModel { get; set; }
        [DataMember]
        public string StateName { get; set; }

        public Originator()
        {

        }

        public Originator(MyHtmlModel model)
        {
            MyHtmlModel = model;
            StateName = GenerateHashSum();
        }

        private string GenerateHashSum()
        {
            int length = 6;
            string symbols = "abcdefghigklmnopqrstuvwxyz";
            string res = String.Empty;
            while (length > 0)
            {
                res += symbols[new Random().Next(0, symbols.Length)];
                length--;
            }

            return res;
        }

        public void MakeChanges(WebCrawler webCrawler)
        {
            var model = webCrawler.LoadFromFile(MyHtmlModel.Name);
            MyHtmlModel = model;
            StateName = GenerateHashSum();
            Console.WriteLine($"Originator StateName changed to {StateName}");
        }
        public SnapShotOfMyHtmlModel Save()
        {
            //binary serialization

            return new SnapShotOfMyHtmlModel(MyHtmlModel, StateName);
        }
        public SnapShotOfMyHtmlModel Save(string name)
        {
            //binary serialization

            return new SnapShotOfMyHtmlModel(MyHtmlModel, name);
        }

        public void Restore(SnapShotOfMyHtmlModel model)
        {
            //binary deserialization
            if (model != null)
            {
                MyHtmlModel = model.MyHtmlModel;
                StateName = model.StateName;
            }
        }

    }
}
