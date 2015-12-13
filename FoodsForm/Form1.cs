using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodsForm.Class;

namespace FoodsForm
{

    public partial class DailyMenu : Form
    {

        public DataTable SourceTable { get; set; }= new DataTable();

        public DailyMenu()
        {
            InitializeComponent();
        }

        private void DailyMenu_Load(object sender, EventArgs e)
        {
            InitState();
        }


        private async void InitState()
        {
            ShowMask();

            InitUI();
            await InitData();
            
            CloseMask();
        }

        
        private void InitUI()
        {
            lbl_ReadNewFilePath.Text = "";
            dataGridView1.AutoGenerateColumns = false;

        }

        private async Task InitData()
        {
            await Excel.Init();

            ExcelDataBase.DumpDish();
            ExcelDataBase.DumpSupplier();
            ExcelDataBase.DumpMaterial();
            //GetProducerList();

        }
        //private void GetProducerList()
        //{
        //    throw new NotImplementedException();
        //}

        private void btn_OpenFileDialog_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            lbl_ReadNewFilePath.Text = openFileDialog1.FileName;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //讀檔
            var file = openFileDialog1.FileName;
            lbl_ReadNewFilePath.Text = file;

            try
            {
                SourceTable = Excel.ExcelToDataTable(file);
                dataGridView1.DataSource = SourceTable;
            }
            catch (Exception)
            {
                lbl_ReadNewFilePath.Text = "";
                MessageBox.Show("檔案開啟失敗，請重新選擇 xls 或 xlsx 檔!");
            }
            
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            //todo:開新檔案or replace
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            //todo:匯出
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
	        dateTimePicker1.Visible = false;
	        textBoxAutoComplete.Visible = false;

			var r = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
			r = dataGridView1.RectangleToScreen(r);

			textBoxAutoComplete.TextChanged += TextBoxAutoCompleteOnTextChanged;
			textBoxAutoComplete.LostFocus += TextBoxAutoCompleteOnLostFocus;

			dateTimePicker1.CloseUp += DateTimePicker_CloseUp;
			dateTimePicker1.TextChanged += DateTimePicker_OnTextChange;

			textBoxAutoComplete.AutoCompleteCustomSource.Clear();

			var columnName = dataGridView1.Columns[e.ColumnIndex].Name;

			if (columnName == CellControlType.菜色編號)
			{
				textBoxAutoComplete.AutoCompleteCustomSource.AddRange(ExcelDataBase.DishDataBase.Select(p => p.Key).ToArray());
				textBoxAutoComplete.Location = RectangleToClient(r).Location;
				textBoxAutoComplete.Size = r.Size;
				textBoxAutoComplete.Text = dataGridView1.CurrentCell.Value?.ToString();
				textBoxAutoComplete.Visible = true;
				textBoxAutoComplete.BringToFront();
			}
			else if (columnName == CellControlType.菜色名稱)
			{
				textBoxAutoComplete.AutoCompleteCustomSource.AddRange(ExcelDataBase.DishDataBase.Select(p => p.Value).ToArray());
				textBoxAutoComplete.Location = RectangleToClient(r).Location;
				textBoxAutoComplete.Size = r.Size;
				textBoxAutoComplete.Text = dataGridView1.CurrentCell.Value?.ToString();
				textBoxAutoComplete.Visible = true;
				textBoxAutoComplete.BringToFront();
			}
			else if (columnName == CellControlType.食材編號)
			{
				textBoxAutoComplete.AutoCompleteCustomSource.AddRange(ExcelDataBase.MaterialDataBase.Select(p => p.Key).ToArray());
				textBoxAutoComplete.Location = RectangleToClient(r).Location;
				textBoxAutoComplete.Size = r.Size;
				textBoxAutoComplete.Text = dataGridView1.CurrentCell.Value?.ToString();
				textBoxAutoComplete.Visible = true;
				textBoxAutoComplete.BringToFront();
			}
			else if (columnName == CellControlType.食材名稱)
			{
				textBoxAutoComplete.AutoCompleteCustomSource.AddRange(ExcelDataBase.MaterialDataBase.Select(p => p.Value).ToArray());
				textBoxAutoComplete.Location = RectangleToClient(r).Location;
				textBoxAutoComplete.Size = r.Size;
				textBoxAutoComplete.Text = dataGridView1.CurrentCell.Value?.ToString();
				textBoxAutoComplete.Visible = true;
				textBoxAutoComplete.BringToFront();
			}
			else if (columnName == CellControlType.重量)
			{
				textBoxAutoComplete.AutoCompleteCustomSource.AddRange(new string[] { "公斤", "台斤", "公克" });
				textBoxAutoComplete.Location = RectangleToClient(r).Location;
				textBoxAutoComplete.Size = r.Size;
				textBoxAutoComplete.Text = dataGridView1.CurrentCell.Value?.ToString();
				textBoxAutoComplete.Visible = true;
				textBoxAutoComplete.BringToFront();
			}
			//else if (columnName == CellControlType.品牌製造商)
			//{
			//	list = new string[] { "公斤", "台斤", "公克" };
			//}
			//else if (columnName == CellControlType.產地製造商所在地)
			//{
			//	list = new string[] { "公斤", "台斤", "公克" };
			//}
			else if (columnName == CellControlType.供應商統編)
			{
				textBoxAutoComplete.AutoCompleteCustomSource.AddRange(ExcelDataBase.SupplierDataBase.Select(p => p.Key).ToArray());
				textBoxAutoComplete.Location = RectangleToClient(r).Location;
				textBoxAutoComplete.Size = r.Size;
				textBoxAutoComplete.Text = dataGridView1.CurrentCell.Value?.ToString();
				textBoxAutoComplete.Visible = true;
				textBoxAutoComplete.BringToFront();
			}
			else if (columnName == CellControlType.供應商名稱)
			{
				textBoxAutoComplete.AutoCompleteCustomSource.AddRange(ExcelDataBase.SupplierDataBase.Select(p => p.Value).ToArray());
				textBoxAutoComplete.Location = RectangleToClient(r).Location;
				textBoxAutoComplete.Size = r.Size;
				textBoxAutoComplete.Text = dataGridView1.CurrentCell.Value?.ToString();
				textBoxAutoComplete.Visible = true;
				textBoxAutoComplete.BringToFront();
			}
			else if (columnName == CellControlType.供餐日期 ||
					 columnName == CellControlType.進貨製造日期 || 
					 columnName == CellControlType.有效期限)
			{
				dateTimePicker1.Location = RectangleToClient(r).Location;
				dateTimePicker1.Size = r.Size;
				dateTimePicker1.Text = dataGridView1.CurrentCell.Value?.ToString();
				dateTimePicker1.Visible = true;
				dateTimePicker1.BringToFront();
			}


			
        }

