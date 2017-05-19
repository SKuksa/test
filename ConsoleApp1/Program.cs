using arm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.HttpListener listener = new System.Net.HttpListener();
            listener.Prefixes.Add("http://localhost:8888/");
            listener.Start();
            Console.WriteLine("Ожидание подключений...");

            while (true)
            {
                System.Net.HttpListenerContext context = listener.GetContext();
                System.Net.HttpListenerRequest request = context.Request;
                //DataStart = 2005-08-09T18: 31:42 & DataEnd = 2005-08-09T18: 31:42
                var rec = new RecordWeight[5] ;
                for (int m = 0; m < 5; m++)
                {
                    rec[m] = new RecordWeight();
                }

                var str = request.RawUrl.Split('&');
                MemoryStream stream1 = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RecordWeight[]), new DataContractJsonSerializerSettings
                {
                    DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
                });
                DateTime Start = DateTime.MinValue;
                DateTime End = DateTime.MaxValue;
                if (str[1].StartsWith("DateStart="))
                {
                    var ts = str[1].Substring(10);
                    Start = DateTime.Parse(ts);
                }

                if (str[2].StartsWith("DateEnd="))
                {
                    var ts = str[2].Substring(8);
                    End = DateTime.Parse(ts);
                }
                var rdr = new StreamReader(stream1, Encoding.UTF8);
                ser.WriteObject(stream1, rec);
                stream1.Position = 0;
                var ret = rdr.ReadToEnd();
                rdr.Close();
                stream1.Close();
                {
                    {
                        System.Net.HttpListenerResponse response = context.Response;
                        response.ContentType = "application/json";

                        string responseString = ret;

                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                        response.ContentLength64 = buffer.Length;
                        Stream output = response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                        output.Close();
                    }
                }
            }
        }
    }
}
