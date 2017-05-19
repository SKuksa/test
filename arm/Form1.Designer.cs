namespace arm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonTara = new System.Windows.Forms.Button();
            this.textWeight = new System.Windows.Forms.TextBox();
            this.buttonBrutto = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxNumberVs = new System.Windows.Forms.TextBox();
            this.maskedTextBoxDataTara = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxDataBrutto = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxAutor = new System.Windows.Forms.TextBox();
            this.textBoxAutorTara = new System.Windows.Forms.TextBox();
            this.textBoxAutorBrutto = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxSclad = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxTovar = new System.Windows.Forms.TextBox();
            this.textBoxGrusoPoluch = new System.Windows.Forms.TextBox();
            this.textBoxGrusoOtpr = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxPricepNumber = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxPricep = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxVodila = new System.Windows.Forms.TextBox();
            this.textBoxAutoNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxAuto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxTara = new System.Windows.Forms.TextBox();
            this.textBoxBrutto = new System.Windows.Forms.TextBox();
            this.textBoxNetto = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(44, 57);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(140, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Записать и закрыть";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(40, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Взвешивание";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(40, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пост1 Режим взвешивания:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Тара_Брутто",
            "Брутто_тара"});
            this.comboBox1.Location = new System.Drawing.Point(267, 100);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(484, 2);
            this.label3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Текущий вес(кг):";
            // 
            // buttonTara
            // 
            this.buttonTara.Location = new System.Drawing.Point(228, 154);
            this.buttonTara.Name = "buttonTara";
            this.buttonTara.Size = new System.Drawing.Size(127, 63);
            this.buttonTara.TabIndex = 6;
            this.buttonTara.Text = "Взвесить тару";
            this.buttonTara.UseVisualStyleBackColor = true;
            this.buttonTara.Click += new System.EventHandler(this.buttonTara_Click);
            // 
            // textWeight
            // 
            this.textWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textWeight.Location = new System.Drawing.Point(53, 180);
            this.textWeight.Name = "textWeight";
            this.textWeight.Size = new System.Drawing.Size(155, 29);
            this.textWeight.TabIndex = 7;
            this.textWeight.Text = "0";
            // 
            // buttonBrutto
            // 
            this.buttonBrutto.Location = new System.Drawing.Point(379, 154);
            this.buttonBrutto.Name = "buttonBrutto";
            this.buttonBrutto.Size = new System.Drawing.Size(112, 63);
            this.buttonBrutto.TabIndex = 8;
            this.buttonBrutto.Text = "Взвесить брутто";
            this.buttonBrutto.UseVisualStyleBackColor = true;
            this.buttonBrutto.Click += new System.EventHandler(this.buttonBrutto_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Номер:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Дата тара:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Дата брутто:";
            // 
            // textBoxNumberVs
            // 
            this.textBoxNumberVs.Location = new System.Drawing.Point(125, 233);
            this.textBoxNumberVs.Name = "textBoxNumberVs";
            this.textBoxNumberVs.ReadOnly = true;
            this.textBoxNumberVs.Size = new System.Drawing.Size(83, 20);
            this.textBoxNumberVs.TabIndex = 12;
            // 
            // maskedTextBoxDataTara
            // 
            this.maskedTextBoxDataTara.Location = new System.Drawing.Point(125, 261);
            this.maskedTextBoxDataTara.Mask = "00 00 0000 90:00:00";
            this.maskedTextBoxDataTara.Name = "maskedTextBoxDataTara";
            this.maskedTextBoxDataTara.ReadOnly = true;
            this.maskedTextBoxDataTara.Size = new System.Drawing.Size(135, 20);
            this.maskedTextBoxDataTara.TabIndex = 13;
            // 
            // maskedTextBoxDataBrutto
            // 
            this.maskedTextBoxDataBrutto.Location = new System.Drawing.Point(129, 293);
            this.maskedTextBoxDataBrutto.Mask = "00/00/0000 90:00:00";
            this.maskedTextBoxDataBrutto.Name = "maskedTextBoxDataBrutto";
            this.maskedTextBoxDataBrutto.ReadOnly = true;
            this.maskedTextBoxDataBrutto.Size = new System.Drawing.Size(131, 20);
            this.maskedTextBoxDataBrutto.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(220, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Автор:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(268, 272);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "АвторТара:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(268, 300);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Автор брутто:";
            // 
            // textBoxAutor
            // 
            this.textBoxAutor.Location = new System.Drawing.Point(271, 240);
            this.textBoxAutor.Name = "textBoxAutor";
            this.textBoxAutor.Size = new System.Drawing.Size(412, 20);
            this.textBoxAutor.TabIndex = 18;
            // 
            // textBoxAutorTara
            // 
            this.textBoxAutorTara.Location = new System.Drawing.Point(340, 272);
            this.textBoxAutorTara.Name = "textBoxAutorTara";
            this.textBoxAutorTara.ReadOnly = true;
            this.textBoxAutorTara.Size = new System.Drawing.Size(343, 20);
            this.textBoxAutorTara.TabIndex = 19;
            // 
            // textBoxAutorBrutto
            // 
            this.textBoxAutorBrutto.Location = new System.Drawing.Point(340, 300);
            this.textBoxAutorBrutto.Name = "textBoxAutorBrutto";
            this.textBoxAutorBrutto.ReadOnly = true;
            this.textBoxAutorBrutto.Size = new System.Drawing.Size(343, 20);
            this.textBoxAutorBrutto.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBoxSclad);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.textBoxTovar);
            this.panel1.Controls.Add(this.textBoxGrusoPoluch);
            this.panel1.Controls.Add(this.textBoxGrusoOtpr);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.textBoxPricepNumber);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.textBoxPricep);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(32, 326);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 365);
            this.panel1.TabIndex = 21;
            // 
            // textBoxSclad
            // 
            this.textBoxSclad.Location = new System.Drawing.Point(437, 23);
            this.textBoxSclad.Name = "textBoxSclad";
            this.textBoxSclad.Size = new System.Drawing.Size(359, 20);
            this.textBoxSclad.TabIndex = 18;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(393, 29);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(38, 13);
            this.label22.TabIndex = 17;
            this.label22.Text = "Склад";
            // 
            // textBoxTovar
            // 
            this.textBoxTovar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTovar.Location = new System.Drawing.Point(145, 318);
            this.textBoxTovar.Name = "textBoxTovar";
            this.textBoxTovar.Size = new System.Drawing.Size(175, 20);
            this.textBoxTovar.TabIndex = 16;
            // 
            // textBoxGrusoPoluch
            // 
            this.textBoxGrusoPoluch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGrusoPoluch.Location = new System.Drawing.Point(145, 290);
            this.textBoxGrusoPoluch.Name = "textBoxGrusoPoluch";
            this.textBoxGrusoPoluch.Size = new System.Drawing.Size(175, 20);
            this.textBoxGrusoPoluch.TabIndex = 15;
            // 
            // textBoxGrusoOtpr
            // 
            this.textBoxGrusoOtpr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGrusoOtpr.Location = new System.Drawing.Point(146, 262);
            this.textBoxGrusoOtpr.Name = "textBoxGrusoOtpr";
            this.textBoxGrusoOtpr.Size = new System.Drawing.Size(175, 20);
            this.textBoxGrusoOtpr.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(40, 325);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Товар                    :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(40, 297);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 13);
            this.label17.TabIndex = 12;
            this.label17.Text = "Грузополучатель  :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(40, 269);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Грузоотправитель:";
            // 
            // textBoxPricepNumber
            // 
            this.textBoxPricepNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPricepNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPricepNumber.Location = new System.Drawing.Point(43, 227);
            this.textBoxPricepNumber.Name = "textBoxPricepNumber";
            this.textBoxPricepNumber.Size = new System.Drawing.Size(165, 30);
            this.textBoxPricepNumber.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(40, 207);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Номерной знак:";
            // 
            // textBoxPricep
            // 
            this.textBoxPricep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPricep.Location = new System.Drawing.Point(97, 178);
            this.textBoxPricep.Name = "textBoxPricep";
            this.textBoxPricep.Size = new System.Drawing.Size(213, 20);
            this.textBoxPricep.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(40, 181);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Прицеп:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.textBoxVodila);
            this.groupBox1.Controls.Add(this.textBoxAutoNumber);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBoxAuto);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(10, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 156);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // textBoxVodila
            // 
            this.textBoxVodila.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxVodila.Location = new System.Drawing.Point(105, 123);
            this.textBoxVodila.Name = "textBoxVodila";
            this.textBoxVodila.Size = new System.Drawing.Size(151, 20);
            this.textBoxVodila.TabIndex = 5;
            // 
            // textBoxAutoNumber
            // 
            this.textBoxAutoNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAutoNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAutoNumber.Location = new System.Drawing.Point(33, 77);
            this.textBoxAutoNumber.Name = "textBoxAutoNumber";
            this.textBoxAutoNumber.Size = new System.Drawing.Size(165, 30);
            this.textBoxAutoNumber.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Водитель:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Номерной знак:";
            // 
            // textBoxAuto
            // 
            this.textBoxAuto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAuto.Location = new System.Drawing.Point(105, 14);
            this.textBoxAuto.Name = "textBoxAuto";
            this.textBoxAuto.Size = new System.Drawing.Size(151, 20);
            this.textBoxAuto.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Автомобиль";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(29, 706);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 13);
            this.label19.TabIndex = 22;
            this.label19.Text = "Вес тары (кг):";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(200, 706);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 13);
            this.label20.TabIndex = 23;
            this.label20.Text = "Брутто (кг):";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(347, 706);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 13);
            this.label21.TabIndex = 24;
            this.label21.Text = "Нетто (кг):";
            // 
            // textBoxTara
            // 
            this.textBoxTara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTara.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTara.Location = new System.Drawing.Point(32, 733);
            this.textBoxTara.Name = "textBoxTara";
            this.textBoxTara.ReadOnly = true;
            this.textBoxTara.Size = new System.Drawing.Size(116, 30);
            this.textBoxTara.TabIndex = 25;
            // 
            // textBoxBrutto
            // 
            this.textBoxBrutto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBrutto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxBrutto.Location = new System.Drawing.Point(183, 733);
            this.textBoxBrutto.Name = "textBoxBrutto";
            this.textBoxBrutto.ReadOnly = true;
            this.textBoxBrutto.Size = new System.Drawing.Size(116, 30);
            this.textBoxBrutto.TabIndex = 26;
            // 
            // textBoxNetto
            // 
            this.textBoxNetto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNetto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNetto.Location = new System.Drawing.Point(350, 733);
            this.textBoxNetto.Name = "textBoxNetto";
            this.textBoxNetto.ReadOnly = true;
            this.textBoxNetto.Size = new System.Drawing.Size(116, 30);
            this.textBoxNetto.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(869, 875);
            this.Controls.Add(this.textBoxNetto);
            this.Controls.Add(this.textBoxBrutto);
            this.Controls.Add(this.textBoxTara);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxAutorBrutto);
            this.Controls.Add(this.textBoxAutorTara);
            this.Controls.Add(this.textBoxAutor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.maskedTextBoxDataBrutto);
            this.Controls.Add(this.maskedTextBoxDataTara);
            this.Controls.Add(this.textBoxNumberVs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonBrutto);
            this.Controls.Add(this.textWeight);
            this.Controls.Add(this.buttonTara);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSave);
            this.Name = "Form1";
            this.Text = " Карточка взвешивания";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void TextWeight_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }


        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonTara;
        private System.Windows.Forms.TextBox textWeight;
        private System.Windows.Forms.Button buttonBrutto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxNumberVs;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDataTara;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDataBrutto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxAutor;
        private System.Windows.Forms.TextBox textBoxAutorTara;
        private System.Windows.Forms.TextBox textBoxAutorBrutto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxTovar;
        private System.Windows.Forms.TextBox textBoxGrusoPoluch;
        private System.Windows.Forms.TextBox textBoxGrusoOtpr;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxPricepNumber;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxPricep;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxVodila;
        private System.Windows.Forms.TextBox textBoxAutoNumber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxAuto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBoxTara;
        private System.Windows.Forms.TextBox textBoxBrutto;
        private System.Windows.Forms.TextBox textBoxNetto;
        private System.Windows.Forms.TextBox textBoxSclad;
        private System.Windows.Forms.Label label22;
    }
}

