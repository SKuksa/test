
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        public override string ToString()
        {
            return Name;
        }
    }
    [DataContract]
    public class WeighingMode
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    [DataContract]
    public class Shipper
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool isUsed { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    [DataContract]
    public class Material
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public bool isUsed { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    [DataContract]
    public class Consignee
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool isUsed { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    [DataContract]
    public class RespCodeToWeb
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Code { get; set; }
    }
    [DataContract]
    public class Cars
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid Code { get; set; }
        [DataMember]
        public string CarNumber { get; set; }
        [DataMember]
        public string TrailerNumber { get; set; }
        [DataMember]
        public string Carbrand { get; set; }
        [DataMember]
        public string Driver { get; set; }
        [DataMember]
        public Guid Shipper { get; set; }
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
            SetCars();
            SetMaterials();
            SetConsignee();
            SetShipper();
            SetWeighingMode();
            SetWeighman();
            /*
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
            }*/
        }
        public static string SetWeighman()
        {
            var req = HttpWebRequest.Create("http://localhost:8080/WEIGHMAN");
            req.Method = "POST";
            req.Credentials = CredentialCache.DefaultCredentials;

            MemoryStream stream1 = new MemoryStream();
            List<Weighman> car = new List<Weighman>();
            for (int i = 0; i < 10; i++)
            {
                car.Add(new Weighman() {  Name="Весовщик"+i.ToString(), isUsed = true, Id = Guid.NewGuid()});
        
            }
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Weighman[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
            ser.WriteObject(stream1, car.ToArray());
            stream1.Position = 0;



            //StringReader sr = new StringReader("{ \"login\": \"user1\" , \"password\": \"user1\"}");
            byte[] ch = new byte[stream1.Length];
            var cnt = stream1.Read(ch, 0, (int)stream1.Length);
            req.ContentLength = stream1.Length;
            req.ContentType = "application/json";
            var strem = req.GetRequestStream();
            strem.Write(ch, 0, (int)stream1.Length);
            //for (int i = 0; i < cnt; i++)
            //{
            //strem.WriteByte((byte)ch[i]);
            //}
            strem.Close();
            var resp = (HttpWebResponse)req.GetResponse();
            System.Console.WriteLine("<--------------------");
            System.Console.WriteLine("ContentType:");
            System.Console.WriteLine("              " + resp.ContentType);
            System.Console.WriteLine("ContentLength:{0}", resp.ContentLength);
            System.Console.WriteLine("");
            var res_str = resp.GetResponseStream();
            byte[] br = new byte[(int)resp.ContentLength];
            res_str.Read(br, 0, (int)resp.ContentLength);
            res_str.Close();


            var memstr = new MemoryStream();
            var rdr = new StreamReader(memstr, Encoding.UTF8);
            memstr.Write(br, 0, br.Length);
            memstr.Position = 0;
            var ret = rdr.ReadToEnd();
            rdr.Close();
            memstr.Close();
            System.Console.WriteLine(ret);
            foreach (var VARIABLE in resp.Headers)
            {

                System.Console.WriteLine(VARIABLE);
            }
            for (int i = 0; i < resp.Headers.Count; ++i)
            {
                Console.WriteLine("\nHeader Name:{0}, Header value :{1}", resp.Headers.Keys[i], resp.Headers[i]);
                if (resp.Headers.Keys[i] == "Set-Cookie")
                {
                    var token = resp.Headers[i].Split('=');
                    resp.Close();
                    return token[1];

                }
            }

            System.Console.WriteLine("cookies");
            foreach (Cookie cookieValue in resp.Cookies)
                System.Console.WriteLine(cookieValue.ToString());
            resp.Close();
            return string.Empty;
        }
        public static string SetWeighingMode()
        {
            var req = HttpWebRequest.Create("http://localhost:8080/WEIGHINGMODE");
            req.Method = "POST";
            req.Credentials = CredentialCache.DefaultCredentials;

            MemoryStream stream1 = new MemoryStream();
            List<WeighingMode> car = new List<WeighingMode>();
            //for (int i = 0; i < 10; i++)
            {
                car.Add(new WeighingMode() {  Id =0, Name ="Брутто_Тара"});
                car.Add(new WeighingMode() { Id = 0, Name = "Тара_Брутто"});
            }
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(WeighingMode[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
            ser.WriteObject(stream1, car.ToArray());
            stream1.Position = 0;



            //StringReader sr = new StringReader("{ \"login\": \"user1\" , \"password\": \"user1\"}");
            byte[] ch = new byte[stream1.Length];
            var cnt = stream1.Read(ch, 0, (int)stream1.Length);
            req.ContentLength = stream1.Length;
            req.ContentType = "application/json";
            var strem = req.GetRequestStream();
            strem.Write(ch, 0, (int)stream1.Length);
            //for (int i = 0; i < cnt; i++)
            //{
            //strem.WriteByte((byte)ch[i]);
            //}
            strem.Close();
            var resp = (HttpWebResponse)req.GetResponse();
            System.Console.WriteLine("<--------------------");
            System.Console.WriteLine("ContentType:");
            System.Console.WriteLine("              " + resp.ContentType);
            System.Console.WriteLine("ContentLength:{0}", resp.ContentLength);
            System.Console.WriteLine("");
            var res_str = resp.GetResponseStream();
            byte[] br = new byte[(int)resp.ContentLength];
            res_str.Read(br, 0, (int)resp.ContentLength);
            res_str.Close();


            var memstr = new MemoryStream();
            var rdr = new StreamReader(memstr, Encoding.UTF8);
            memstr.Write(br, 0, br.Length);
            memstr.Position = 0;
            var ret = rdr.ReadToEnd();
            rdr.Close();
            memstr.Close();
            System.Console.WriteLine(ret);
            foreach (var VARIABLE in resp.Headers)
            {

                System.Console.WriteLine(VARIABLE);
            }
            for (int i = 0; i < resp.Headers.Count; ++i)
            {
                Console.WriteLine("\nHeader Name:{0}, Header value :{1}", resp.Headers.Keys[i], resp.Headers[i]);
                if (resp.Headers.Keys[i] == "Set-Cookie")
                {
                    var token = resp.Headers[i].Split('=');
                    resp.Close();
                    return token[1];

                }
            }

            System.Console.WriteLine("cookies");
            foreach (Cookie cookieValue in resp.Cookies)
                System.Console.WriteLine(cookieValue.ToString());
            resp.Close();
            return string.Empty;
        }
        public static string SetShipper()
        {
            var req = HttpWebRequest.Create("http://localhost:8080/SHIPPERS");
            req.Method = "POST";
            req.Credentials = CredentialCache.DefaultCredentials;

            MemoryStream stream1 = new MemoryStream();
            List<Shipper> car = new List<Shipper>();
            for (int i = 0; i < 10; i++)
            {
                car.Add(new Shipper() { Id = Guid.NewGuid(), isUsed = true, Name = "Грузоотправитель" + i.ToString() });
            }
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Shipper[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
            ser.WriteObject(stream1, car.ToArray());
            stream1.Position = 0;



            //StringReader sr = new StringReader("{ \"login\": \"user1\" , \"password\": \"user1\"}");
            byte[] ch = new byte[stream1.Length];
            var cnt = stream1.Read(ch, 0, (int)stream1.Length);
            req.ContentLength = stream1.Length;
            req.ContentType = "application/json";
            var strem = req.GetRequestStream();
            strem.Write(ch, 0, (int)stream1.Length);
            //for (int i = 0; i < cnt; i++)
            //{
            //strem.WriteByte((byte)ch[i]);
            //}
            strem.Close();
            var resp = (HttpWebResponse)req.GetResponse();
            System.Console.WriteLine("<--------------------");
            System.Console.WriteLine("ContentType:");
            System.Console.WriteLine("              " + resp.ContentType);
            System.Console.WriteLine("ContentLength:{0}", resp.ContentLength);
            System.Console.WriteLine("");
            var res_str = resp.GetResponseStream();
            byte[] br = new byte[(int)resp.ContentLength];
            res_str.Read(br, 0, (int)resp.ContentLength);
            res_str.Close();


            var memstr = new MemoryStream();
            var rdr = new StreamReader(memstr, Encoding.UTF8);
            memstr.Write(br, 0, br.Length);
            memstr.Position = 0;
            var ret = rdr.ReadToEnd();
            rdr.Close();
            memstr.Close();
            System.Console.WriteLine(ret);
            foreach (var VARIABLE in resp.Headers)
            {

                System.Console.WriteLine(VARIABLE);
            }
            for (int i = 0; i < resp.Headers.Count; ++i)
            {
                Console.WriteLine("\nHeader Name:{0}, Header value :{1}", resp.Headers.Keys[i], resp.Headers[i]);
                if (resp.Headers.Keys[i] == "Set-Cookie")
                {
                    var token = resp.Headers[i].Split('=');
                    resp.Close();
                    return token[1];

                }
            }

            System.Console.WriteLine("cookies");
            foreach (Cookie cookieValue in resp.Cookies)
                System.Console.WriteLine(cookieValue.ToString());
            resp.Close();
            return string.Empty;
        }

        public static string SetConsignee()
        {
            var req = HttpWebRequest.Create("http://localhost:8080/CONSIGNEE");
            req.Method = "POST";
            req.Credentials = CredentialCache.DefaultCredentials;

            MemoryStream stream1 = new MemoryStream();
            List<Consignee> car = new List<Consignee>();
            for (int i = 0; i < 10; i++)
            {
                car.Add(new Consignee() {  Id = Guid.NewGuid(), isUsed =true, Name="Грузополучатель"+i.ToString()});
            }
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Consignee[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
            ser.WriteObject(stream1, car.ToArray());
            stream1.Position = 0;



            //StringReader sr = new StringReader("{ \"login\": \"user1\" , \"password\": \"user1\"}");
            byte[] ch = new byte[stream1.Length];
            var cnt = stream1.Read(ch, 0, (int)stream1.Length);
            req.ContentLength = stream1.Length;
            req.ContentType = "application/json";
            var strem = req.GetRequestStream();
            strem.Write(ch, 0, (int)stream1.Length);
            //for (int i = 0; i < cnt; i++)
            //{
            //strem.WriteByte((byte)ch[i]);
            //}
            strem.Close();
            var resp = (HttpWebResponse)req.GetResponse();
            System.Console.WriteLine("<--------------------");
            System.Console.WriteLine("ContentType:");
            System.Console.WriteLine("              " + resp.ContentType);
            System.Console.WriteLine("ContentLength:{0}", resp.ContentLength);
            System.Console.WriteLine("");
            var res_str = resp.GetResponseStream();
            byte[] br = new byte[(int)resp.ContentLength];
            res_str.Read(br, 0, (int)resp.ContentLength);
            res_str.Close();


            var memstr = new MemoryStream();
            var rdr = new StreamReader(memstr, Encoding.UTF8);
            memstr.Write(br, 0, br.Length);
            memstr.Position = 0;
            var ret = rdr.ReadToEnd();
            rdr.Close();
            memstr.Close();
            System.Console.WriteLine(ret);
            foreach (var VARIABLE in resp.Headers)
            {

                System.Console.WriteLine(VARIABLE);
            }
            for (int i = 0; i < resp.Headers.Count; ++i)
            {
                Console.WriteLine("\nHeader Name:{0}, Header value :{1}", resp.Headers.Keys[i], resp.Headers[i]);
                if (resp.Headers.Keys[i] == "Set-Cookie")
                {
                    var token = resp.Headers[i].Split('=');
                    resp.Close();
                    return token[1];

                }
            }

            System.Console.WriteLine("cookies");
            foreach (Cookie cookieValue in resp.Cookies)
                System.Console.WriteLine(cookieValue.ToString());
            resp.Close();
            return string.Empty;
        }
        public static string SetMaterials()
        {
            var req = HttpWebRequest.Create("http://localhost:8080/MATERIAL");
            req.Method = "POST";
            req.Credentials = CredentialCache.DefaultCredentials;

            MemoryStream stream1 = new MemoryStream();
            List<Material> car = new List<Material>();
            for (int i = 0; i < 10; i++)
            {
                car.Add(new Material() {  Name="Материал"+i.ToString(), Id = Guid.NewGuid(),  isUsed=true, Number = i  });
            }
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Material[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
            ser.WriteObject(stream1, car.ToArray());
            stream1.Position = 0;



            //StringReader sr = new StringReader("{ \"login\": \"user1\" , \"password\": \"user1\"}");
            byte[] ch = new byte[stream1.Length];
            var cnt = stream1.Read(ch, 0, (int)stream1.Length);
            req.ContentLength = stream1.Length;
            req.ContentType = "application/json";
            var strem = req.GetRequestStream();
            strem.Write(ch, 0, (int)stream1.Length);
            //for (int i = 0; i < cnt; i++)
            //{
            //strem.WriteByte((byte)ch[i]);
            //}
            strem.Close();
            var resp = (HttpWebResponse)req.GetResponse();
            System.Console.WriteLine("<--------------------");
            System.Console.WriteLine("ContentType:");
            System.Console.WriteLine("              " + resp.ContentType);
            System.Console.WriteLine("ContentLength:{0}", resp.ContentLength);
            System.Console.WriteLine("");
            var res_str = resp.GetResponseStream();
            byte[] br = new byte[(int)resp.ContentLength];
            res_str.Read(br, 0, (int)resp.ContentLength);
            res_str.Close();


            var memstr = new MemoryStream();
            var rdr = new StreamReader(memstr, Encoding.UTF8);
            memstr.Write(br, 0, br.Length);
            memstr.Position = 0;
            var ret = rdr.ReadToEnd();
            rdr.Close();
            memstr.Close();
            System.Console.WriteLine(ret);
            foreach (var VARIABLE in resp.Headers)
            {

                System.Console.WriteLine(VARIABLE);
            }
            for (int i = 0; i < resp.Headers.Count; ++i)
            {
                Console.WriteLine("\nHeader Name:{0}, Header value :{1}", resp.Headers.Keys[i], resp.Headers[i]);
                if (resp.Headers.Keys[i] == "Set-Cookie")
                {
                    var token = resp.Headers[i].Split('=');
                    resp.Close();
                    return token[1];

                }
            }

            System.Console.WriteLine("cookies");
            foreach (Cookie cookieValue in resp.Cookies)
                System.Console.WriteLine(cookieValue.ToString());
            resp.Close();
            return string.Empty;
        }
        public static string SetCars()
        {
            var req = HttpWebRequest.Create("http://localhost:8080/CARS");
            req.Method = "POST";
            req.Credentials = CredentialCache.DefaultCredentials;

            MemoryStream stream1 = new MemoryStream();
            List<Cars> car = new List<Cars>();
            for(int i=0;i<10;i++)
            {
                car.Add(new Cars() { Carbrand = "Модель" + i.ToString(), CarNumber = "Номер" +i.ToString(), Code = Guid.NewGuid(), Driver = "Водила" + i.ToString(), Id = Guid.NewGuid(), isUsed = true, Shipper = Guid.NewGuid(), TrailerNumber = "tr_num" + i.ToString() });
            }
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Cars[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
            ser.WriteObject(stream1, car.ToArray());
            stream1.Position = 0;



            //StringReader sr = new StringReader("{ \"login\": \"user1\" , \"password\": \"user1\"}");
            byte[] ch = new byte[stream1.Length];
            var cnt = stream1.Read(ch, 0, (int)stream1.Length);
            req.ContentLength = stream1.Length;
            req.ContentType = "application/json";
            var strem = req.GetRequestStream();
            strem.Write(ch, 0, (int)stream1.Length);
            //for (int i = 0; i < cnt; i++)
            //{
                //strem.WriteByte((byte)ch[i]);
            //}
            strem.Close();
            var resp = (HttpWebResponse)req.GetResponse();
            System.Console.WriteLine("<--------------------");
            System.Console.WriteLine("ContentType:");
            System.Console.WriteLine("              " + resp.ContentType);
            System.Console.WriteLine("ContentLength:{0}", resp.ContentLength);
            System.Console.WriteLine("");
            var res_str = resp.GetResponseStream();
            byte[] br = new byte[(int)resp.ContentLength];
            res_str.Read(br, 0, (int)resp.ContentLength);
            res_str.Close();


            var memstr = new MemoryStream();
            var rdr = new StreamReader(memstr, Encoding.UTF8);
            memstr.Write(br, 0, br.Length);
            memstr.Position = 0;
            var ret = rdr.ReadToEnd();
            rdr.Close();
            memstr.Close();
            System.Console.WriteLine(ret);
            foreach (var VARIABLE in resp.Headers)
            {

                System.Console.WriteLine(VARIABLE);
            }
            for (int i = 0; i < resp.Headers.Count; ++i)
            {
                Console.WriteLine("\nHeader Name:{0}, Header value :{1}", resp.Headers.Keys[i], resp.Headers[i]);
                if (resp.Headers.Keys[i] == "Set-Cookie")
                {
                    var token = resp.Headers[i].Split('=');
                    resp.Close();
                    return token[1];

                }
            }

            System.Console.WriteLine("cookies");
            foreach (Cookie cookieValue in resp.Cookies)
                System.Console.WriteLine(cookieValue.ToString());
            resp.Close();
            return string.Empty;
        }
    }
}
