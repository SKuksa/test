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
                        if (tt.dataBrutto == DateTime.MinValue || tt.dataTara == DateTime.MinValue)
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
                        if (tt.dataBrutto == DateTime.MinValue || tt.dataTara == DateTime.MinValue)
                            AddItem(tt);
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1(new RecordWeight(Properties.Settings.Default.NumberCard++));
            if (frm.ShowDialog() == DialogResult.OK)
            {
        
                Properties.Settings.Default.Save();
                lock (listWeight)
                {
                    listWeight.Add(frm.rec);
                }
                SaveCards();
                if (buttonAll.FlatStyle == FlatStyle.Popup)
                    AddItem(frm.rec);
                else
                {
                    if(frm.rec.dataBrutto==DateTime.MinValue || frm.rec.dataTara==DateTime.MinValue)
                        AddItem(frm.rec);
                }
            }
        }
        void AddItem(RecordWeight it)
        {
            if (it.dataBrutto == DateTime.MinValue && it.dataTara == DateTime.MinValue)
                return;
            var arrstr = new[] { it.Number.ToString("D9"),
                                 it.dataBrutto>it.dataTara? it.dataBrutto.ToString("dd MM yyyy HH:mm:ss"): it.dataTara.ToString("dd MM yyyy HH:mm:ss"),
                                 it.Autor,
                                 it.Regim,
                                 it.Tovar,
                                 it.WeightBrutto.ToString(),
                                 it.WeightNetto.ToString(),
                                 it.WeightTara.ToString(),
                                 it.CarName,
                                 it.CarNumber};
            ListViewItem item = new ListViewItem(arrstr);
            item.Tag = it;
            listViewOperation.Items.Add(item);
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {
            string filename = Properties.Settings.Default.FileName;
            if (File.Exists(filename))
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

                foreach(var tt in listWeight)
                    if (buttonAll.FlatStyle == FlatStyle.Popup)
                        AddItem(tt);
                    else
                    {
                        if (tt.dataBrutto == DateTime.MinValue || tt.dataTara == DateTime.MinValue)
                            AddItem(tt);
                    }
            }
            Web();
        }
        private void SaveCards()
        {
                string filename = Properties.Settings.Default.FileName;
                var fs = new FileStream(filename, FileMode.Create);
                var writer = XmlDictionaryWriter.CreateTextWriter(fs);
                var ser = new NetDataContractSerializer();
            lock (listWeight)
            {
                ser.WriteObject(writer, listWeight);
            }
                writer.Close();
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
                        /*var rec = new RecordWeight[5];
                        for (int m = 0; m < 5; m++)
                        {
                            rec[m] = new RecordWeight();
                        }*/

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
                        }
                    } catch { }
                } });
        }
    }
}
