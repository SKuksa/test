using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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
            foreach (var tt in listWeight)
                if (buttonAll.FlatStyle == FlatStyle.Popup)
                    AddItem(tt);
                else
                {
                    if (tt.dataBrutto == DateTime.MinValue || tt.dataTara == DateTime.MinValue)
                        AddItem(tt);
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
            foreach (var tt in listWeight)
                if (buttonAll.FlatStyle == FlatStyle.Popup)
                    AddItem(tt);
                else
                {
                    if (tt.dataBrutto == DateTime.MinValue || tt.dataTara == DateTime.MinValue)
                        AddItem(tt);
                }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1(new RecordWeight(Properties.Settings.Default.NumberCard++));
            if (frm.ShowDialog() == DialogResult.OK)
            {
        
                Properties.Settings.Default.Save();
                listWeight.Add(frm.rec);
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
        }
        private void SaveCards()
        {
                string filename = Properties.Settings.Default.FileName;
                var fs = new FileStream(filename, FileMode.Create);
                var writer = XmlDictionaryWriter.CreateTextWriter(fs);
                var ser = new NetDataContractSerializer();
                ser.WriteObject(writer, listWeight);
                writer.Close();
        }
    }
}
