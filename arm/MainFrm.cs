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
        List<Weighing> listWeight;
        static public List<Material> listMaterial;
         /// <summary>
            /// Автомобили
            /// </summary>
        static public List<Autotruck> listCars;
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




        //--------------------------------------------------
        static public List<Material> ArhlistMaterial;
        /// <summary>
        /// Автомобили
        /// </summary>
        static public List<Autotruck> ArhlistCars;
        /// <summary>
        /// Грузоотправитель
        /// </summary>
        static public List<Shipper> ArhlistShipper;
        /// <summary>
        /// Грузполучатель
        /// </summary>
        static public List<Consignee> ArhlistConsignee;
        /// <summary>
        /// Режим взвешивания
        /// </summary>
        static public List<WeighingMode> ArhlistWeighingMode;
        /// <summary>
        /// Весовщик
        /// </summary>
        static public List<Weighman> ArhlistWeighman;
        //--------------------------------------------------
        public MainFrm()
        {
            InitializeComponent();
            listWeight = new List<Weighing>();
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

            Form1 frm = new Form1(new Weighing(Numbercr++));
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
        void AddItem(Weighing it)
        {
            if (it.DateGross == DateTime.MinValue && it.DateTare == DateTime.MinValue)
                return;
            string Autor = string.Empty;
            if (it.WeighmanGross != string.Empty)
            {
                Autor += ArhlistWeighman.First(x => x.Code == it.WeighmanGross).Name;
            }
            if (it.WeighmanGross != string.Empty)
            {
                Autor += "/";
                Autor += ArhlistWeighman.First(x => x.Code == it.WeighmanTare).Name;
            }
            string Tovar = "";
            if(it.MaterialFact!=string.Empty)
                Tovar = ArhlistMaterial.First(x=>x.Code==it.MaterialFact).Name;
            string CarName = string.Empty;
            string CarNumber = string.Empty;
            CarName = ArhlistCars.First(x => x.Code == it.Autotruck).Carbrand;
            CarNumber = ArhlistCars.First(x => x.Code == it.Autotruck).CarNumber;



            var arrstr = new[] { it.Code.ToString("D9"),
                                 it.DateGross>it.DateTare? it.DateGross.ToString("dd MM yyyy HH:mm:ss"): it.DateTare.ToString("dd MM yyyy HH:mm:ss"),
                                 Autor,
                                 it.WeighingMode== EWeighingMode.Cross_Tare? "Брутто_Тара":"Тара_Брутто",
                                 Tovar,
                                 it.WeightGross.ToString(),
                                 it.NetWeight.ToString(),
                                 it.WeightTara.ToString(),
                                  CarName,
                                 CarNumber,
                                 it.DateGross!=DateTime.MinValue && it.DateTare!=DateTime.MinValue? "ДА":"НЕТ"};
            ListViewItem item = new ListViewItem(arrstr);
            item.Tag = it;
            listViewOperation.Items.Add(item);
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {
            try
            {

                object tmp = LoadJsonDB(typeof(Autotruck[]), Path.Combine(Properties.Settings.Default.PathDB, "listCars.txt"));
                if (tmp == null)
                    listCars = new List<Autotruck>();
                else
                    listCars = ((Autotruck[])tmp).ToList();

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

                /*tmp = LoadJsonDB(typeof(WeighingMode[]), Path.Combine(Properties.Settings.Default.PathDB, "listWeighingMode.txt"));
                if (tmp != null)
                    listWeighingMode = listWeighingMode((WeighingMode[])tmp).ToList();
                else*/
                    listWeighingMode = new List<WeighingMode>();
                listWeighingMode.Add(new WeighingMode() { Mode = EWeighingMode.Cross_Tare });
                listWeighingMode.Add(new WeighingMode() { Mode = EWeighingMode.Tare_Gross });


                tmp = LoadJsonDB(typeof(Weighman[]), Path.Combine(Properties.Settings.Default.PathDB, "listWeighman.txt"));
                if (tmp != null)
                    listWeighman = ((Weighman[])tmp).ToList();
                else
                    listWeighman = new List<Weighman>();


                //*******************************************
                tmp = LoadJsonDB(typeof(Material[]), Path.Combine(Properties.Settings.Default.PathDB, "ArhlistMaterial.txt"));
                if (tmp != null)
                    ArhlistMaterial = ((Material[])tmp).ToList();
                else
                    ArhlistMaterial = new List<Material>();
                /// <summary>
                /// Автомобили
                /// </summary>
                tmp = LoadJsonDB(typeof(Autotruck[]), Path.Combine(Properties.Settings.Default.PathDB, "ArhlistCars.txt"));
                if (tmp != null)
                    ArhlistCars = ((Autotruck[])tmp).ToList();
                else
                    ArhlistCars = new List<Autotruck>();

                /// <summary>
                /// Грузоотправитель
                /// </summary>
                tmp = LoadJsonDB(typeof(Shipper[]), Path.Combine(Properties.Settings.Default.PathDB, "ArhlistShipper.txt"));
                if (tmp != null)
                    ArhlistShipper = ((Shipper[])tmp).ToList();
                else
                    ArhlistShipper = new List<Shipper>();
                /// <summary>
                /// Грузполучатель
                /// </summary>
                tmp = LoadJsonDB(typeof(Consignee[]), Path.Combine(Properties.Settings.Default.PathDB, "ArhlistConsignee.txt"));
                if (tmp != null)
                    ArhlistConsignee = ((Consignee[])tmp).ToList();
                else
                    ArhlistConsignee = new List<Consignee>();

                /// <summary>
                /// Режим взвешивания
                /// </summary>
                tmp = LoadJsonDB(typeof(WeighingMode[]), Path.Combine(Properties.Settings.Default.PathDB, "ArhlistWeighingMode.txt"));
                if (tmp != null)
                    ArhlistWeighingMode = ((WeighingMode[])tmp).ToList();
                else
                    ArhlistWeighingMode = new List<WeighingMode>();

                /// <summary>
                /// Весовщик
                /// </summary>
                tmp = LoadJsonDB(typeof(Weighman[]), Path.Combine(Properties.Settings.Default.PathDB, "ArhlistWeighman.txt"));
                if (tmp != null)
                    ArhlistWeighman = ((Weighman[])tmp).ToList();
                else
                    ArhlistWeighman = new List<Weighman>();

                //*******************************************


                string filename = Path.Combine(Properties.Settings.Default.PathDB, "RecordWeight.txt");
                if (System.IO.File.Exists(filename))
                {
                    var fs = new FileStream(filename, FileMode.Open);
                    var reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                    var ser = new NetDataContractSerializer();
                    object tmpobj = ser.ReadObject(reader, true);
                    if (tmpobj != null)
                        listWeight = (List<Weighing>)tmpobj;
                    else
                        listWeight = new List<Weighing>();
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
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Weighing[]), new DataContractJsonSerializerSettings
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
            Weighing[] rec;
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
                listMaterial.ForEach(x => x.Code = "1C-code" + x.Id.ToString());
                SaveJsonDB(typeof(Material[]), listMaterial.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "listMaterial.txt"));
                ArhlistMaterial = ArhlistMaterial.Union(listMaterial).ToList();
                SaveJsonDB(typeof(Material[]), ArhlistMaterial.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "ArhlistMaterial.txt"));
            }


            var rs = listMaterial.Select(x =>
            {
                return new RespCodeToWeb() { Id = x.Id, Code = x.Code };
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
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Autotruck[]), new DataContractJsonSerializerSettings
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
                listCars = ((Autotruck[])obj).ToList();
                listCars.ForEach(x => x.Code = "1C-code" + x.Id.ToString());
                SaveJsonDB(typeof(Autotruck[]), listCars.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "listCars.txt"));
                ArhlistCars = ArhlistCars.Union(listCars).ToList();
                SaveJsonDB(typeof(Autotruck[]), ArhlistCars.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "ArhlistCars.txt"));
            }

            var rs = listCars.Select(x =>
             {
                 return new RespCodeToWeb() { Id = x.Id, Code = x.Code };
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
                listShipper.ForEach(x => x.Code = "1C-code" + x.Id.ToString());
                SaveJsonDB(typeof(Shipper[]), listShipper.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "listShipper.txt"));
                ArhlistShipper = ArhlistShipper.Union(listShipper).ToList();
                SaveJsonDB(typeof(Shipper[]), ArhlistShipper.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "ArhlistShipper.txt"));
            }

            var rs = listShipper.Select(x =>
            {
                return new RespCodeToWeb() { Id = x.Id, Code =x.Code };
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
                listConsignee.ForEach(x => x.Code = "1C-code" + x.Id.ToString());
                SaveJsonDB(typeof(Consignee[]), listConsignee.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "listConsignee.txt"));
                ArhlistConsignee=ArhlistConsignee.Union(listConsignee).ToList();
                SaveJsonDB(typeof(Consignee[]), ArhlistConsignee.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "ArhlistConsignee.txt"));
            }

            var rs = listConsignee.Select(x =>
            {
                return new RespCodeToWeb() { Id = x.Id, Code = x.Code };
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
                listWeighman.ForEach(x => x.Code = "1C-code" + x.Id.ToString());
                SaveJsonDB(typeof(Weighman[]), listWeighman.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "listWeighman.txt"));
                ArhlistWeighman = ArhlistWeighman.Union(listWeighman).ToList();
                SaveJsonDB(typeof(Weighman[]), ArhlistWeighman.ToArray(), Path.Combine(Properties.Settings.Default.PathDB, "ArhlistWeighman.txt"));
            }

            var rs = listWeighman.Select(x =>
            {
                return new RespCodeToWeb() { Id = x.Id, Code = x.Code};
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
