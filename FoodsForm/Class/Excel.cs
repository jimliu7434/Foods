using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;

namespace FoodsForm.Class
{
    public static class Excel
    {
        public enum SheetEnum
        {
            菜色編號對照 = 0,
            供應商編號對照 = 1,
            食材編號對照 = 2,
        }
        public delegate void FileDownloadCompletedHandler(object sender, AsyncCompletedEventArgs e);
        public static event FileDownloadCompletedHandler ExcelFileDownloadCompleted;

        public delegate void ExcelParsingCompletedHandler();
        public static event ExcelParsingCompletedHandler ExcelParsingCompleted;

        private static readonly string ApplicationPath = Directory.GetCurrentDirectory();
        public static string LocalSavePath = Path.Combine(ApplicationPath, "TempFiles\\");
        public static string FileName = "main_base.xls";
        public static string LocalFullFilePath = Path.Combine(LocalSavePath, FileName);
        public static string DownloadUrl = "http://foodtracertaipei.health.gov.tw/caterer/export_lunch_daily_base.aspx";

        private static HSSFWorkbook _workBook;

        public static HSSFWorkbook WorkBook
        {
            get
            {
                if (_workBook == null)
                {
                    Init();
                }
                return _workBook;
            }
            set { _workBook = value; }
        }

        public static async Task Init()
        {
            await DownloadFile();
            InitWorkBook();
            if (ExcelParsingCompleted != null)
            {
                ExcelParsingCompleted();
            }
        }

        private static async Task DownloadFile()
        {
            using (var client = new WebClient())
            {
                //目錄不存在 => 建立
                if (!Directory.Exists(LocalSavePath))
                    Directory.CreateDirectory(LocalSavePath);

                // 檔案已存在 => 刪除舊的
                if (File.Exists(LocalFullFilePath))
                    File.Delete(LocalFullFilePath);

                try
                {
                    client.DownloadFileCompleted += (sender, args) =>
                    {
                        ExcelFileDownloadCompleted?.Invoke(sender, args);
                    };
                    await client.DownloadFileTaskAsync(new Uri(DownloadUrl, UriKind.Absolute), LocalFullFilePath);
                }
                //catch (WebException webException)
                //{
                //    throw webException;
                //}
                //catch (InvalidOperationException opException)
                //{
                //    MessageBox.Show("Operation:" + opException.Message);
                //}
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private static void InitWorkBook()
        {
            try
            {
                FileStream fs = new FileStream(LocalFullFilePath, FileMode.Open);
                HSSFWorkbook wb = new HSSFWorkbook(fs);
                if (wb != null) WorkBook = wb;
                fs.Close();
            }
            catch (Exception)
            {
                throw new FileNotFoundException("DataBaseFile Not Found.");
            }
        }

        public static List<TDbitemT> ExcelToList<TDbitemT>(int sheetIndex) 
                                                    where TDbitemT : DataBaseItem, new()
        {
            if (WorkBook == null) return null;

            var hasExtra = false;
            var rtnList = new List<TDbitemT>();

            var sheetCount = WorkBook.NumberOfSheets;
            if (sheetIndex >= sheetCount) return null;

            var sheet = WorkBook.GetSheetAt(sheetIndex);

            //第一列為中文欄位名不取
            var headerRow = sheet.GetRow(sheet.FirstRowNum + 1);
            int cellCount = headerRow.LastCellNum;
            if (cellCount == 3)
                hasExtra = true;


            //略過第零列(標題列)，一直處理至最後一列
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row == null) continue;
                if (row.GetCell(row.FirstCellNum).StringCellValue == "") continue;

                var dataBaseItem = new TDbitemT();
                if (hasExtra)
                {
                    var cell0 = row.GetCell(row.FirstCellNum);
                    var cell1 = row.GetCell(row.FirstCellNum + 1);
                    var cell2 = row.GetCell(row.FirstCellNum + 2);

                    if (cell0 == null ||
                        cell1 == null ||
                        cell2 == null)
                        continue;

                    dataBaseItem = new TDbitemT()
                    {
                        Key = cell0.StringCellValue,
                        Value = cell1.StringCellValue,
                        Extra = cell2.StringCellValue,
                    };
                }
                else
                {
                    var cell0 = row.GetCell(row.FirstCellNum);
                    var cell1 = row.GetCell(row.FirstCellNum + 1);

                    if (cell0 == null ||
                        cell1 == null)
                        continue;

                    dataBaseItem = new TDbitemT()
                    {
                        Key = cell0.StringCellValue,
                        Value = cell1.StringCellValue,
                        Extra = "",
                    };
                }

                if (!rtnList.Contains(dataBaseItem))
                    rtnList.Add(dataBaseItem);
            }
            return rtnList;
        }

        public static DataTable ExcelToDataTable(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                HSSFWorkbook wb = new HSSFWorkbook(fs);

                var sheet = wb.GetSheetAt(0);
                DataTable table = new DataTable();
                //由第一列取標題做為欄位名稱
                var headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;
                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    //以欄位文字為名新增欄位
                    var columnName = headerRow.GetCell(i).StringCellValue;
                    columnName = RemoveSymbol(columnName);

                    table.Columns.Add(
                        new DataColumn(columnName));
                }

                //略過第零列(標題列)，一直處理至最後一列
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    var row = sheet.GetRow(i);
                    if (row == null) continue;
                    var dataRow = table.NewRow();
                    //依先前取得的欄位數逐一設定欄位內容
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                        {
                            dataRow[j] = ConvertCellType(row.GetCell(j));
                        }
                    }
                    table.Rows.Add(dataRow);
                }
                return table;
            }
        }

        private static object ConvertCellType(ICell cell)
        {
            object value = null;

            //如要針對不同型別做個別處理，可善用.CellType判斷型別
            //再用.StringCellValue, .DateCellValue, .NumericCellValue...取值
            switch (cell.CellType)
            {
                case CellType.Numeric:
                    // Date comes here
                    if (DateUtil.IsCellDateFormatted(cell))
                    {
                        value = cell.DateCellValue.ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        // Numeric type
                        value = cell.NumericCellValue;
                    }
                    break;
                case CellType.Boolean:
                    // Boolean type
                    value = cell.BooleanCellValue;
                    break;
                case CellType.Formula:
                    value = cell.CellFormula;
                    break;
                default:
                    // String type
                    value = cell.StringCellValue;
                    break;
            }

            return value;
        }

        private static string RemoveSymbol(string columnName)
        {
            var chArray = new[] { '(', ')', '{', '}', '[', ']' };
            var rtnString = "";

            foreach (var ch in columnName.ToCharArray())
            {
                if (!chArray.Contains(ch))
                {
                    rtnString += ch.ToString();
                }
            }

            return rtnString;
        }

        public static HSSFWorkbook DataTableToExcel(DataTable dt)
        {
            throw new NotImplementedException();
        }

    }
}
