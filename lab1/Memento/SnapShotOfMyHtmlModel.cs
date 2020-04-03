using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
using Patterns.models;

namespace Patterns.Memento
{
    //Memento
    [Serializable]
    [DataContract]
    public class SnapShotOfMyHtmlModel
    {
        public SnapShotOfMyHtmlModel()
        {

        }
        public SnapShotOfMyHtmlModel(MyHtmlModel model, string name)
        {
            MyHtmlModel = model;
            StateName = name;
        }
        [DataMember]
        public MyHtmlModel MyHtmlModel { get; private set; }
        [DataMember]
        public string StateName { get; private set; }


    }
}
