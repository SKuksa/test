namespace arm
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
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(128)))), ((int)(((byte)(237)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(18, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Взвешивания";
            // 
            // buttonNesav
            // 
            this.buttonNesav.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonNesav.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.buttonNesav.FlatAppearance.BorderSize = 2;
            this.buttonNesav.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonNesav.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.buttonNesav.Location = new System.Drawing.Point(1312, 53);
            this.buttonNesav.Name = "buttonNesav";
            this.buttonNesav.Size = new System.Drawing.Size(248, 49);
            this.buttonNesav.TabIndex = 2;
            this.buttonNesav.Text = "Незавершенные взвешивания";
            this.buttonNesav.UseVisualStyleBackColor = false;
            this.buttonNesav.Click += new System.EventHandler(this.buttonNesav_Click);
            // 
            // buttonAll
            // 
            this.buttonAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.buttonAll.FlatAppearance.BorderSize = 2;
            this.buttonAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAll.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.buttonAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.buttonAll.Location = new System.Drawing.Point(1058, 53);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(248, 49);
            this.buttonAll.TabIndex = 3;
            this.buttonAll.Text = "Все взвешивания";
            this.buttonAll.UseVisualStyleBackColor = false;
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
            this.listViewOperation.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listViewOperation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.listViewOperation.Location = new System.Drawing.Point(18, 108);
            this.listViewOperation.Name = "listViewOperation";
            this.listViewOperation.Size = new System.Drawing.Size(1542, 722);
            this.listViewOperation.TabIndex = 4;
            this.listViewOperation.UseCompatibleStateImageBehavior = false;
            this.listViewOperation.View = System.Windows.Forms.View.Details;
            this.listViewOperation.MouseDoubleClick += ListViewOperation_MouseDoubleClick1;
            // 
            // columnNumber
            // 
            this.columnNumber.Text = "Номер";
            this.columnNumber.Width = 93;
            // 
            // columnData
            // 
            this.columnData.Text = "Дата";
            this.columnData.Width = 90;
            // 
            // columnAutor
            // 
            this.columnAutor.Text = "Автор";
            this.columnAutor.Width = 88;
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
            this.columnVesConteiner.Width = 134;
            // 
            // columnCar
            // 
            this.columnCar.Text = "Автомобиль";
            this.columnCar.Width = 108;
            // 
            // columnNumberCar
            // 
            this.columnNumberCar.Text = "Номерной знак";
            this.columnNumberCar.Width = 113;
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
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1584, 862);
            this.Controls.Add(this.listViewOperation);
            this.Controls.Add(this.buttonAll);
            this.Controls.Add(this.buttonNesav);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
                                    if (listWeight[j].Code == frm.rec.Code)
                                        listWeight[j] = frm.rec;
                            }

                            listViewOperation.Items[i].Tag = frm.rec;

                            listViewOperation.Items[i].SubItems[0].Text = frm.rec.Code.ToString("D9");
                            listViewOperation.Items[i].SubItems[1].Text = frm.rec.DateGross > frm.rec.DateTare ? frm.rec.DateGross.ToString("dd MM yyyy HH:mm:ss") : frm.rec.DateTare.ToString("dd MM yyyy HH:mm:ss");
                            /*listViewOperation.Items[i].SubItems[2].Text = frm.rec.Autor;
                            listViewOperation.Items[i].SubItems[3].Text = frm.rec.Regim;
                            listViewOperation.Items[i].SubItems[4].Text = frm.rec.Tovar;
                            listViewOperation.Items[i].SubItems[5].Text = frm.rec.WeightBrutto.ToString();
                            listViewOperation.Items[i].SubItems[6].Text = frm.rec.WeightNetto.ToString();
                            listViewOperation.Items[i].SubItems[7].Text = frm.rec.WeightTara.ToString();
                            listViewOperation.Items[i].SubItems[8].Text = frm.rec.CarName;
                            listViewOperation.Items[i].SubItems[9].Text = frm.rec.CarNumber;
                            listViewOperation.Items[i].SubItems[10].Text = frm.rec.DateGross != System.DateTime.MinValue && frm.rec.DateTare != System.DateTime.MinValue ? "ДА" : "НЕТ";*/

                            if (buttonAll.FlatStyle != System.Windows.Forms.FlatStyle.Popup)
                            {
                                if (frm.rec.DateGross != System.DateTime.MinValue && frm.rec.DateTare != System.DateTime.MinValue)
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