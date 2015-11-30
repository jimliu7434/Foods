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
using System.Windows.Media;
using Foods.Class;
using Foods.Enum;
using Foods.Pages;

namespace Foods.PageViewModels
{
    public class MainPageViewModel :PageViewModelBase
    {
        public string DishGridVisibility => "Visible";

        private bool _txtDownloadingIsVisible = true;
	    public bool TxtDownloadingIsVisibile 
	    {
			get { return _txtDownloadingIsVisible; }
		    set
		    {
			    _txtDownloadingIsVisible = value;
			    this.OnPropertyChanged("TxtDownloadingIsVisibile");
				this.OnPropertyChanged("TxtDownloadingVisibility");
			}
		    
	    }

		public string TxtDownloadingVisibility => TxtDownloadingIsVisibile ? "Visible" : "Collapsed";

	    private ExcelTab _selectedHeader;

	    public ExcelTab SelectedHeader
	    {
			get { return _selectedHeader; }
		    set
		    {
			    _selectedHeader = value;
			    this.OnPropertyChanged("SelectedHeader");
		    }
	    }

	    private List<ExcelTab> _headerList;
        public List<ExcelTab> HeaderList
	    {
			get { return _headerList; }
	        set
	        {
		        _headerList = value;
		        this.OnPropertyChanged("HeaderList");
	        }
		}

	  //  private List<ExcelCellPair> _contentList;

	  //  public List<ExcelCellPair> ContentList
	  //  {
			//get { return _contentList; }
		 //   set
		 //   {
			//    _contentList = value;
			//    this.OnPropertyChanged("ContentList");
		 //   }
	  //  }

	    private Page _frameContent;

	    public Page FrameContent
	    {
		    get { return _frameContent; }
		    set
		    {
			    _frameContent = value;
			    this.OnPropertyChanged("FrameContent");
		    }
	    }

		private AppSetting RootSetting => AppSettingManager.RootSetting;

        public MainPageViewModel()
        {
            var obj = DumpExcelDataBase.ExcelFullContent;
            DumpExcelDataBase.ExcelFileDownloadCompleted += DumpExcelDataBase_ExcelFileDownloadCompleted;
	        TxtDownloadingIsVisibile = true;
        }

        private void DumpExcelDataBase_ExcelFileDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
	        if (!e.Cancelled)
	        {
		        Init();
		        TxtDownloadingIsVisibile = false;
			}
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

            //DumpExcelDataBase.DumpHeader();

            if (DumpExcelDataBase.HeaderList != null &&
                DumpExcelDataBase.HeaderList.Count > 0)
            {


                HeaderList = DumpExcelDataBase.HeaderList;
            }
            else
            {
                HeaderList = new List<ExcelTab>();
            }

	        
        }

        public void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
	        var item = e.AddedItems[0] as ExcelTab;
			if(item == null) return;
	        SelectedHeader = item;

	        WorkSheetEnum en;
	        if (WorkSheetEnum.TryParse(SelectedHeader.Content, out en))
	        {
		        switch (en)
		        {
				    case WorkSheetEnum.菜色編號對照:
						FrameContent = new DishSubPage();
						break;
					case WorkSheetEnum.供應商編號對照:
						FrameContent = new SupplierSubPage();
						break;    
					case WorkSheetEnum.食材編號對照:
						FrameContent = new MaterialSubPage();
						break;

		        }
	        }
        }
    }
}
