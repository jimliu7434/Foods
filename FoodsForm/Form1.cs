using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodsForm
{
    public enum AttachFileType
    {
        Read,
        Create,
    }

    public partial class DailyMenu : Form
    {
        private AttachFileType _nowFileType = AttachFileType.Create;
        private AttachFileType NowFileType
        {
            get { return _nowFileType; }
            set
            {
                if (value != _nowFileType)  //不同於前一狀態
                {
                    lbl_ReadNewFilePath.Text = "";
                    _nowFileType = value;
                }
            }
        } 

        public DailyMenu()
        {
            InitializeComponent();

            InitState();
        }

        private void InitState()
        {
            MaxOpenFilePart();
        }


        private void btn_OpenFileDialog_Click(object sender, EventArgs e)
        {
            switch (NowFileType)
            {
                case AttachFileType.Create:
                    folderBrowserDialog1.ShowDialog();
                    lbl_ReadNewFilePath.Text = folderBrowserDialog1.SelectedPath;
                    break;
                case AttachFileType.Read:
                    openFileDialog1.ShowDialog();
                    lbl_ReadNewFilePath.Text = openFileDialog1.FileName;
                    break;
            }
        }

        private void btn_MaxPnlReadNew_Click(object sender, EventArgs e)
        {
            MaxOpenFilePart();
        }

        private void btn_MinPnlReadNew_Click(object sender, EventArgs e)
        {
            MinOpenFilePart();
        }

        private void MaxOpenFilePart()
        {
            group_ReadNewFile.Visible = true;
            btn_MinPnlReadNew.Visible = true;
        }

        private void MinOpenFilePart()
        {
            group_ReadNewFileMin.Visible = true;
            btn_MaxPnlReadNew.Visible = true;
        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

    }
}
