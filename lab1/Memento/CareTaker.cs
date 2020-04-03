using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Patterns.Memento
{
    [DataContract]
    public class CareTaker
    {
        [DataMember]
        public List<SnapShotOfMyHtmlModel> SnapShotModels { get; set; }
        [DataMember]
        public Originator Originator { get; set; }

        public CareTaker()
        {

        }

        public CareTaker(Originator originator)
        {
            Originator = originator;
            SnapShotModels = new List<SnapShotOfMyHtmlModel>();

        }

        public async Task Save()
        {
            Console.WriteLine($"Saving originator state in memento. Name: {Originator.StateName}");
            SnapShotModels.Add(Originator.Save());

            //maybe bad format
            //using (FileStream fs = new FileStream($@"E:\studying\education\6сем\трпз\lab1\files\lab1\lab3_States\CareTaker.json", FileMode.OpenOrCreate))
            //{
            //    await JsonSerializer.SerializeAsync<CareTaker>(fs, this);
            //    Console.WriteLine("CareTaker has been saved to json file");
            //}

            //JsonSerializer serializer = new JsonSerializer();
            //serializer.NullValueHandling = NullValueHandling.Ignore;

            //using (StreamWriter sw = new StreamWriter(@"E:\studying\education\6сем\трпз\lab1\files\lab1\lab3_States\CareTakerNetSoft.json"))
            //using (JsonWriter writer = new JsonTextWriter(sw))
            //{
            //    serializer.Serialize(writer, this);

            //}

            //datacontractJsonSerialization
            DataContractSerialization(FileMode.OpenOrCreate);

        }

        private void DataContractSerialization(FileMode fileMode)
        {
            using (FileStream fs = new FileStream($@"E:\studying\education\6сем\трпз\lab1\files\lab1\lab3_States\CareTakerDataContract.json", fileMode))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(CareTaker));
                jsonSerializer.WriteObject(fs, this);
                Console.WriteLine("CareTaker has been saved to json file");
            }
        }

        public static async Task<CareTaker> RestoreFromFile()
        {
            try
            {


                //using (StreamReader file = File.OpenText(@"E:\studying\education\6сем\трпз\lab1\files\lab1\lab3_States\CareTakerNetSoft.json"))
                //using (JsonTextReader reader = new JsonTextReader(file))
                //{
                //    JObject jsonObject = (JObject)JToken.ReadFrom(reader);

                //    CareTaker careTaker = JsonConvert.DeserializeObject<CareTaker>(jsonObject.ToString());

                //}

                //creates file with null properties
                //using (FileStream fs = new FileStream($@"E:\studying\education\6сем\трпз\lab1\files\lab1\lab3_States\CareTaker.json", FileMode.OpenOrCreate))
                //{

                //    var careTaker = await JsonSerializer.DeserializeAsync<CareTaker>(fs);
                //    Console.WriteLine("CareTaker has been created from json file");
                //    return careTaker;
                //}


                //datacontractJsonDeSerialization
                using (FileStream fs = new FileStream($@"E:\studying\education\6сем\трпз\lab1\files\lab1\lab3_States\CareTakerDataContract.json", FileMode.OpenOrCreate))
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(CareTaker));
                    var careTaker = jsonSerializer.ReadObject(fs) as CareTaker;
                    Console.WriteLine("CareTaker has been restored from json file");
                    return careTaker;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

            return null;
        }

        public void Compare(string name)
        {
            var model = SnapShotModels.Find(o => o.StateName == name);
            if (model.MyHtmlModel.HTML == Originator.MyHtmlModel.HTML)
            {
                Console.WriteLine($"SnapShot with state name{Originator.StateName} is the same as SnapShot with state name {name}");
            }
            else
            {
                Console.WriteLine($"SnapShot with state name{Originator.StateName} is not the same as SnapShot with state name {name}");
            }
        }
        public void Restore(string stateName)
        {
            if (SnapShotModels.Count > 0)
            {
                var model = SnapShotModels.Find(o => o.StateName == stateName);
                Console.WriteLine($"Restoring to state {model.StateName}");

                try
                {
                    Originator.Restore(model);
                    DataContractSerialization(FileMode.Create);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    
                }
            }
            else
            {
                return;
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("History of snapShots");
            foreach (var el in SnapShotModels)
            {
                Console.WriteLine($"{el.StateName}");
            }
        }
    }
}
