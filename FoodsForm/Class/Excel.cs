using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;

namespace FoodsForm.Class
{
    public static class Excel
    {
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
            var chArray = new[] {'(', ')', '{', '}', '[', ']'};
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
