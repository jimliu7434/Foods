using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.Formula.Functions;

namespace FoodsForm.Class
{
    public class DataBaseItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Extra { get; set; }

        public DataBaseItem()
        { }
    }


    public static class ExcelDataBase
    {
        

        private static List<DataBaseItem> _dishDataBase;

        public static List<DataBaseItem> DishDataBase
        {
            get
            {
                if (_dishDataBase == null || _dishDataBase.Count == 0)
                {
                    DumpDish();
                }
                return _dishDataBase;
            }
            set { _dishDataBase = value; }
        }

        private static List<DataBaseItem> _supplierDataBase;
        public static List<DataBaseItem> SupplierDataBase
        {
            get
            {
                if (_supplierDataBase == null || _supplierDataBase.Count == 0)
                {
                    DumpSupplier();
                }
                return _supplierDataBase;
            }
            set { _supplierDataBase = value; }
        }

        private static List<DataBaseItem> _materialDataBase;
        public static List<DataBaseItem> MaterialDataBase
        {
            get
            {
                if (_materialDataBase == null || _materialDataBase.Count == 0)
                {
                    DumpMaterial();
                }
                return _materialDataBase;
            }
            set { _materialDataBase = value; }
        }


        public static void DumpDish()
        {
            DishDataBase = Excel.ExcelToList<DataBaseItem>((int)Excel.SheetEnum.菜色編號對照);
        }

        public static void DumpSupplier()
        {
            SupplierDataBase = Excel.ExcelToList<DataBaseItem>((int)Excel.SheetEnum.供應商編號對照);
        }

        public static void DumpMaterial()
        {
            MaterialDataBase = Excel.ExcelToList<DataBaseItem>((int)Excel.SheetEnum.食材編號對照);
        }

        

    }

}
