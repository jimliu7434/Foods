namespace FoodsForm
{
    partial class InputDataForm
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
            this.pnl_InputData = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ddl_Unit = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.datetime_Date = new System.Windows.Forms.DateTimePicker();
            this.datetime_StartDate = new System.Windows.Forms.DateTimePicker();
            this.datetime_EndDate = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pnl_InputData.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_InputData
            // 
            this.pnl_InputData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_InputData.Controls.Add(this.panel2);
            this.pnl_InputData.Controls.Add(this.panel1);
            this.pnl_InputData.Location = new System.Drawing.Point(12, 12);
            this.pnl_InputData.Name = "pnl_InputData";
            this.pnl_InputData.Size = new System.Drawing.Size(724, 233);
            this.pnl_InputData.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.datetime_EndDate);
            this.panel2.Controls.Add(this.datetime_StartDate);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox8);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.ddl_Unit);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(312, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 218);
            this.panel2.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "~";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(77, 128);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(218, 22);
            this.textBox8.TabIndex = 16;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(77, 53);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(68, 22);
            this.textBox6.TabIndex = 14;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(151, 53);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(186, 22);
            this.textBox5.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 8;
            this.label12.Text = "效期起迄";
            // 
            // ddl_Unit
            // 
            this.ddl_Unit.DisplayMember = "KG";
            this.ddl_Unit.FormattingEnabled = true;
            this.ddl_Unit.Items.AddRange(new object[] {
            "公斤",
            "公克",
            "台斤"});
            this.ddl_Unit.Location = new System.Drawing.Point(183, 14);
            this.ddl_Unit.Name = "ddl_Unit";
            this.ddl_Unit.Size = new System.Drawing.Size(64, 20);
            this.ddl_Unit.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 9;
            this.label11.Text = "認證標章";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(77, 12);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "重量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "品牌";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "供應商";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.datetime_Date);
            this.panel1.Controls.Add(this.btn_Send);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 218);
            this.panel1.TabIndex = 23;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(28, 155);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(109, 44);
            this.btn_Send.TabIndex = 24;
            this.btn_Send.Text = "送出";
            this.btn_Send.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(163, 155);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(104, 44);
            this.btn_Cancel.TabIndex = 23;
            this.btn_Cancel.Text = "放棄";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "菜色";
            // 
            // textBox3
            // 
            this.textBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox3.Location = new System.Drawing.Point(63, 107);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(204, 22);
            this.textBox3.TabIndex = 19;
            // 
            // textBox2
            // 
            this.textBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox2.Location = new System.Drawing.Point(63, 65);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(204, 22);
            this.textBox2.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "食材";
            // 
            // datetime_Date
            // 
            this.datetime_Date.CustomFormat = "yyyy/MM/dd";
            this.datetime_Date.Location = new System.Drawing.Point(63, 27);
            this.datetime_Date.Name = "datetime_Date";
            this.datetime_Date.Size = new System.Drawing.Size(144, 22);
            this.datetime_Date.TabIndex = 25;
            // 
            // datetime_StartDate
            // 
            this.datetime_StartDate.CustomFormat = "yyyy/MM/dd";
            this.datetime_StartDate.Location = new System.Drawing.Point(78, 171);
            this.datetime_StartDate.Name = "datetime_StartDate";
            this.datetime_StartDate.Size = new System.Drawing.Size(134, 22);
            this.datetime_StartDate.TabIndex = 26;
            this.datetime_StartDate.Value = new System.DateTime(2015, 12, 7, 17, 2, 44, 0);
            // 
            // datetime_EndDate
            // 
            this.datetime_EndDate.CustomFormat = "yyyy/MM/dd";
            this.datetime_EndDate.Location = new System.Drawing.Point(235, 171);
            this.datetime_EndDate.Name = "datetime_EndDate";
            this.datetime_EndDate.Size = new System.Drawing.Size(128, 22);
            this.datetime_EndDate.TabIndex = 27;
            this.datetime_EndDate.Value = new System.DateTime(2015, 12, 7, 17, 2, 35, 0);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(77, 91);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(217, 20);
            this.comboBox1.TabIndex = 28;
            // 
            // InputDataForm
            // 
            this.AcceptButton = this.btn_Send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(746, 251);
            this.ControlBox = false;
            this.Controls.Add(this.pnl_InputData);
            this.Name = "InputDataForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "輸入資料";
            this.TopMost = true;
            this.pnl_InputData.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_InputData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox ddl_Unit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker datetime_EndDate;
        private System.Windows.Forms.DateTimePicker datetime_StartDate;
        private System.Windows.Forms.DateTimePicker datetime_Date;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}