	    private void TextBoxAutoCompleteOnLostFocus(object sender, EventArgs eventArgs)
	    {
			textBoxAutoComplete.TextChanged -= TextBoxAutoCompleteOnTextChanged;
			textBoxAutoComplete.LostFocus -= TextBoxAutoCompleteOnLostFocus;

			textBoxAutoComplete.Visible = false;
			textBoxAutoComplete.SendToBack();
	    }

	    private void TextBoxAutoCompleteOnTextChanged(object sender, EventArgs eventArgs)
	    {
			dataGridView1.CurrentCell.Value = textBoxAutoComplete.Text;
		}

	    private void DateTimePicker_CloseUp(object sender, EventArgs e)
        {
			dateTimePicker1.CloseUp -= DateTimePicker_CloseUp;
			dateTimePicker1.TextChanged -= DateTimePicker_OnTextChange;

			dateTimePicker1.Visible = false;
			dateTimePicker1.SendToBack();
		}

        private void DateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dateTimePicker1.Text;
        }

        private void ShowMask()
        {
            var viewStartPoint = new Point(0, 0);
            var viewWidth = this.Width;
            var viewHeight = this.Height;

            maskPictureBox.Location = viewStartPoint;
            maskPictureBox.Width = viewWidth;
            maskPictureBox.Height = viewHeight;
            maskPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            maskPictureBox.ImageLocation = Directory.GetCurrentDirectory() + @"\Image\31.gif";
            
            maskPictureBox.Load();
            maskPictureBox.BringToFront();
            maskPictureBox.Visible = true;
        }

        private void CloseMask()
        {
            maskPictureBox.SendToBack();
            maskPictureBox = new PictureBox {Visible = false};
        }


		//private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
		//{
		//	textBoxAutoComplete.TextChanged -= TextBoxAutoCompleteOnTextChanged;
		//	textBoxAutoComplete.LostFocus -= TextBoxAutoCompleteOnLostFocus;

		//	dateTimePicker1.CloseUp -= DateTimePicker_CloseUp;
		//	dateTimePicker1.TextChanged -= DateTimePicker_OnTextChange;

		//	dateTimePicker1.Visible = false;
		//	textBoxAutoComplete.Visible = false;
		//	dateTimePicker1.SendToBack();
		//	textBoxAutoComplete.SendToBack();
		//}
	}
}
