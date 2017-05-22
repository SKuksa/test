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
                if(rec.dataTara== DateTime.MinValue && rec.dataBrutto==DateTime.MinValue)
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
            textBoxAutorTara.Text = textBoxAutor.Text;

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
            textBoxAutorBrutto.Text = textBoxAutor.Text;

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
            rec.AutoBrutto = textBoxAutorBrutto.Text;
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
            rec.Regim = (string)comboBox1.SelectedItem;
            Close();
        }
        void Init()
        {
            if (rec.dataTara == DateTime.MinValue && rec.dataBrutto == DateTime.MinValue)//Инициализация новой карточки
            {

            }

            if (rec.dataTara == DateTime.MinValue && rec.dataBrutto != DateTime.MinValue)//Взвесили брутто не взвесили нетто
            {
                maskedTextBoxDataBrutto.Text = rec.dataBrutto.ToString("dd/MM/yyyy hh:mm:ss");
                maskedTextBoxDataBrutto.Tag = rec.dataBrutto;
                comboBox1.SelectedIndex = 1;
                buttonBrutto.Enabled = false;
                buttonBrutto.Visible = false;


            }
            if (rec.dataTara != DateTime.MinValue && rec.dataBrutto == DateTime.MinValue)//Взвесили нетто не взвесили брутто
            {
                maskedTextBoxDataTara.Text = rec.dataTara.ToString("dd/MM/yyyy hh:mm:ss");
                maskedTextBoxDataTara.Tag = rec.dataTara;
                comboBox1.SelectedIndex = 0;
                buttonTara.Enabled = false;
                buttonTara.Visible = false;
            }

            if (rec.dataTara != DateTime.MinValue && rec.dataBrutto != DateTime.MinValue)//Все взвесили просмотр
            {
                //buttonSave.Text = "Закрыть";
                toolStripButtonSave.Text = "Закрыть";
                buttonTara.Enabled = false;
                buttonTara.Visible = false;
                buttonBrutto.Enabled = false;
                buttonBrutto.Visible = false;
                maskedTextBoxDataBrutto.Text = rec.dataBrutto.ToString("dd/MM/yyyy hh:mm:ss");
                maskedTextBoxDataBrutto.Tag = rec.dataBrutto;
                maskedTextBoxDataTara.Text = rec.dataTara.ToString("dd/MM/yyyy hh:mm:ss");
                maskedTextBoxDataTara.Tag = rec.dataTara;

                if(rec.dataTara> rec.dataBrutto)
                    comboBox1.SelectedIndex = 1;
                else
                    comboBox1.SelectedIndex = 0;
                textBoxAutorBrutto.Enabled=false;
                textBoxAutor.Enabled = false;
                textBoxAutorTara.Enabled = false;
                textBoxVodila.Enabled = false;
                textBoxAuto.Enabled = false;
                textBoxAutoNumber.Enabled = false;

                textBoxGrusoOtpr.Enabled = false;
                textBoxGrusoPoluch.Enabled = false;

                textBoxNumberVs.Enabled = false;
                textBoxPricep.Enabled = false;
                textBoxPricepNumber.Enabled = false;
                textBoxSclad.Enabled = false;
                textBoxTovar.Enabled = false;
                textBoxBrutto.Enabled = false;
                textBoxNetto.Enabled = false;
                textBoxTara.Enabled = false;
                comboBox1.Enabled = false;
                if (rec.Regim == (string)comboBox1.SelectedItem)
                    if (comboBox1.SelectedIndex == 0)
                        comboBox1.SelectedIndex = 1;
                     else
                        comboBox1.SelectedIndex = 0;

            }


            textBoxAutorTara.Enabled = false;
            textBoxAutorBrutto.Enabled = false;



            textBoxAutorBrutto.Text =rec.AutoBrutto;
            textBoxAutor.Text =rec.Autor;
            textBoxAutorTara.Text =rec.AutoTara;
            textBoxVodila.Text =rec.CarDriver;
            textBoxAuto.Text =rec.CarName ;
            textBoxAutoNumber.Text =rec.CarNumber;

            textBoxGrusoOtpr.Text =rec.GrusOtprav;
            textBoxGrusoPoluch.Text =rec.GrusPoluch;

            textBoxNumberVs.Text =rec.Number.ToString();
            textBoxPricep.Text =rec.Pricep;
            textBoxPricepNumber.Text =rec.PricepNumber;
            textBoxSclad.Text =rec.Sclad;
            textBoxTovar.Text=rec.Tovar ;
            textBoxBrutto.Text = rec.WeightBrutto.ToString();// = int.Parse(textBoxBrutto.Text);
            textBoxNetto.Text = rec.WeightNetto.ToString();// = int.Parse(textBoxNetto.Text);
            textBoxTara.Text=rec.WeightTara.ToString();// = int.Parse(textBoxTara.Text);
        }

       
     
   
    }
}
