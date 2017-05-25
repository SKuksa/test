using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace arm
{
    enum variantLoadImage
    {
        LoadBruttoAndTaraFromCamera,
        LoadOnlyBruttoFromCamera,
        LoadOnlyTaraFromCamera,
        LoadAllFromFiles
    };
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rec = new Weighing();
        }
        public Form1(Weighing _rec)
        {
            InitializeComponent();
            rec = _rec;
            Init();
        }

        public Weighing rec;
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
            if(comboBoxAutor.SelectedItem==null)
            {
                MessageBox.Show("Не задан весовщик");
                return;
            }



            maskedTextBoxDataTara.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            maskedTextBoxDataTara.Tag = DateTime.Now;

            textBoxTara.Text = textWeight.Text;
            //comboBoxAutor.SelectedItem
            textBoxAutorTara.Text = ((Weighman)comboBoxAutor.SelectedItem).ToString(); ; //textBoxAutor.Text;
            textBoxAutorTara.Tag = comboBoxAutor.SelectedItem;

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
            if (comboBoxAutor.SelectedItem == null)
            {
                MessageBox.Show("Не задан весовщик");
                return;
            }
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
            textBoxAutorBrutto.Tag = comboBoxAutor.SelectedItem;
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

            if (comboBoxAutoNumber.SelectedItem == null)
            {
                MessageBox.Show("Не задан автомобиль");
                return;
            }
            if (comboBoxGrusPoluch.SelectedItem == null)
            {
                MessageBox.Show("Не задан получатель");
                return;
            }
            if (comboBoxTovar.SelectedItem == null)
            {
                MessageBox.Show("Не задан товар");
                return;
            }
            if (comboBoxGrusoOtpr.SelectedItem == null)
            {
                MessageBox.Show("Не задан отправитель");
                return;
            }


            DialogResult = DialogResult.OK;


            rec.Autotruck = ((Autotruck)(comboBoxAutoNumber.SelectedItem)).Code;
            rec.Consignee = ((Consignee)(comboBoxGrusPoluch.SelectedItem)).Code;
            rec.Shipper = ((Shipper)(comboBoxGrusoOtpr.SelectedItem)).Code;
            rec.MaterialFact = ((Material)(comboBoxTovar.SelectedItem)).Code;
            rec.NetWeight = int.Parse(textBoxNetto.Text);
            rec.WeightGross = int.Parse(textBoxBrutto.Text);
            rec.WeightTara = int.Parse(textBoxTara.Text);

            if (maskedTextBoxDataBrutto.Tag != null)
                rec.DateGross = (DateTime)maskedTextBoxDataBrutto.Tag;
            else
                rec.DateGross = DateTime.MinValue;

            if (maskedTextBoxDataTara.Tag != null)
                rec.DateTare = (DateTime)maskedTextBoxDataTara.Tag;
            else
                rec.DateTare = DateTime.MinValue;
            if(textBoxAutorTara.Tag!=null)
                rec.WeighmanTare = ((Weighman)(textBoxAutorTara.Tag)).Code;
            if(textBoxAutorBrutto.Tag!=null)
                rec.WeighmanGross = ((Weighman)(textBoxAutorBrutto.Tag)).Code;

            //textBoxAutorBrutto.Text = ((Weighman)comboBoxAutor.SelectedItem).ToString();
            //textBoxAutorTara.Text = ((Weighman)comboBoxAutor.SelectedItem).ToString();
            //textBoxAutorTara.Tag =
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
        void LoadImageFromCameraOrFile(variantLoadImage TypeLoad)
        {
            if (TypeLoad == variantLoadImage.LoadBruttoAndTaraFromCamera || TypeLoad == variantLoadImage.LoadOnlyTaraFromCamera)
            {
                if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t1.jpg")))
                    System.IO.File.Delete(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t1.jpg"));

                if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t2.jpg")))
                    System.IO.File.Delete(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t2.jpg"));
            }

            if (TypeLoad == variantLoadImage.LoadBruttoAndTaraFromCamera || TypeLoad == variantLoadImage.LoadOnlyBruttoFromCamera)
            {
                if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b1.jpg")))
                    System.IO.File.Delete(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b1.jpg"));

                if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b2.jpg")))
                    System.IO.File.Delete(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b2.jpg"));
            }
            if (TypeLoad == variantLoadImage.LoadBruttoAndTaraFromCamera)
            {
                try
                {
                    var cm1 = new
                        LoadImageFromCamera(Properties.Settings.Default.Camera1Login,
                                            Properties.Settings.Default.Camera1Password,
                                            Properties.Settings.Default.Camera1Url,
                                            Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t1.jpg"),
                                            Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b1.jpg")
                        );
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось получить изображение с камеры1");
                }
                try
                {
                    var cm2 = new
                        LoadImageFromCamera(Properties.Settings.Default.Camera2Login,
                                            Properties.Settings.Default.Camera2Password,
                                            Properties.Settings.Default.Camera2Url,
                                            Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t2.jpg"),
                                            Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b2.jpg")

                        );
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось получить изображение с камеры2");
                }

            }
            if (TypeLoad == variantLoadImage.LoadOnlyBruttoFromCamera)
            {
                try
                {
                    var cm1 = new
                        LoadImageFromCamera(Properties.Settings.Default.Camera1Login,
                                            Properties.Settings.Default.Camera1Password,
                                            Properties.Settings.Default.Camera1Url,
                                            Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b1.jpg")
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось получить изображение с камеры2");
                }
                try
                {
                    var cm2 = new
                        LoadImageFromCamera(Properties.Settings.Default.Camera2Login,
                                            Properties.Settings.Default.Camera2Password,
                                            Properties.Settings.Default.Camera2Url,
                                            Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b2.jpg")

                        );
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось получить изображение с камеры2");
                }
            }
            if (TypeLoad == variantLoadImage.LoadOnlyTaraFromCamera)
            {
                try
                {
                    var cm1 = new
                        LoadImageFromCamera(Properties.Settings.Default.Camera1Login,
                                            Properties.Settings.Default.Camera1Password,
                                            Properties.Settings.Default.Camera1Url,
                                            Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t1.jpg")
                        );
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось получить изображение с камеры1");
                }
                try
                {
                    var cm2 = new
                        LoadImageFromCamera(Properties.Settings.Default.Camera2Login,
                                            Properties.Settings.Default.Camera2Password,
                                            Properties.Settings.Default.Camera2Url,
                                            Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t2.jpg")

                        );
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось получить изображение с камеры2");
                }
            }

            if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b1.jpg")))
            {
                using (var str = System.IO.File.Open(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b1.jpg"), FileMode.Open))
                {
                    pictureBoxBrutto1.Image = Image.FromStream(str);
                }
            }
            if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b2.jpg")))
            {
                using (var str = System.IO.File.Open(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b2.jpg"), FileMode.Open))
                {
                    pictureBoxBruuto2.Image = Image.FromStream(str);
                }
            }
            if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t1.jpg")))
            {
                using (var str = System.IO.File.Open(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t1.jpg"), FileMode.Open))
                {
                    pictureBoxTara1.Image = Image.FromStream(str);
                }
            }
            if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t2.jpg")))
            {
                using (var str = System.IO.File.Open(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t2.jpg"), FileMode.Open))
                {
                    pictureBoxTara2.Image = Image.FromStream(str);
                }
            }
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
                LoadImageFromCameraOrFile(variantLoadImage.LoadBruttoAndTaraFromCamera);
               /* if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t1.jpg")))
                    System.IO.File.Delete(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t1.jpg"));

                if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t2.jpg")))
                    System.IO.File.Delete(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t2.jpg"));

                if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b1.jpg")))
                    System.IO.File.Delete(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b1.jpg"));

                if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b2.jpg")))
                    System.IO.File.Delete(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b2.jpg"));


                var cm1 = new
                    LoadImageFromCamera(Properties.Settings.Default.Camera1Login,
                                        Properties.Settings.Default.Camera1Password,
                                        Properties.Settings.Default.Camera1Url,
                                        Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t1.jpg"),
                                        Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b1.jpg")
                    );
                var cm2 = new
                    LoadImageFromCamera(Properties.Settings.Default.Camera2Login,
                                        Properties.Settings.Default.Camera2Password,
                                        Properties.Settings.Default.Camera2Url,
                                        Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t2.jpg"),
                                        Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b2.jpg")
                    );
                if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b1.jpg")))
                {
                    using (var str = System.IO.File.Open(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b1.jpg"), FileMode.Open))
                    {
                        pictureBoxBrutto1.Image = Image.FromStream(str);
                    }
                }
                if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b2.jpg")))
                {
                    using (var str = System.IO.File.Open(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "b2.jpg"), FileMode.Open))
                    {
                        pictureBoxBruuto2.Image = Image.FromStream(str);
                    }
                }
                if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t1.jpg")))
                { 
                    using (var str = System.IO.File.Open(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t1.jpg"), FileMode.Open))
                    {
                        pictureBoxTara1.Image = Image.FromStream(str);
                    }
                }
                if (System.IO.File.Exists(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t2.jpg")))
                {
                    using (var str = System.IO.File.Open(Path.Combine(Properties.Settings.Default.PathDB, "images", rec.Code.ToString("D9") + "t2.jpg"), FileMode.Open))
                    {
                        pictureBoxTara2.Image = Image.FromStream(str);
                    }
                }*/
            }
            
            if (rec.DateTare == DateTime.MinValue && rec.DateGross != DateTime.MinValue)//Взвесили брутто не взвесили нетто
            {
                maskedTextBoxDataBrutto.Text = rec.DateGross.ToString("dd/MM/yyyy hh:mm:ss");
                maskedTextBoxDataBrutto.Tag = rec.DateGross;
                comboBox1.SelectedIndex = 1;
                buttonBrutto.Enabled = false;
                buttonBrutto.Visible = false;
                LoadImageFromCameraOrFile(variantLoadImage.LoadOnlyTaraFromCamera);
             }
            if (rec.DateTare != DateTime.MinValue && rec.DateGross == DateTime.MinValue)//Взвесили нетто не взвесили брутто
            {
                maskedTextBoxDataTara.Text = rec.DateTare.ToString("dd/MM/yyyy hh:mm:ss");
                maskedTextBoxDataTara.Tag = rec.DateTare;
                comboBox1.SelectedIndex = 0;
                buttonTara.Enabled = false;
                buttonTara.Visible = false;
                LoadImageFromCameraOrFile(variantLoadImage.LoadOnlyBruttoFromCamera);
             }

            if (rec.DateTare != DateTime.MinValue && rec.DateGross != DateTime.MinValue)//Все взвесили просмотр
            {
                 LoadImageFromCameraOrFile(variantLoadImage.LoadAllFromFiles);
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
                textBoxPricepNumber.Enabled = false;
                //textBoxSclad.Enabled = false;
                //textBoxTovar.Enabled = false;
                comboBoxTovar.Enabled = false;
                textBoxBrutto.Enabled = false;
                textBoxNetto.Enabled = false;
                textBoxTara.Enabled = false;
                comboBox1.Enabled = false;
                if (rec.WeighingMode== EWeighingMode.Cross_Tare)//  == (string)comboBox1.SelectedItem)
                    comboBox1.SelectedIndex = 1;
                /*if (comboBox1.SelectedIndex == 0)
                        comboBox1.SelectedIndex = 1;
                     else
                        comboBox1.SelectedIndex = 0;*/

            }


            textBoxAutorTara.Enabled = false;
            textBoxAutorBrutto.Enabled = false;


      
            foreach (var it in MainFrm.ArhlistWeighman)
            {
                if (((Weighman)it).Code == rec.WeighmanGross)
                {
                    textBoxAutorBrutto.Text = ((Weighman)it).Name;
                    textBoxAutorBrutto.Tag = it;
                }
                if (((Weighman)it).Code == rec.WeighmanTare)
                {
                    textBoxAutorTara.Text = ((Weighman)it).Name;
                    textBoxAutorTara.Tag = it;
                }

            }
            foreach (var it in comboBoxAutoNumber.Items)
            {
                if (((Autotruck)it).Code == rec.Autotruck)
                {
                    textBoxVodila.Text = ((Autotruck)it).Driver;
                    textBoxAuto.Text = ((Autotruck)it).Carbrand;
                    textBoxPricepNumber.Text = ((Autotruck)it).TrailerNumber;
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
                textBoxAuto.Text = ((Autotruck)comboBoxAutoNumber.SelectedItem).Carbrand;
                textBoxPricepNumber.Text = ((Autotruck)comboBoxAutoNumber.SelectedItem).TrailerNumber;
                textBoxVodila.Text = ((Autotruck)comboBoxAutoNumber.SelectedItem).Driver;
            }
        }
    }
}
