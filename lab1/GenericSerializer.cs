using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Patterns
{
    public class GenericSerializer
    {
        private string _name;
        private string _savePath;

        public GenericSerializer(string name,string savePath)
        {
            _name = name;
            _savePath = savePath;
        }
        public void BinarySerializing(FileMode mode, object ob)
        {
            using (FileStream fs = new FileStream(_savePath+ _name + ".bin", mode))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs,ob);
                Console.WriteLine("Object has been serialized");
            }
        }
        public object BinaryDeSerializing()
        {
            using (FileStream fs = new FileStream(_savePath + _name + ".bin", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                object ob = bf.Deserialize(fs);
                Console.WriteLine("Object has been Deserialized");
                return ob;
            }
        }

        public void DataContractSerialization(FileMode mode, Type type,object ob)
        {
            using (FileStream fs = new FileStream(_savePath + _name+".json", mode))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(type);
                jsonSerializer.WriteObject(fs,ob);
                Console.WriteLine("Object has been serialized to json file");
            }
        }
        public object DataContractDeSerialization(FileMode mode, Type type)
        {
            using (FileStream fs = new FileStream(_savePath + _name + ".json", mode))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(type);
                object ob = jsonSerializer.ReadObject(fs);
                Console.WriteLine("Object has been deserialized from file");
                return ob;

            }
        }
    }
}
