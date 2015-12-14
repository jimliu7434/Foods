namespace FoodsForm
{
    partial class DailyMenu
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControl = new System.Windows.Forms.TabControl();
            this.Tab_Dish = new System.Windows.Forms.TabPage();
            this.group_ReadNewFile = new System.Windows.Forms.GroupBox();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_OpenFileDialog = new System.Windows.Forms.Button();
            this.pnl_ReadNewFile = new System.Windows.Forms.Panel();
            this.lbl_ReadNewFilePath = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.供餐日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.菜色編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.菜色名稱 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.食材編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.食材名稱 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.重量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.單位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品牌製造商 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.產地製造商所在地 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.供應商統編 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.供應商名稱 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.認證標章 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.進貨製造日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.有效期限 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tab_Supplier = new System.Windows.Forms.TabPage();
            this.group_DisplaySupplier = new System.Windows.Forms.GroupBox();
            this.ckb_DisplaySupplier = new System.Windows.Forms.CheckedListBox();
            this.Tab_Material = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.maskPictureBox = new System.Windows.Forms.PictureBox();
            this.textBoxAutoComplete = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.TabControl.SuspendLayout();
            this.Tab_Dish.SuspendLayout();
            this.group_ReadNewFile.SuspendLayout();
            this.pnl_ReadNewFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Tab_Supplier.SuspendLayout();
            this.group_DisplaySupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maskPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.Tab_Dish);
            this.TabControl.Controls.Add(this.Tab_Supplier);
            this.TabControl.Controls.Add(this.Tab_Material);
            this.TabControl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1367, 424);
            this.TabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.TabControl.TabIndex = 0;
            // 
            // Tab_Dish
            // 
            this.Tab_Dish.Controls.Add(this.group_ReadNewFile);
            this.Tab_Dish.Controls.Add(this.dataGridView1);
            this.Tab_Dish.Location = new System.Drawing.Point(4, 29);
            this.Tab_Dish.Name = "Tab_Dish";
            this.Tab_Dish.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Dish.Size = new System.Drawing.Size(1359, 391);
            this.Tab_Dish.TabIndex = 0;
            this.Tab_Dish.Text = "每日菜單";
            this.Tab_Dish.UseVisualStyleBackColor = true;
            // 
            // group_ReadNewFile
            // 
            this.group_ReadNewFile.Controls.Add(this.btn_Export);
            this.group_ReadNewFile.Controls.Add(this.btn_OpenFileDialog);
            this.group_ReadNewFile.Controls.Add(this.pnl_ReadNewFile);
            this.group_ReadNewFile.Location = new System.Drawing.Point(16, 18);
            this.group_ReadNewFile.Name = "group_ReadNewFile";
            this.group_ReadNewFile.Size = new System.Drawing.Size(1337, 108);
            this.group_ReadNewFile.TabIndex = 3;
            this.group_ReadNewFile.TabStop = false;
            this.group_ReadNewFile.Text = "檔案";
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(911, 38);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(399, 45);
            this.btn_Export.TabIndex = 0;
            this.btn_Export.Text = "匯出";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_OpenFileDialog
            // 
            this.btn_OpenFileDialog.Location = new System.Drawing.Point(655, 45);
            this.btn_OpenFileDialog.Name = "btn_OpenFileDialog";
            this.btn_OpenFileDialog.Size = new System.Drawing.Size(99, 31);
            this.btn_OpenFileDialog.TabIndex = 1;
            this.btn_OpenFileDialog.Text = "開啟檔案";
            this.btn_OpenFileDialog.UseVisualStyleBackColor = true;
            this.btn_OpenFileDialog.Click += new System.EventHandler(this.btn_OpenFileDialog_Click);
            // 
            // pnl_ReadNewFile
            // 
            this.pnl_ReadNewFile.Controls.Add(this.lbl_ReadNewFilePath);
            this.pnl_ReadNewFile.Location = new System.Drawing.Point(6, 29);
            this.pnl_ReadNewFile.Name = "pnl_ReadNewFile";
            this.pnl_ReadNewFile.Size = new System.Drawing.Size(634, 58);
            this.pnl_ReadNewFile.TabIndex = 2;
            // 
            // lbl_ReadNewFilePath
            // 
            this.lbl_ReadNewFilePath.AutoSize = true;
            this.lbl_ReadNewFilePath.Location = new System.Drawing.Point(14, 21);
            this.lbl_ReadNewFilePath.Name = "lbl_ReadNewFilePath";
            this.lbl_ReadNewFilePath.Size = new System.Drawing.Size(166, 20);
            this.lbl_ReadNewFilePath.TabIndex = 0;
            this.lbl_ReadNewFilePath.Text = "lbl_ReadNewFilePath";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.供餐日期,
            this.菜色編號,
            this.菜色名稱,
            this.食材編號,
            this.食材名稱,
            this.重量,
            this.單位,
            this.品牌製造商,
            this.產地製造商所在地,
            this.供應商統編,
            this.供應商名稱,
            this.認證標章,
            this.進貨製造日期,
            this.有效期限});
            this.dataGridView1.Location = new System.Drawing.Point(16, 132);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1338, 250);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.Resize += new System.EventHandler(this.dataGridView1_Resize);
            // 
            // 供餐日期
            // 
            this.供餐日期.DataPropertyName = "供餐日期";
            this.供餐日期.HeaderText = "供餐日期";
            this.供餐日期.Name = "供餐日期";
            this.供餐日期.Width = 76;
            // 
            // 菜色編號
            // 
            this.菜色編號.DataPropertyName = "菜色編號";
            this.菜色編號.HeaderText = "菜色編號";
            this.菜色編號.Name = "菜色編號";
            this.菜色編號.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.菜色編號.Width = 76;
            // 
            // 菜色名稱
            // 
            this.菜色名稱.DataPropertyName = "菜色名稱";
            this.菜色名稱.HeaderText = "菜色名稱";
            this.菜色名稱.Name = "菜色名稱";
            this.菜色名稱.Width = 76;
            // 
            // 食材編號
            // 
            this.食材編號.DataPropertyName = "食材編號";
            this.食材編號.HeaderText = "食材編號";
            this.食材編號.Name = "食材編號";
            this.食材編號.Width = 76;
            // 
            // 食材名稱
            // 
            this.食材名稱.DataPropertyName = "食材名稱";
            this.食材名稱.HeaderText = "食材名稱";
            this.食材名稱.Name = "食材名稱";
            this.食材名稱.Width = 76;
            // 
            // 重量
            // 
            this.重量.DataPropertyName = "重量";
            this.重量.HeaderText = "重量";
            this.重量.Name = "重量";
            this.重量.Width = 61;
            // 
            // 單位
            // 
            this.單位.DataPropertyName = "單位";
            this.單位.HeaderText = "單位";
            this.單位.Name = "單位";
            this.單位.Width = 61;
            // 
            // 品牌製造商
            // 
            this.品牌製造商.DataPropertyName = "品牌製造商";
            this.品牌製造商.HeaderText = "品牌(製造商)";
            this.品牌製造商.Name = "品牌製造商";
            this.品牌製造商.Width = 95;
            // 
            // 產地製造商所在地
            // 
            this.產地製造商所在地.DataPropertyName = "產地製造商所在地";
            this.產地製造商所在地.HeaderText = "產地(製造商所在地)";
            this.產地製造商所在地.Name = "產地製造商所在地";
            this.產地製造商所在地.Width = 109;
            // 
            // 供應商統編
            // 
            this.供應商統編.DataPropertyName = "供應商統編";
            this.供應商統編.HeaderText = "供應商統編";
            this.供應商統編.Name = "供應商統編";
            this.供應商統編.Width = 90;
            // 
            // 供應商名稱
            // 
            this.供應商名稱.DataPropertyName = "供應商名稱";
            this.供應商名稱.HeaderText = "供應商名稱";
            this.供應商名稱.Name = "供應商名稱";
            this.供應商名稱.Width = 90;
            // 
            // 認證標章
            // 
            this.認證標章.DataPropertyName = "認證標章";
            this.認證標章.HeaderText = "認證標章";
            this.認證標章.Name = "認證標章";
            this.認證標章.Width = 76;
            // 
            // 進貨製造日期
            // 
            this.進貨製造日期.DataPropertyName = "進貨製造日期";
            this.進貨製造日期.HeaderText = "進貨(製造)日期";
            this.進貨製造日期.Name = "進貨製造日期";
            this.進貨製造日期.Width = 99;
            // 
            // 有效期限
            // 
            this.有效期限.DataPropertyName = "有效期限";
            this.有效期限.HeaderText = "有效期限";
            this.有效期限.Name = "有效期限";
            this.有效期限.Width = 76;
            // 
            // Tab_Supplier
            // 
            this.Tab_Supplier.Controls.Add(this.group_DisplaySupplier);
            this.Tab_Supplier.Location = new System.Drawing.Point(4, 29);
            this.Tab_Supplier.Name = "Tab_Supplier";
            this.Tab_Supplier.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Supplier.Size = new System.Drawing.Size(1359, 391);
            this.Tab_Supplier.TabIndex = 1;
            this.Tab_Supplier.Text = "供應商設定";
            this.Tab_Supplier.UseVisualStyleBackColor = true;
            // 
            // group_DisplaySupplier
            // 
            this.group_DisplaySupplier.Controls.Add(this.ckb_DisplaySupplier);
            this.group_DisplaySupplier.Location = new System.Drawing.Point(20, 20);
            this.group_DisplaySupplier.Name = "group_DisplaySupplier";
            this.group_DisplaySupplier.Size = new System.Drawing.Size(698, 416);
            this.group_DisplaySupplier.TabIndex = 0;
            this.group_DisplaySupplier.TabStop = false;
            this.group_DisplaySupplier.Text = "供應商顯示";
            // 
            // ckb_DisplaySupplier
            // 
            this.ckb_DisplaySupplier.FormattingEnabled = true;
            this.ckb_DisplaySupplier.Location = new System.Drawing.Point(24, 29);
            this.ckb_DisplaySupplier.Name = "ckb_DisplaySupplier";
            this.ckb_DisplaySupplier.Size = new System.Drawing.Size(650, 364);
            this.ckb_DisplaySupplier.TabIndex = 0;
            // 
            // Tab_Material
            // 
            this.Tab_Material.Location = new System.Drawing.Point(4, 29);
            this.Tab_Material.Name = "Tab_Material";
            this.Tab_Material.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Material.Size = new System.Drawing.Size(1359, 391);
            this.Tab_Material.TabIndex = 2;
            this.Tab_Material.Text = "食材設定";
            this.Tab_Material.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // maskPictureBox
            // 
            this.maskPictureBox.Location = new System.Drawing.Point(998, -15);
            this.maskPictureBox.Name = "maskPictureBox";
            this.maskPictureBox.Size = new System.Drawing.Size(100, 50);
            this.maskPictureBox.TabIndex = 7;
            this.maskPictureBox.TabStop = false;
            this.maskPictureBox.Visible = false;
            // 
            // textBoxAutoComplete
            // 
            this.textBoxAutoComplete.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxAutoComplete.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxAutoComplete.Location = new System.Drawing.Point(1105, 2);
            this.textBoxAutoComplete.Name = "textBoxAutoComplete";
            this.textBoxAutoComplete.Size = new System.Drawing.Size(100, 22);
            this.textBoxAutoComplete.TabIndex = 8;
            this.textBoxAutoComplete.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(829, -15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 22);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // DailyMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1382, 438);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBoxAutoComplete);
            this.Controls.Add(this.maskPictureBox);
            this.Controls.Add(this.TabControl);
            this.Name = "DailyMenu";
            this.Text = "每日菜單";
            this.Load += new System.EventHandler(this.DailyMenu_Load);
            this.TabControl.ResumeLayout(false);
            this.Tab_Dish.ResumeLayout(false);
            this.group_ReadNewFile.ResumeLayout(false);
            this.pnl_ReadNewFile.ResumeLayout(false);
            this.pnl_ReadNewFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Tab_Supplier.ResumeLayout(false);
            this.group_DisplaySupplier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.maskPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage Tab_Dish;
        private System.Windows.Forms.TabPage Tab_Supplier;
        private System.Windows.Forms.TabPage Tab_Material;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel pnl_ReadNewFile;
        private System.Windows.Forms.Label lbl_ReadNewFilePath;
        private System.Windows.Forms.GroupBox group_ReadNewFile;
        private System.Windows.Forms.Button btn_OpenFileDialog;
        private System.Windows.Forms.GroupBox group_DisplaySupplier;
        private System.Windows.Forms.CheckedListBox ckb_DisplaySupplier;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.PictureBox maskPictureBox;
		private System.Windows.Forms.TextBox textBoxAutoComplete;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 供餐日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 菜色編號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 菜色名稱;
        private System.Windows.Forms.DataGridViewTextBoxColumn 食材編號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 食材名稱;
        private System.Windows.Forms.DataGridViewTextBoxColumn 重量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 單位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品牌製造商;
        private System.Windows.Forms.DataGridViewTextBoxColumn 產地製造商所在地;
        private System.Windows.Forms.DataGridViewTextBoxColumn 供應商統編;
        private System.Windows.Forms.DataGridViewTextBoxColumn 供應商名稱;
        private System.Windows.Forms.DataGridViewTextBoxColumn 認證標章;
        private System.Windows.Forms.DataGridViewTextBoxColumn 進貨製造日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 有效期限;
    }
}

