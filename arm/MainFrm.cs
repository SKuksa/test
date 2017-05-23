using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace arm
{
    public partial class MainFrm : Form
    {
        //int LastNumber;
        List<RecordWeight> listWeight;
        static public List<Material> listMaterial;
         /// <summary>
            /// Автомобили
            /// </summary>
        static public List<Cars> listCars;
        /// <summary>
        /// Грузоотправитель
        /// </summary>
        static public List<Shipper> listShipper;
        /// <summary>
        /// Грузполучатель
        /// </summary>
        static public List<Consignee> listConsignee;
        /// <summary>
        /// Режим взвешивания
        /// </summary>
        static public List<WeighingMode> listWeighingMode;
        /// <summary>
        /// Весовщик
        /// </summary>
        static public List<Weighman> listWeighman;
        public MainFrm()
        {
            InitializeComponent();
            listWeight = new List<RecordWeight>();
            buttonAll_Click(null, null);
        }

        private void buttonNesav_Click(object sender, EventArgs e)
        {
            if (buttonNesav.FlatStyle == FlatStyle.Standard)
            {
                buttonNesav.FlatStyle = FlatStyle.Popup;
                buttonAll.FlatStyle = FlatStyle.Standard;
            }
            listViewOperation.Items.Clear();
            lock (listWeight)
            {
                foreach (var tt in listWeight)
                    if (buttonAll.FlatStyle == FlatStyle.Popup)
                        AddItem(tt);
                    else
                    {
                        if (tt.DateGross == DateTime.MinValue || tt.DateTare == DateTime.MinValue)
                            AddItem(tt);
                    }
            }

        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            if (buttonAll.FlatStyle == FlatStyle.Standard)
            {
                buttonAll.FlatStyle = FlatStyle.Popup;
                buttonNesav.FlatStyle = FlatStyle.Standard;
            }
            listViewOperation.Items.Clear();
            lock (listWeight)
            {
                foreach (var tt in listWeight)
                    if (buttonAll.FlatStyle == FlatStyle.Popup)
                        AddItem(tt);
                    else
                    {
                        if (tt.DateGross == DateTime.MinValue || tt.DateTare == DateTime.MinValue)
                            AddItem(tt);
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileMaNum =Path.Combine(Properties.Settings.Default.PathDB, "numberdb.txt");
            int Numbercr = 0;
            if (System.IO.File.Exists(fileMaNum))
                Numbercr = BitConverter.ToInt32(System.IO.File.ReadAllBytes(fileMaNum), 0);

            Form1 frm = new Form1(new RecordWeight(Numbercr++));
            if (frm.ShowDialog() == DialogResult.OK)
            {

                System.IO.File.WriteAllBytes(fileMaNum, BitConverter.GetBytes(Numbercr));

                lock (listWeight)
                {
                    listWeight.Add(frm.rec);
                }
                SaveCards();
                if (buttonAll.FlatStyle == FlatStyle.Popup)
                    AddItem(frm.rec);
                else
                {
                    if(frm.rec.DateGross==DateTime.MinValue || frm.rec.DateTare==DateTime.MinValue)
                        AddItem(frm.rec);
                }
            }
        }
        void AddItem(RecordWeight it)
        {
            if (it.DateGross == DateTime.MinValue && it.DateTare == DateTime.MinValue)
                return;
            var arrstr = new[] { it.Code.ToString("D9"),
                                 it.DateGross>it.DateTare? it.DateGross.ToString("dd MM yyyy HH:mm:ss"): it.DateTare.ToString("dd MM yyyy HH:mm:ss"),
                                 /*it.Autor,
                                 it.Regim,
                                 it.Tovar,
                                 it.WeightBrutto.ToString(),
                                 it.WeightNetto.ToString(),
                                 it.WeightTara.ToString(),
                                 it.CarName,
                                 it.CarNumber,
                                 it.dataBrutto!=DateTime.MinValue && it.dataTara!=DateTime.MinValue? "ДА":"НЕТ" */};
            ListViewItem item = new ListViewItem(arrstr);
            item.Tag = it;
            listViewOperation.Items.Add(item);
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {
            try
            {
                object tmp = LoadJsonDB(typeof(Cars[]), Path.Combine(Properties.Settings.Default.PathDB, "listCars.txt"));
                if (tmp == null)
                    listCars = new List<Cars>();
                else
                    listCars = ((Cars[])tmp).ToList();

                tmp = LoadJsonDB(typeof(Material[]), Path.Combine(Properties.Settings.Default.PathDB, "listMaterial.txt"));
                if (tmp == null)
                    listMaterial = new List<Material>();
                else
                    listMaterial = ((Material[])tmp).ToList();


                tmp = LoadJsonDB(typeof(Shipper[]), Path.Combine(Properties.Settings.Default.PathDB, "listShipper.txt"));
                if (tmp != null)
                    listShipper = ((Shipper[])tmp).ToList();
                else
                    listShipper = new List<Shipper>();

                tmp = LoadJsonDB(typeof(Consignee[]), Path.Combine(Properties.Settings.Default.PathDB, "listConsignee.txt"));
                if (tmp != null)
                    listConsignee = ((Consignee[])tmp).ToList();
                else
                    listConsignee = new List<Consignee>();

                tmp = LoadJsonDB(typeof(WeighingMode[]), Path.Combine(Properties.Settings.Default.PathDB, "listWeighingMode.txt"));
                if (tmp != null)
                    listWeighingMode = ((WeighingMode[])tmp).ToList();
                else
                    listWeighingMode = new List<WeighingMode>();
               

                tmp = LoadJsonDB(typeof(Weighman[]), Path.Combine(Properties.Settings.Default.PathDB, "listWeighman.txt"));
                if (tmp != null)
                    listWeighman = ((Weighman[])tmp).ToList();
                else
                    listWeighman = new List<Weighman>(); 



                string filename = Path.Combine(Properties.Settings.Default.PathDB, "RecordWeight.txt");
                if (System.IO.File.Exists(filename))
                {
                    var fs = new FileStream(filename, FileMode.Open);
                    var reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                    var ser = new NetDataContractSerializer();
                    object tmpobj = ser.ReadObject(reader, true);
                    if (tmpobj != null)
                        listWeight = (List<RecordWeight>)tmpobj;
                    else
                        listWeight = new List<RecordWeight>();
                    fs.Close();

                    foreach (var tt in listWeight)
                        if (buttonAll.FlatStyle == FlatStyle.Popup)
                            AddItem(tt);
                        else
                        {
                            if (tt.DateGross == DateTime.MinValue || tt.DateTare == DateTime.MinValue)
                                AddItem(tt);
                        }
                }
                Web();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message,"Ошибка");
                Close();
                return;
            }
        }
        private void SaveCards()
        {
            string filename = Path.Combine(Properties.Settings.Default.PathDB, "RecordWeight.txt");
            //string filename = Properties.Settings.Default.FileName;
                var fs = new FileStream(filename, FileMode.Create);
                var writer = XmlDictionaryWriter.CreateTextWriter(fs);
                var ser = new NetDataContractSerializer();
            lock (listWeight)
            {
                ser.WriteObject(writer, listWeight);
            }
                writer.Close();
        }
 
     
    
      
        static private void SaveJsonDB(Type tp, object Values, string FileName)
        {
            try
            {
                ///MemoryStream stream1 = new MemoryStream();
                ///
                var strFile = System.IO.File.Create(FileName);
                DataContractJsonSerializer ser = new DataContractJsonSerializer(tp, new DataContractJsonSerializerSettings
                {
                    DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
                });
                ser.WriteObject(strFile, Values);
                strFile.Close();
            }
            catch (Exception ex) { }
        }
        static private object LoadJsonDB(Type tp, string FileName)
        {
            if (!System.IO.File.Exists(FileName))
                return null;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(tp, new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                var newpeople = ser.ReadObject(fs);
                return newpeople;
            }

        }
     
        void WebWeighing(string[] str, System.Net.HttpListenerContext context)
        {
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
            if (Start > End)
                return;
            RecordWeight[] rec;
            lock (listWeight)
            {
                rec = listWeight.ToArray();
            }
            rec = rec.Where(x =>
            {
                var date = x.DateGross > x.DateTare ? x.DateGross : x.DateTare;
                return date >= Start && date <= End;
            }).ToArray();
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

                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
            }

        }

        void WebMaterial(string[] str, System.Net.HttpListenerRequest request, System.Net.HttpListenerContext context)
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Material[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });

            System.IO.Stream strem = request.InputStream;
            int ln = (int)request.ContentLength64;
            var rdr = new StreamReader(stream1, Encoding.UTF8);
            byte[] buf = new byte[ln];

            strem.Read(buf, 0, ln);
            stream1.Write(buf, 0, ln);
            stream1.Position = 0;
            var obj = ser.ReadObject(stream1);

            lock (listMaterial)
            {
                listMaterial = ((Material[])obj).ToList();
                SaveJsonDB(typeof(Material[]), listMaterial.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "listMaterial.txt"));
            }

            var rs = listMaterial.Select(x =>
            {
                return new RespCodeToWeb() { Id = x.Id, Code = "1C-code" + x.Id.ToString() };
            }).ToArray();
            ser = new DataContractJsonSerializer(typeof(RespCodeToWeb[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
            stream1 = new MemoryStream();
            rdr = new StreamReader(stream1, Encoding.UTF8);
            ser.WriteObject(stream1, rs);
            stream1.Position = 0;
            var ret = rdr.ReadToEnd();
            rdr.Close();
            stream1.Close();
            {
                {
                    System.Net.HttpListenerResponse response = context.Response;
                    response.ContentType = "application/json";

                    string responseString = ret;

                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
            }
        }

        void WebCars(string[] str, System.Net.HttpListenerRequest request, System.Net.HttpListenerContext context)
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Cars[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
         
            System.IO.Stream strem = request.InputStream;
            int ln =(int)request.ContentLength64;
            var rdr = new StreamReader(stream1, Encoding.UTF8);
            byte[] buf = new byte[ln];

            strem.Read(buf, 0, ln);
            stream1.Write(buf, 0, ln);
            stream1.Position = 0;
            var obj = ser.ReadObject(stream1);
     
            lock (listCars)
            {
                listCars = ((Cars[])obj).ToList();
                SaveJsonDB(typeof(Cars[]), listCars.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "listCars.txt"));
            }

            var rs = listCars.Select(x =>
             {
                 return new RespCodeToWeb() { Id = x.Id, Code = "1C-code" + x.Id.ToString() };
             }).ToArray();
            ser= new DataContractJsonSerializer(typeof(RespCodeToWeb[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
            stream1 = new MemoryStream();
            rdr=new StreamReader(stream1, Encoding.UTF8);
            ser.WriteObject(stream1, rs);
            stream1.Position = 0;
            var ret = rdr.ReadToEnd();
            rdr.Close();
            stream1.Close();
            {
                {
                    System.Net.HttpListenerResponse response = context.Response;
                    response.ContentType = "application/json";

                    string responseString = ret;

                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
            }
        }
        void WebShippers(string[] str, System.Net.HttpListenerRequest request, System.Net.HttpListenerContext context)
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Shipper[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });

            System.IO.Stream strem = request.InputStream;
            int ln = (int)request.ContentLength64;
            var rdr = new StreamReader(stream1, Encoding.UTF8);
            byte[] buf = new byte[ln];

            strem.Read(buf, 0, ln);
            stream1.Write(buf, 0, ln);
            stream1.Position = 0;
            var obj = ser.ReadObject(stream1);
            lock (listShipper)
            {
                listShipper = ((Shipper[])obj).ToList();
                SaveJsonDB(typeof(Shipper[]), listShipper.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "listShipper.txt"));
            }

            var rs = listShipper.Select(x =>
            {
                return new RespCodeToWeb() { Id = x.Id, Code = "1C-code" + x.Id.ToString() };
            }).ToArray();
            ser = new DataContractJsonSerializer(typeof(RespCodeToWeb[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
            stream1 = new MemoryStream();
            rdr = new StreamReader(stream1, Encoding.UTF8);
            ser.WriteObject(stream1, rs);
            stream1.Position = 0;
            var ret = rdr.ReadToEnd();
            rdr.Close();
            stream1.Close();
            {
                {
                    System.Net.HttpListenerResponse response = context.Response;
                    response.ContentType = "application/json";

                    string responseString = ret;

                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
            }
        }
        void WebConsignee(string[] str, System.Net.HttpListenerRequest request, System.Net.HttpListenerContext context)
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Consignee[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });

            System.IO.Stream strem = request.InputStream;
            int ln = (int)request.ContentLength64;
            var rdr = new StreamReader(stream1, Encoding.UTF8);
            byte[] buf = new byte[ln];

            strem.Read(buf, 0, ln);
            stream1.Write(buf, 0, ln);
            stream1.Position = 0;
            var obj = ser.ReadObject(stream1);
            lock (listConsignee)
            {
                listConsignee = ((Consignee[])obj).ToList();
                SaveJsonDB(typeof(Consignee[]), listConsignee.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "listConsignee.txt"));
            }

            var rs = listConsignee.Select(x =>
            {
                return new RespCodeToWeb() { Id = x.Id, Code = "1C-code" + x.Id.ToString() };
            }).ToArray();
            ser = new DataContractJsonSerializer(typeof(RespCodeToWeb[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
            stream1 = new MemoryStream();
            rdr = new StreamReader(stream1, Encoding.UTF8);
            ser.WriteObject(stream1, rs);
            stream1.Position = 0;
            var ret = rdr.ReadToEnd();
            rdr.Close();
            stream1.Close();
            {
                {
                    System.Net.HttpListenerResponse response = context.Response;
                    response.ContentType = "application/json";

                    string responseString = ret;

                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
            }
        }
        void WebWeighman(string[] str, System.Net.HttpListenerRequest request, System.Net.HttpListenerContext context)
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Weighman[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });

            System.IO.Stream strem = request.InputStream;
            int ln = (int)request.ContentLength64;
            var rdr = new StreamReader(stream1, Encoding.UTF8);
            byte[] buf = new byte[ln];

            strem.Read(buf, 0, ln);
            stream1.Write(buf, 0, ln);
            stream1.Position = 0;
            var obj = ser.ReadObject(stream1);
            lock (listWeighman)
            {
                listWeighman = ((Weighman[])obj).ToList();
                SaveJsonDB(typeof(Weighman[]), listWeighman.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "listWeighman.txt"));
            }

            var rs = listWeighman.Select(x =>
            {
                return new RespCodeToWeb() { Id = x.Id, Code = "1C-code" + x.Id.ToString() };
            }).ToArray();
            ser = new DataContractJsonSerializer(typeof(RespCodeToWeb[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
            stream1 = new MemoryStream();
            rdr = new StreamReader(stream1, Encoding.UTF8);
            ser.WriteObject(stream1, rs);
            stream1.Position = 0;
            var ret = rdr.ReadToEnd();
            rdr.Close();
            stream1.Close();
            {
                {
                    System.Net.HttpListenerResponse response = context.Response;
                    response.ContentType = "application/json";

                    string responseString = ret;

                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
            }
        }
        void WebWeighingMode(string[] str, System.Net.HttpListenerContext context)
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(WeighingMode[]), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
            });
        
            var rdr = new StreamReader(stream1, Encoding.UTF8);
            WeighingMode[] rec;
            lock (listWeighingMode)
            {
                rec = listWeighingMode.ToArray();
            }
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

                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
            }

        }
        void Web()
        {
            System.Net.HttpListener listener = new System.Net.HttpListener();
            //Properties.Settings.Default.Host
            //listener.Prefixes.Add("http://localhost:8888/");
            listener.Prefixes.Add(Properties.Settings.Default.Host);
            listener.Start();
            System.Threading.Tasks.Task.Factory.StartNew(()=>
                {

                while (true)
                {
                        try
                        {
                            System.Net.HttpListenerContext context = listener.GetContext();
                            System.Net.HttpListenerRequest request = context.Request;
                            //DataStart = 2005-08-09T18: 31:42 & DataEnd = 2005-08-09T18: 31:42

                            var str = request.RawUrl.Split('&');
                            switch (str[0].ToUpper())
                            {
                                case "/WEIGHING":
                                    WebWeighing(str, context);
                                    break;
                                case "/CARS":
                                    WebCars(str, request, context);
                                    break;
                                case "/SHIPPERS":
                                    WebShippers(str, request, context);
                                    break;
                                case "/CONSIGNEE":
                                    WebConsignee(str, request, context);
                                    break;
                                case "/WEIGHMAN":
                                    WebWeighman(str, request, context);
                                    break;
                                case "/WEIGHINGMODE":
                                    WebWeighingMode(str, context);
                                    break;
                                case "/MATERIAL":
                                    WebMaterial(str, request, context);
                                    break;
                            }
                            /*
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
                        if (Start > End)
                            continue;
                        RecordWeight[] rec;
                        lock (listWeight)
                        {
                            rec = listWeight.ToArray();
                        }
                        rec = rec.Where(x =>
                        {
                            var date = x.dataBrutto > x.dataTara ? x.dataBrutto : x.dataTara;
                            return date >= Start && date <= End;
                        }).ToArray();
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
                        }*/
                    } catch { }
                } });
        }
    }
}
