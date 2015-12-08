using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FoodsForm.Class;

namespace FoodsForm
{

    public partial class DailyMenu : Form
    {

        public IEnumerable<Dish> DishList { get; set; }
        public IEnumerable<Supplier> SupplierList { get; set; }
        public IEnumerable<Material> MaterialList { get; set; }
        public IEnumerable<string> ProducerList { get; set; }

        public DataTable SourceTable { get; set; }= new DataTable();

        public DailyMenu()
        {
            InitializeComponent();

            InitState();
        }

        private void InitState()
        {
            lbl_ReadNewFilePath.Text = "";
            //GetDishList();
            //GetSupplierList();
            //GetMaterialList();
            //GetProducerList();
        }

        private void GetDishList()
        {
            throw new NotImplementedException();
        }

        private void GetSupplierList()
        {
            throw new NotImplementedException();
        }

        private void GetMaterialList()
        {
            throw new NotImplementedException();
        }

        private void GetProducerList()
        {
            throw new NotImplementedException();
        }

        private void btn_OpenFileDialog_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            lbl_ReadNewFilePath.Text = openFileDialog1.FileName;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //todo:讀檔
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
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "date")
            {
                var r = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                r = this.dataGridView1.RectangleToScreen(r);
                this.dateTimePicker1.Location = this.RectangleToClient(r).Location;
                this.dateTimePicker1.Size = r.Size;
                this.dateTimePicker1.Text = this.dataGridView1.CurrentCell.Value.ToString();

                dateTimePicker1.CloseUp += DateTimePicker_CloseUp;
                dateTimePicker1.TextChanged += DateTimePicker_OnTextChange;

                dateTimePicker1.Visible = true;
            }
            else
            {
                dateTimePicker1.Visible = false;
            }
        }

        private void DateTimePicker_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = false;
        }

        private void DateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dateTimePicker1.Text;
        }
    }
}
