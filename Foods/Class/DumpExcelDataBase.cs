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

		private static List<ExcelTab> _headerList;

		public static List<ExcelTab> HeaderList
		{
			get
			{
				if (_headerList == null || _headerList.Count == 0)
				{
					DumpHeader();
				}
				return _headerList;
			}
			set { _headerList = value; }
		}

		private static List<Dish> _dishList;
		public static List<Dish> DishList
		{
			get
			{
				if (_dishList == null || _dishList.Count == 0)
				{
					DumpDish();
				}
				return _dishList;
			}
			set { _dishList = value; }
		}

		private static List<Supplier> _supplierList;
		public static List<Supplier> SupplierList
		{
			get
			{
				if (_supplierList == null || _supplierList.Count == 0)
				{
					DumpSupplier();
				}
				return _supplierList;
			}
			set { _supplierList = value; }
		}

		private static List<Material> _materialList;
		public static List<Material> MaterialList
		{
			get
			{
				if (_materialList == null || _materialList.Count == 0)
				{
					DumpMaterial();
				}
				return _materialList;
			}
			set { _materialList = value; }
		}


		private static void DumpDish()
		{
			DishList = DumpContent<Dish>(WorkSheetEnum.菜色編號對照);
		}

		private static void DumpSupplier()
		{
			SupplierList = DumpContent<Supplier>(WorkSheetEnum.供應商編號對照);
		}

		private static void DumpMaterial()
		{
			MaterialList = DumpContent<Material>(WorkSheetEnum.食材編號對照);
		}

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
			HeaderList = new List<ExcelTab>();

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

		            HeaderList = GetExcelTabList(ExcelFullContent.GetWorksheetNames());

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
	            WorkSheetEnum key;
	            if (WorkSheetEnum.TryParse(headerContent, out key))
	            {
		            var newItem = new ExcelTab()
		            {
			            Key = ((int)key).ToString("000"),
			            Content = headerContent,
		            };
		            if (!rtnList.Contains(newItem))
			            rtnList.Add(newItem);
	            }
            }
	        rtnList = rtnList.OrderBy(p => p.Key).ToList();
            return rtnList;
        }

	    private static List<T> DumpContent<T>(WorkSheetEnum type)
	    {
			var rtnList = new List<T>();

			if (string.IsNullOrEmpty(RootSetting.DownloadLocalDir) ||
                string.IsNullOrEmpty(RootSetting.TempFileName))
                return rtnList;

            if (ExcelFullContent == null ||
	            ExcelFullContent == new ExcelQueryFactory())
	        {
                ExcelFullContent = new ExcelQueryFactory(LocalFileName);
            }

			
			var tabIndex = (int)type;
            switch (tabIndex)
	        {
                case (int)WorkSheetEnum.菜色編號對照:
					ExcelFullContent.AddMapping<Dish>(p => p.C_DishKey, "菜色編號");
					ExcelFullContent.AddMapping<Dish>(p => p.C_DishName, "菜色名稱");
					rtnList = ExcelFullContent.Worksheet<T>(type.ToString()).ToList();
					//var workSheet0 = ExcelFullContent.Worksheet(selectedTab.Content);
					//rtnList = ConvertCells(workSheet0, WorkSheetEnum.菜色編號對照);
                    //return rtnList;
					break;
                case (int)WorkSheetEnum.供應商編號對照:
					ExcelFullContent.AddMapping<Supplier>(p => p.C_SupplierKey, "供應商統編");
					ExcelFullContent.AddMapping<Supplier>(p => p.C_SupplierName, "供應商名稱");
					rtnList = ExcelFullContent.Worksheet<T>(type.ToString()).ToList();
					//rtnList = ConvertCells(workSheet1, WorkSheetEnum.供應商編號對照);
					//return rtnList;
					break;
				case (int)WorkSheetEnum.食材編號對照:
					ExcelFullContent.AddMapping<Material>(p => p.C_MaterialKey, "食材編號");
					ExcelFullContent.AddMapping<Material>(p => p.C_MaterialName, "食材名稱");
					ExcelFullContent.AddMapping<Material>(p => p.C_MaterialCatagory, "食材類別");
					rtnList = ExcelFullContent.Worksheet<T>(type.ToString()).ToList();
					//rtnList = ConvertCells(workSheet2, WorkSheetEnum.食材編號對照);
					//return rtnList;
					break;
			}

	        return rtnList;
	    }

     //   private static List<ExcelCellPair> ConvertCells(object workSheet, WorkSheetEnum typeEnum)
     //   {
     //       var rtnList = new List<ExcelCellPair>();
     //       switch (typeEnum)
     //       {
     //           case WorkSheetEnum.菜色編號對照:
					//var sheet0 = workSheet as ExcelQueryable<Dish>;
					////var sheet0 = workSheet as ExcelQueryable<Row>;
					//foreach (var dish in sheet0)
     //               {
     //                   var cell = new ExcelCellPair()
     //                   {
					//		Key = dish.C_DishKey,
					//		Name = dish.C_DishName,
					//		Catagory = "",
					//		//Key = dish["菜色編號"].ToString(),
					//		//Name = dish["菜色名稱"].ToString(),
					//		//Catagory = "",
					//	};
     //                   if (!rtnList.Contains(cell))
     //                   {
     //                       rtnList.Add(cell);
     //                   }
     //               }
     //               break;
     //           case WorkSheetEnum.供應商編號對照:
     //               var sheet1 = workSheet as ExcelQueryable<Supplier>;
     //               foreach (var supplier in sheet1)
     //               {
     //                   var cell = new ExcelCellPair()
     //                   {
     //                       Key = supplier.C_SupplierKey,
     //                       Name = supplier.C_SupplierName,
     //                       Catagory = "",
     //                   };
     //                   if (!rtnList.Contains(cell))
     //                   {
     //                       rtnList.Add(cell);
     //                   }
     //               }
     //               break;
     //           case WorkSheetEnum.食材編號對照:
     //               var sheet2 = workSheet as ExcelQueryable<Material>;
     //               foreach (var material in sheet2)
     //               {
     //                   var cell = new ExcelCellPair()
     //                   {
     //                       Key = material.C_MaterialKey,
     //                       Name = material.C_MaterialName,
     //                       Catagory = material.C_MaterialCatagory,
     //                   };
     //                   if (!rtnList.Contains(cell))
     //                   {
     //                       rtnList.Add(cell);
     //                   }
     //               }
     //               break;
     //       }

     //       return rtnList;
     //   }

    }
}
