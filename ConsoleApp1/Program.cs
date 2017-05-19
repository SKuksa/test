using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                var str = request.RawUrl.Split('?');
                switch (str[0])
                {
                    case "/ListAllNumbers":
                        {
                            System.Net.HttpListenerResponse response = context.Response;

                            string responseString = "<html><head><meta charset='utf8'></head><body>ListAllNumbers</body></html>";
                            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                            response.ContentLength64 = buffer.Length;
                            Stream output = response.OutputStream;
                            output.Write(buffer, 0, buffer.Length);
                            output.Close();
                        }

                        break;
                    case "/UnFinishedNumber":
                        {
                            System.Net.HttpListenerResponse response = context.Response;

                            string responseString = "<html><head><meta charset='utf8'></head><body>UnFinishedNumber</body></html>";
                            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                            response.ContentLength64 = buffer.Length;
                            Stream output = response.OutputStream;
                            output.Write(buffer, 0, buffer.Length);
                            output.Close();
                        }

                        break;
                    case "/NumberCard":
                        {
                            System.Net.HttpListenerResponse response = context.Response;
                            response.ContentType = "application/json";

                            string responseString = "{\"reason\" : \"INVALID_USER_AUTHENTICATION\",\"message\" : \"Failed to authenticate principal, password was invalid\"}";
                        
                            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                            response.ContentLength64 = buffer.Length;
                            Stream output = response.OutputStream;
                            output.Write(buffer, 0, buffer.Length);
                            output.Close();
                        }
                        break;
                }


                /*
                System.Net.HttpListenerResponse response = context.Response;

                string responseString = "<html><head><meta charset='utf8'></head><body>Привет мир!</body></html>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();*/
            }
        }
    }
}
