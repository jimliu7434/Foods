using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Foods.Class;

namespace Foods.PageViewModels
{
    public class MainPageViewModel :PageViewModelBase
    {

        public ExcelTab SelectedHeader { get; set; }

        public ObservableCollection<ExcelTab> HeaderList { get; set; }
        public ObservableCollection<ExcelCellPair> ContentList { get; set; }

        private AppSetting RootSetting => AppSettingManager.RootSetting;

        public MainPageViewModel()
        {
            var obj = DumpExcelDataBase.ExcelFullContent;
            DumpExcelDataBase.ExcelFileDownloadCompleted += DumpExcelDataBase_ExcelFileDownloadCompleted;

        }

        private void DumpExcelDataBase_ExcelFileDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if(!e.Cancelled)
                Init();
        }

        private void Init()
        {
            PrepareHeaderList();

            SelectDefaultTab();
        }

        private void SelectDefaultTab()
        {
            SelectedHeader = HeaderList.FirstOrDefault();
        }



        private void PrepareHeaderList()
        {
            if(HeaderList != null && HeaderList.Count > 0) return;

            DumpExcelDataBase.DumpHeader();

            if (DumpExcelDataBase.TabList != null &&
                DumpExcelDataBase.TabList.Count > 0)
            {


                HeaderList = new ObservableCollection<ExcelTab>(DumpExcelDataBase.TabList);
            }
            else
            {
                HeaderList = new ObservableCollection<ExcelTab>();
            }
            this.OnPropertyChanged("HeaderList");
        }

        public void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Prepare Second List
            var list = new List<ExcelCellPair>();

            if (DumpExcelDataBase.DumpContent(SelectedHeader, out list))
            {
                ContentList = new ObservableCollection<ExcelCellPair>(list);
                this.OnPropertyChanged("ContentList");
            }

        }
    }
}
