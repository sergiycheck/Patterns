using System.Runtime.Serialization;

namespace Patterns.models
{
    [DataContract]
    public class MyHtmlModel
    {
        public MyHtmlModel()
        {

        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string HTML { get; set; }
    }
}
