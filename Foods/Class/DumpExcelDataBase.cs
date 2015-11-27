using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using System.Reflection;
using LinqToExcel;
using Remotion.Data.Linq.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Foods.Enum;
using LinqToExcel.Query;
using System.Net;

namespace Foods.Class
{
	public static class DumpExcelDataBase
	{
	    public delegate void FileDownloadCompletedHandler(object sender, AsyncCompletedEventArgs e);

	    public static event FileDownloadCompletedHandler ExcelFileDownloadCompleted;

        private static readonly AppSetting RootSetting = AppSettingManager.RootSetting;

	    public static string LocalSavePath = Path.Combine(PathUtility.GetRootPath(), RootSetting.DownloadLocalDir);
        public static string LocalFileName = Path.Combine(LocalSavePath, RootSetting.TempFileName);
        public static List<ExcelTab> TabList { get; set; }

	    private static ExcelQueryFactory _excelFullContent;
        public static ExcelQueryFactory ExcelFullContent
        {
            get
            {
                if (_excelFullContent == null)
                {
                    Init();
                }

                return _excelFullContent;
            }
            set { _excelFullContent = value; }
        }


		public static async Task Init()
		{
			TabList = new List<ExcelTab>();

            using (var client = new WebClient())
            {
                if (!Directory.Exists(LocalSavePath))
                    Directory.CreateDirectory(LocalSavePath);
                if (File.Exists(LocalFileName))
                    File.Delete(LocalFileName);

                try
                {
                    client.DownloadFileCompleted += (sender, args) =>
                    {
                        if (ExcelFileDownloadCompleted != null)
                        {
                            ExcelFileDownloadCompleted(sender, args);
                        }
                    };
                    await client.DownloadFileTaskAsync(new Uri(RootSetting.DownloadUrl, UriKind.Absolute), LocalFileName);
                    

                }
                catch (WebException webException)
                {
                    MessageBox.Show("Web:" + webException.Message);
                }
                catch (InvalidOperationException opException)
                {
                    MessageBox.Show("Operation:" + opException.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Other:" + ex.Message);
                }
            }
        }

		public static bool DumpHeader()
		{
			if (string.IsNullOrEmpty(RootSetting.DownloadLocalDir) ||
                string.IsNullOrEmpty(RootSetting.TempFileName)) return false;

		    try
		    {
		        if (File.Exists(LocalFileName))
		        {
		            // Read EXCEL
		            ExcelFullContent = new ExcelQueryFactory(LocalFileName);

		            TabList = GetExcelTabList(ExcelFullContent.GetWorksheetNames());

		            return true;
		        }
		    }
		    catch (Exception ex)
		    {
		        MessageBox.Show("ParsingExcel:" + ex.Message);
		    }

	        return false;


		}

        private static List<ExcelTab> GetExcelTabList(IEnumerable<string> enumerable)
        {
            var rtnList = new List<ExcelTab>();
            foreach (var headerContent in enumerable)
            {
                var newItem = new ExcelTab()
                {
                    Key = enumerable.ToList().IndexOf(headerContent).ToString("000"),
                    Content = headerContent,
                };
                if(!rtnList.Contains(newItem)) 
                    rtnList.Add(newItem);
            }

            return rtnList;
        }

	    public static bool DumpContent(ExcelTab selectedTab, out List<ExcelCellPair> rtnList)
	    {
            rtnList = new List<ExcelCellPair>();

            if (string.IsNullOrEmpty(RootSetting.DownloadLocalDir) ||
                string.IsNullOrEmpty(RootSetting.TempFileName))
                return false;

            if (ExcelFullContent == null ||
	            ExcelFullContent == new ExcelQueryFactory())
	        {
                ExcelFullContent = new ExcelQueryFactory(LocalFileName);
            }

	        var tabIndex = int.Parse(selectedTab.Key);
            switch (tabIndex)
	        {
                case (int)WorkSheetEnum.菜色編號對照:
                    var workSheet0 = ExcelFullContent.Worksheet<菜色>(selectedTab.Content);
                    rtnList = ConvertCells(workSheet0, WorkSheetEnum.菜色編號對照);
                    return true;
                case (int)WorkSheetEnum.供應商編號對照:
                    var workSheet1 = ExcelFullContent.Worksheet<供應商>(selectedTab.Content);
                    rtnList = ConvertCells(workSheet1, WorkSheetEnum.供應商編號對照);
                    return true;
                case (int)WorkSheetEnum.食材編號對照:
                    var workSheet2 = ExcelFullContent.Worksheet<食材>(selectedTab.Content);
                    rtnList = ConvertCells(workSheet2, WorkSheetEnum.食材編號對照);
                    return true;
            }

	        return false;
	    }

        private static List<ExcelCellPair> ConvertCells(object workSheet, WorkSheetEnum typeEnum)
        {
            var rtnList = new List<ExcelCellPair>();
            switch (typeEnum)
            {
                case WorkSheetEnum.菜色編號對照:
                    var sheet0 = workSheet as ExcelQueryable<菜色>;
                    foreach (var 菜色 in sheet0)
                    {
                        var cell = new ExcelCellPair()
                        {
                            Key = 菜色.菜色編號,
                            Name = 菜色.菜色名稱,
                            Catagory = "",
                        };
                        if (!rtnList.Contains(cell))
                        {
                            rtnList.Add(cell);
                        }
                    }
                    break;
                case WorkSheetEnum.供應商編號對照:
                    var sheet1 = workSheet as ExcelQueryable<供應商>;
                    foreach (var 供應商 in sheet1)
                    {
                        var cell = new ExcelCellPair()
                        {
                            Key = 供應商.供應商統編,
                            Name = 供應商.供應商名稱,
                            Catagory = "",
                        };
                        if (!rtnList.Contains(cell))
                        {
                            rtnList.Add(cell);
                        }
                    }
                    break;
                case WorkSheetEnum.食材編號對照:
                    var sheet2 = workSheet as ExcelQueryable<食材>;
                    foreach (var 食材 in sheet2)
                    {
                        var cell = new ExcelCellPair()
                        {
                            Key = 食材.食材編號,
                            Name = 食材.食材名稱,
                            Catagory = 食材.食材類別,
                        };
                        if (!rtnList.Contains(cell))
                        {
                            rtnList.Add(cell);
                        }
                    }
                    break;
            }

            return rtnList;
        }

    }
}
