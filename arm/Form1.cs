using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace arm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rec = new RecordWeight();
        }
        public Form1(RecordWeight _rec)
        {
            InitializeComponent();
            rec = _rec;
            Init();
        }

        public RecordWeight rec;
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(rec==null)
                comboBox1.SelectedIndex = 0;
            else
                if(rec.DateTare== DateTime.MinValue && rec.DateGross==DateTime.MinValue)
                    comboBox1.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (comboBox1.SelectedIndex == 0)
            {
                buttonBrutto.Visible = false;
                buttonBrutto.Enabled = false;
            }
            else
            {
                buttonBrutto.Visible = true;
                buttonBrutto.Enabled = true;
            }*/
        }

        private void buttonTara_Click(object sender, EventArgs e)
        {
            if (!AsNettoBrutto())
            {
                if (maskedTextBoxDataBrutto.Tag == null)
                {
                    MessageBox.Show("Не произведено взвешивание брутто");
                    return;
                }
            }
            int wig = 0;
            int.TryParse(textWeight.Text, out wig);
            if (wig == 0)
            {
                MessageBox.Show("Не задан вес тары");
                return;
            }

            maskedTextBoxDataTara.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            maskedTextBoxDataTara.Tag = DateTime.Now;

            textBoxTara.Text = textWeight.Text;
            //comboBoxAutor.SelectedItem
            textBoxAutorTara.Text = ((Weighman)comboBoxAutor.SelectedItem).ToString(); ; //textBoxAutor.Text;

            if (!AsNettoBrutto())
            {
                int Rasn = int.Parse(textBoxBrutto.Text) - int.Parse(textBoxTara.Text);
                if (Rasn <= 0)
                {
                    MessageBox.Show("Вес тары задан больше или равен брутто");
                    maskedTextBoxDataTara.Text = "";
                    textBoxAutorTara.Text = "";
                    textBoxTara.Text = "0";
                    maskedTextBoxDataTara.Tag = null;
                    return;
                }
                textBoxNetto.Text = (int.Parse(textBoxBrutto.Text) - int.Parse(textBoxTara.Text)).ToString();

                if (maskedTextBoxDataTara.Tag == null)
                {
                    MessageBox.Show("Не произведено взвешивание тары");
                    return;
                }
            }



        }
        bool AsNettoBrutto()
        {
            if (comboBox1.SelectedIndex == 0)
                return true;
            return false;
        }
        private void buttonBrutto_Click(object sender, EventArgs e)
        {
            if (AsNettoBrutto())
            {
                if (maskedTextBoxDataTara.Tag == null)
                {
                    MessageBox.Show("Не произведено взвешивание тары");
                    return;
                }
            }
            int wig = 0;
            int.TryParse(textWeight.Text, out wig);
            if (wig == 0)
            {
                MessageBox.Show("Не задан вес брутто");
                return;
            }


            maskedTextBoxDataBrutto.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            maskedTextBoxDataBrutto.Tag = DateTime.Now;
            textBoxBrutto.Text = textWeight.Text;
            textBoxAutorBrutto.Text = ((Weighman)comboBoxAutor.SelectedItem).ToString();
                ;// textBoxAutor.Text;

            if (AsNettoBrutto())
            {
                int Rasn = int.Parse(textBoxBrutto.Text) - int.Parse(textBoxTara.Text);
                if (Rasn <= 0)
                {
                    MessageBox.Show("Вес тары задан больше или равен брутто");
                    maskedTextBoxDataBrutto.Text = "";
                    textBoxAutorBrutto.Text = "";
                    textBoxBrutto.Text = "0";
                    maskedTextBoxDataBrutto.Tag = null;
                    return;
                }
                textBoxNetto.Text = (int.Parse(textBoxBrutto.Text) - int.Parse(textBoxTara.Text)).ToString();

                if (maskedTextBoxDataTara.Tag == null)
                {
                    MessageBox.Show("Не произведено взвешивание тары");
                    return;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
           
            DialogResult = DialogResult.OK;
             /*rec.AutoBrutto = textBoxAutorBrutto.Text;
            rec.Autor = textBoxAutor.Text;
            rec.AutoTara = textBoxAutorTara.Text;
            rec.CarDriver = textBoxVodila.Text;
            rec.CarName = textBoxAuto.Text;
            rec.CarNumber = textBoxAutoNumber.Text;
            if (maskedTextBoxDataBrutto.Tag != null)
                rec.dataBrutto = (DateTime)maskedTextBoxDataBrutto.Tag;
            else
                rec.dataBrutto = DateTime.MinValue;

            if (maskedTextBoxDataTara.Tag != null)
                rec.dataTara = (DateTime)maskedTextBoxDataTara.Tag;
            else
                rec.dataTara = DateTime.MinValue;

            rec.GrusOtprav = textBoxGrusoOtpr.Text;
            rec.GrusPoluch = textBoxGrusoPoluch.Text;
            rec.Number = int.Parse(textBoxNumberVs.Text);
            rec.Pricep = textBoxPricep.Text;
            rec.PricepNumber = textBoxPricepNumber.Text;
            rec.Sclad = textBoxSclad.Text;
            rec.Tovar = textBoxTovar.Text;
            rec.WeightBrutto = int.Parse(textBoxBrutto.Text);
            rec.WeightNetto = int.Parse(textBoxNetto.Text);
            rec.WeightTara = int.Parse(textBoxTara.Text);
            rec.Regim = (string)comboBox1.SelectedItem;*/
            Close();
        }
        void Init()
        {
            if (MainFrm.listWeighman != null)
            {
                lock (MainFrm.listWeighman)
                {
                    comboBoxAutor.Items.AddRange(MainFrm.listWeighman.OrderBy(x=>x.Name).ToArray());
                }
            }
            if (MainFrm.listCars != null)
            {
                lock (MainFrm.listCars)
                {
                    comboBoxAutoNumber.Items.AddRange(MainFrm.listCars.OrderBy(x=>x.CarNumber).ToArray());
                }
            }
            if (MainFrm.listShipper != null)
            {
                lock (MainFrm.listShipper)
                {
                    comboBoxGrusoOtpr.Items.AddRange(MainFrm.listShipper.OrderBy(x=>x.Name).ToArray());
                }
            }
            if (MainFrm.listConsignee != null)
            {
                lock (MainFrm.listConsignee)
                {
                    comboBoxGrusPoluch.Items.AddRange(MainFrm.listConsignee.OrderBy(x=>x.Name).ToArray());
                }
            }
            if (MainFrm.listMaterial != null)
            {
                lock (MainFrm.listMaterial)
                {
                    comboBoxTovar.Items.AddRange(MainFrm.listMaterial.OrderBy(x=>x.Name).ToArray());
                }
            }
            
            if (rec.DateTare == DateTime.MinValue && rec.DateGross == DateTime.MinValue)//Инициализация новой карточки
            {

            }

            if (rec.DateTare == DateTime.MinValue && rec.DateGross != DateTime.MinValue)//Взвесили брутто не взвесили нетто
            {
                maskedTextBoxDataBrutto.Text = rec.DateGross.ToString("dd/MM/yyyy hh:mm:ss");
                maskedTextBoxDataBrutto.Tag = rec.DateGross;
                comboBox1.SelectedIndex = 1;
                buttonBrutto.Enabled = false;
                buttonBrutto.Visible = false;


            }
            if (rec.DateTare != DateTime.MinValue && rec.DateGross == DateTime.MinValue)//Взвесили нетто не взвесили брутто
            {
                maskedTextBoxDataTara.Text = rec.DateTare.ToString("dd/MM/yyyy hh:mm:ss");
                maskedTextBoxDataTara.Tag = rec.DateTare;
                comboBox1.SelectedIndex = 0;
                buttonTara.Enabled = false;
                buttonTara.Visible = false;
            }

            if (rec.DateTare != DateTime.MinValue && rec.DateGross != DateTime.MinValue)//Все взвесили просмотр
            {
                //buttonSave.Text = "Закрыть";
                toolStripButtonSave.Text = "Закрыть";
                buttonTara.Enabled = false;
                buttonTara.Visible = false;
                buttonBrutto.Enabled = false;
                buttonBrutto.Visible = false;
                maskedTextBoxDataBrutto.Text = rec.DateGross.ToString("dd/MM/yyyy hh:mm:ss");
                maskedTextBoxDataBrutto.Tag = rec.DateGross;
                maskedTextBoxDataTara.Text = rec.DateTare.ToString("dd/MM/yyyy hh:mm:ss");
                maskedTextBoxDataTara.Tag = rec.DateTare;

                if(rec.DateTare> rec.DateGross)
                    comboBox1.SelectedIndex = 1;
                else
                    comboBox1.SelectedIndex = 0;
                textBoxAutorBrutto.Enabled=false;


                comboBoxAutor.Enabled = false;
                //textBoxAutor.Enabled = false;
                textBoxAutorTara.Enabled = false;
                textBoxVodila.Enabled = false;
                textBoxAuto.Enabled = false;
                comboBoxAutoNumber.Enabled = false;
                //textBoxAutoNumber.Enabled = false;

                //textBoxGrusoOtpr.Enabled = false;
                comboBoxGrusoOtpr.Enabled = false;
                //textBoxGrusoPoluch.Enabled = false;
                comboBoxGrusPoluch.Enabled = false;

                textBoxNumberVs.Enabled = false;
                textBoxPricep.Enabled = false;
                textBoxPricepNumber.Enabled = false;
                //textBoxSclad.Enabled = false;
                //textBoxTovar.Enabled = false;
                comboBoxTovar.Enabled = false;
                textBoxBrutto.Enabled = false;
                textBoxNetto.Enabled = false;
                textBoxTara.Enabled = false;
                comboBox1.Enabled = false;
                if (rec.WeighingMode == (string)comboBox1.SelectedItem)
                    if (comboBox1.SelectedIndex == 0)
                        comboBox1.SelectedIndex = 1;
                     else
                        comboBox1.SelectedIndex = 0;

            }


            textBoxAutorTara.Enabled = false;
            textBoxAutorBrutto.Enabled = false;



            foreach (var it in comboBoxAutor.Items)
            {
                if (((Weighman)it).Code == rec.WeighmanGross)
                    textBoxAutorBrutto.Text = ((Weighman)it).Name;
                if (((Weighman)it).Code == rec.WeighmanTare)
                    textBoxAutorTara.Text = ((Weighman)it).Name;


                //textBoxAutorTara.Text = rec.AutoTara;

                //textBoxAutorBrutto.Text = rec.WeighmanGross;// .AutoBrutto;
            }
            foreach (var it in comboBoxAutoNumber.Items)
            {
                if (((Cars)it).Code == rec.Autotruck)
                {
                    textBoxVodila.Text = ((Cars)it).Driver;
                    textBoxAuto.Text = ((Cars)it).Carbrand;
                    textBoxPricepNumber.Text = ((Cars)it).TrailerNumber;
                    comboBoxAutoNumber.SelectedItem = it;
                    break;
                }
                //textBoxVodila.Text = rec.CarDriver;
                //textBoxAuto.Text = rec.CarName;
                //textBoxAutoNumber.Text = rec.CarNumber;
            }

            //textBoxAutorBrutto.Text =   rec.AutoBrutto;
            //textBoxAutor.Text =rec.Autor;
            //textBoxAutorTara.Text =rec.AutoTara;
           // textBoxVodila.Text =rec.CarDriver;
            //textBoxAuto.Text =rec.CarName ;
            //textBoxAutoNumber.Text =rec.CarNumber;
            foreach(var it in comboBoxGrusoOtpr.Items)
            {
                if (((Shipper)it).Code == rec.Shipper)
                {
                    comboBoxGrusoOtpr.SelectedItem = it;
                    break;
                }

                //textBoxGrusoOtpr.Text = rec.GrusOtprav;

            }
            //textBoxGrusoOtpr.Text =rec.GrusOtprav;
            foreach (var it in comboBoxGrusPoluch.Items)
            {
                if (((Consignee)it).Code == rec.Consignee)
                {
                    comboBoxGrusPoluch.SelectedItem = it;
                    break;
                }

                //textBoxGrusoPoluch.Text = rec.GrusPoluch;
            }
            //textBoxGrusoPoluch.Text =rec.GrusPoluch;

            textBoxNumberVs.Text =rec.Code.ToString();
            //textBoxPricep.Text =rec.Pricep;
            //textBoxPricepNumber.Text =rec.PricepNumber;
            //textBoxSclad.Text =rec.Sclad;
            foreach(var it in comboBoxTovar.Items)
            {
                if (((Material)it).Code == rec.MaterialFact)
                {
                    comboBoxTovar.SelectedItem = it;
                    break;
                }
            }
            //textBoxTovar.Text=rec.Tovar ;
            textBoxBrutto.Text = rec.WeightGross.ToString();// = int.Parse(textBoxBrutto.Text);
            textBoxNetto.Text = rec.NetWeight.ToString();// = int.Parse(textBoxNetto.Text);
            textBoxTara.Text=rec.WeightTara.ToString();// = int.Parse(textBoxTara.Text);
            
        }

        private void comboBoxAutoNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAutoNumber.SelectedItem != null)
            {
                textBoxAuto.Text = ((Cars)comboBoxAutoNumber.SelectedItem).Carbrand;
                textBoxPricepNumber.Text = ((Cars)comboBoxAutoNumber.SelectedItem).TrailerNumber;
                textBoxVodila.Text = ((Cars)comboBoxAutoNumber.SelectedItem).Driver;
            }
        }
    }
}
