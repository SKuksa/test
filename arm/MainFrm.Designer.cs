﻿namespace arm
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNesav = new System.Windows.Forms.Button();
            this.buttonAll = new System.Windows.Forms.Button();
            this.listViewOperation = new System.Windows.Forms.ListView();
            this.columnNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAutor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRegim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTovar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnContiner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNetto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnVesConteiner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNumberCar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEnded = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(66, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Взвешивания";
            // 
            // buttonNesav
            // 
            this.buttonNesav.Location = new System.Drawing.Point(337, 66);
            this.buttonNesav.Name = "buttonNesav";
            this.buttonNesav.Size = new System.Drawing.Size(233, 23);
            this.buttonNesav.TabIndex = 2;
            this.buttonNesav.Text = "Незавершенные взвешивания";
            this.buttonNesav.UseVisualStyleBackColor = true;
            this.buttonNesav.Click += new System.EventHandler(this.buttonNesav_Click);
            // 
            // buttonAll
            // 
            this.buttonAll.Location = new System.Drawing.Point(577, 65);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(308, 23);
            this.buttonAll.TabIndex = 3;
            this.buttonAll.Text = "Все взвешивания";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // listViewOperation
            // 
            this.listViewOperation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNumber,
            this.columnData,
            this.columnAutor,
            this.columnRegim,
            this.columnTovar,
            this.columnContiner,
            this.columnNetto,
            this.columnVesConteiner,
            this.columnCar,
            this.columnNumberCar,
            this.columnEnded});
            this.listViewOperation.Location = new System.Drawing.Point(12, 132);
            this.listViewOperation.Name = "listViewOperation";
            this.listViewOperation.Size = new System.Drawing.Size(1057, 449);
            this.listViewOperation.TabIndex = 4;
            this.listViewOperation.UseCompatibleStateImageBehavior = false;
            this.listViewOperation.View = System.Windows.Forms.View.Details;
            this.listViewOperation.MouseDoubleClick += ListViewOperation_MouseDoubleClick1;
            // 
            // columnNumber
            // 
            this.columnNumber.Text = "Номер";
            this.columnNumber.Width = 66;
            // 
            // columnData
            // 
            this.columnData.Text = "Дата";
            this.columnData.Width = 68;
            // 
            // columnAutor
            // 
            this.columnAutor.Text = "Автор";
            this.columnAutor.Width = 79;
            // 
            // columnRegim
            // 
            this.columnRegim.Text = "Режим взвешивания";
            this.columnRegim.Width = 126;
            // 
            // columnTovar
            // 
            this.columnTovar.Text = "Товар";
            this.columnTovar.Width = 56;
            // 
            // columnContiner
            // 
            this.columnContiner.Text = "Брутто";
            this.columnContiner.Width = 95;
            // 
            // columnNetto
            // 
            this.columnNetto.Text = "Нетто";
            this.columnNetto.Width = 59;
            // 
            // columnVesConteiner
            // 
            this.columnVesConteiner.Text = "Вес контейнера";
            this.columnVesConteiner.Width = 108;
            // 
            // columnCar
            // 
            this.columnCar.Text = "Автомобиль";
            this.columnCar.Width = 87;
            // 
            // columnNumberCar
            // 
            this.columnNumberCar.Text = "Номерной знак";
            this.columnNumberCar.Width = 102;
            // 
            // columnEnded
            // 
            this.columnEnded.Text = "Завершенная";
            this.columnEnded.Width = 85;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 593);
            this.Controls.Add(this.listViewOperation);
            this.Controls.Add(this.buttonAll);
            this.Controls.Add(this.buttonNesav);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "MainFrm";
            this.Text = "Взвешивание транспорта";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        private void ListViewOperation_MouseDoubleClick1(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            for (int i = 0; i < listViewOperation.Items.Count; i++)
            {
                var rectangle = listViewOperation.GetItemRect(i);
                if (rectangle.Contains(e.Location))
                {
                    if (listViewOperation.Items[i].Tag != null)
                    {
                        Form1 frm = new Form1(((RecordWeight)(listViewOperation.Items[i].Tag)));
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            lock (listWeight)
                            {
                                for (int j = 0; j < listWeight.Count; j++)
                                    if (listWeight[j].Number == frm.rec.Number)
                                        listWeight[j] = frm.rec;
                            }

                            listViewOperation.Items[i].Tag = frm.rec;

                            listViewOperation.Items[i].SubItems[0].Text = frm.rec.Number.ToString("D9");
                            listViewOperation.Items[i].SubItems[1].Text = frm.rec.dataBrutto > frm.rec.dataTara ? frm.rec.dataBrutto.ToString("dd MM yyyy HH:mm:ss") : frm.rec.dataTara.ToString("dd MM yyyy HH:mm:ss");
                            listViewOperation.Items[i].SubItems[2].Text = frm.rec.Autor;
                            listViewOperation.Items[i].SubItems[3].Text = frm.rec.Regim;
                            listViewOperation.Items[i].SubItems[4].Text = frm.rec.Tovar;
                            listViewOperation.Items[i].SubItems[5].Text = frm.rec.WeightBrutto.ToString();
                            listViewOperation.Items[i].SubItems[6].Text = frm.rec.WeightNetto.ToString();
                            listViewOperation.Items[i].SubItems[7].Text = frm.rec.WeightTara.ToString();
                            listViewOperation.Items[i].SubItems[8].Text = frm.rec.CarName;
                            listViewOperation.Items[i].SubItems[9].Text = frm.rec.CarNumber;

                            if (buttonAll.FlatStyle == System.Windows.Forms.FlatStyle.Popup)
                               ;
                            else
                            {
                                if (frm.rec.dataBrutto != System.DateTime.MinValue && frm.rec.dataTara != System.DateTime.MinValue)
                                    listViewOperation.Items.RemoveAt(i);
                                ;
                            }
                            SaveCards();
                            return;
                        }
                    }
                    return;
                }
            }
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNesav;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.ListView listViewOperation;
        private System.Windows.Forms.ColumnHeader columnNumber;
        private System.Windows.Forms.ColumnHeader columnData;
        private System.Windows.Forms.ColumnHeader columnAutor;
        private System.Windows.Forms.ColumnHeader columnContiner;
        private System.Windows.Forms.ColumnHeader columnRegim;
        private System.Windows.Forms.ColumnHeader columnTovar;
        private System.Windows.Forms.ColumnHeader columnNetto;
        private System.Windows.Forms.ColumnHeader columnVesConteiner;
        private System.Windows.Forms.ColumnHeader columnCar;
        private System.Windows.Forms.ColumnHeader columnNumberCar;
        private System.Windows.Forms.ColumnHeader columnEnded;
    }
}