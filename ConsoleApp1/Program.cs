
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ConsoleApp1
{

    [DataContract]
    public class Weighman
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool isUsed { get; set; }
    }
    class Program
    {
        static private void SaveJsonDB(Type tp, object Values, string FileName)
        {

            ///MemoryStream stream1 = new MemoryStream();
            ///
            var strFile = File.Create(FileName);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(tp, new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
            ser.WriteObject(strFile, Values);
            strFile.Close();
        }
        static private object LoadJsonDB(Type tp, string FileName)
        {
       
            DataContractJsonSerializer ser = new DataContractJsonSerializer(tp, new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                var  newpeople = ser.ReadObject(fs);
                return newpeople;
            }

        }
        static void Main(string[] args)
        {
            List<Weighman> ls = new List<Weighman>();
            for (int i = 0; i < 5; i++)
            {
                ls.Add(new Weighman { Code = i.ToString(), Id=Guid.NewGuid(), isUsed = true, Name="БлаБла_"+i.ToString() });

            }
           SaveJsonDB(typeof(Weighman[]), ls.ToArray(), @"C:\temp\1\out.txt");
          //  return;

            var ret = (Weighman[])LoadJsonDB(typeof(Weighman[]), @"C:\temp\1\out.txt");
            foreach (var r in ret)
            {
                Console.WriteLine("-----------");
                Console.WriteLine(r.Name);
                Console.WriteLine(r.Id);
                Console.WriteLine(r.Code);
                Console.WriteLine(r.isUsed);
            }
        }
    }
}
