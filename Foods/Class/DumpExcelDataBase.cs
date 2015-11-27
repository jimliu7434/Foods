using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using System.Reflection;

namespace Foods.Class
{
	public class DumpExcelDataBase
	{
		public string LocalFilePath { get; set; }
		public List<ExcelTab> TabList { get; set; }

		public DumpExcelDataBase()
		{
			LocalFilePath = "";
			TabList = new List<ExcelTab>();
		}

		public DumpExcelDataBase(string localFilePath)
		{
			LocalFilePath = localFilePath;
			TabList = new List<ExcelTab>();
		}

		public bool Dump()
		{
			if (string.IsNullOrEmpty(LocalFilePath)) return false;

			string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			string filePath = Path.Combine(directory, LocalFilePath);

			if (!File.Exists(filePath))
			{
				//Todo: Read EXCEL

				return true;
			}

			return false;

		}
	}
}
