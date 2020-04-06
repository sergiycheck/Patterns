using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Patterns.Memento;
using Patterns.models;

namespace Patterns.TemplateMethod
{
    [Serializable]
    [DataContract]
    public abstract class HtmlDataAccess
    {
        protected string Path;
        protected HtmlDocument Html;
        private WebCrawler _crawler;
        protected IElemRetriever ElemRetriever;
        [DataMember]
        protected List<string> ElemList;
        protected string SavedPath = @"E:\studying\education\6сем\трпз\lab4\files\Saves\";
        private string _nameOfTheFile;
        /// <summary>
        /// This class is used in order to set path to the file and give name of the file 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="nameOfTheFile"></param>
        protected HtmlDataAccess(string path,string nameOfTheFile)
        {
            Path = path;
            _crawler = WebCrawler.GetInstance();
            _nameOfTheFile = nameOfTheFile;
        }
        /// <summary>
        /// you can choose json
        /// </summary>
        /// <param name="type"></param>
        public void Process(string type = "binary")
        {
            Load().Wait();
            GetElements();
            Save(type);
        }

        protected async Task Load()
        {
            Html = await _crawler.Download(Path);
        }
        public abstract void GetElements();

        public virtual void Save(string type ="binary")
        {
            switch (type)
            {
                case "binary":
                    using (FileStream fs = new FileStream(SavedPath + _nameOfTheFile+".dat", FileMode.Create))
                    {
                        //Html.Save(fs, Encoding.UTF8);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, ElemList);
                        Console.WriteLine($"{_nameOfTheFile} has been saved to binary file");
                    }
                    break;
                case "json":
                {
                    using (FileStream fs = new FileStream(SavedPath + _nameOfTheFile+".json", FileMode.Create))
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<string>));
                        jsonSerializer.WriteObject(fs, ElemList);
                        Console.WriteLine($"{_nameOfTheFile} has been saved to json file");
                    }
                    break;
                }
            }
            




        }
    }
}
