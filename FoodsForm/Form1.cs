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

        public DataTable SourceTable { get; set; } = new DataTable();

        public bool IsFileImporting { get; set; } = false;

        private bool IsDefault { get; set; } = true;
        private int GridViewDefaultHeight { get; set; }
        private int GridViewDefaultWidth { get; set; }

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
            openFileDialog1.Filter = "Excel檔|*.xls";
            saveFileDialog1.Filter = "Excel檔|*.xls";
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "每日菜單";
            openFileDialog1.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Save");
            saveFileDialog1.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Save");
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
                IsFileImporting = true;

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
            //開新檔案or replace
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var dialog = sender as SaveFileDialog;
            if (dialog == null) return;

            //if (File.Exists(dialog.FileName))
            //{
            //    var result = MessageBox.Show(this, "檔案已存在，確定覆蓋?", "訊息", MessageBoxButtons.YesNo);
            //    if (result == DialogResult.Yes)
            //    {
            //        File.Delete(dialog.FileName);
            //    }
            //    else
            //    {
            //        dialog.FileName = "";
            //        return;
            //    }
            //}

            var msg = ExportExcel(dialog.FileName);

            if (msg.StartsWith("-1:"))
            {
                MessageBox.Show("匯出失敗:" + msg.Substring(3));
            }
            else
            {
                MessageBox.Show("匯出成功！");
            }

        }

        private string ExportExcel(string fileName)
        {
            return Excel.DataGridViewToExcel(dataGridView1, fileName);
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
            maskPictureBox = new PictureBox { Visible = false };
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!IsFileImporting)
            {
                var gridView = sender as DataGridView;
                if (gridView == null) return;

               var columnName = dataGridView1.Columns[e.ColumnIndex].Name;
                var currentCell = gridView.CurrentCell;
                if (columnName == "" || currentCell == null) return;

                var key = currentCell.Value?.ToString();
                if (key == "") return;

                if (columnName == CellControlType.菜色編號)
                {
                    var value = ExcelDataBase.DishDataBase.FirstOrDefault(p => p.Key == key);
                    if (value == null) return;

                    var cell = GetCell(gridView, e.ColumnIndex + 1, e.RowIndex);
                    if (cell == null) return;

                    cell.Value = value.Value;

                }
                else if (columnName == CellControlType.菜色名稱)
                {
                    var value = ExcelDataBase.DishDataBase.FirstOrDefault(p => p.Value == key);
                    if (value == null) return;

                    var cell = GetCell(gridView, e.ColumnIndex - 1, e.RowIndex);
                    if (cell == null) return;

                    cell.Value = value.Key;
                }
                else if (columnName == CellControlType.食材編號)
                {
                    var value = ExcelDataBase.MaterialDataBase.FirstOrDefault(p => p.Key == key);
                    if (value == null) return;

                    var cell = GetCell(gridView, e.ColumnIndex + 1, e.RowIndex);
                    if (cell == null) return;

                    cell.Value = value.Value;
                }
                else if (columnName == CellControlType.食材名稱)
                {
                    var value = ExcelDataBase.MaterialDataBase.FirstOrDefault(p => p.Value == key);
                    if (value == null) return;

                    var cell = GetCell(gridView, e.ColumnIndex - 1, e.RowIndex);
                    if (cell == null) return;

                    cell.Value = value.Key;
                }
                else if (columnName == CellControlType.供應商統編)
                {
                    var value = ExcelDataBase.SupplierDataBase.FirstOrDefault(p => p.Key == key);
                    if (value == null) return;

                    var cell = GetCell(gridView, e.ColumnIndex + 1, e.RowIndex);
                    if (cell == null) return;

                    cell.Value = value.Value;
                }
                else if (columnName == CellControlType.供應商名稱)
                {
                    var value = ExcelDataBase.SupplierDataBase.FirstOrDefault(p => p.Value == key);
                    if (value == null) return;

                    var cell = GetCell(gridView, e.ColumnIndex - 1, e.RowIndex);
                    if (cell == null) return;

                    cell.Value = value.Key;
                }
            }
        }

        private static DataGridViewCell GetCell(DataGridView gridView, int columnIndex, int rowIndex)
        {
            if (gridView.ColumnCount <= columnIndex ||
                gridView.RowCount <= rowIndex)
                return null;

            return gridView.Rows[rowIndex].Cells[columnIndex];
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(IsFileImporting )
                IsFileImporting = false;

            if (IsDefault)
            {
                var gridView = sender as DataGridView;
                if (gridView == null) return;

                GridViewDefaultHeight = gridView.Height;
                GridViewDefaultWidth = gridView.Width;
                IsDefault = false;
            }
            else
            {
                
            }

        }

        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            
        }
    }
}
