using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foods.Class;
using Foods.ViewModel;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Controls;

namespace Foods
{
	public class MainWindowViewModel : ViewModelBase
	{
		private AppSetting AppSettingRoot = new AppSetting();
		private const string AppSettingLoc = "\\Setting\\AppSetting.json";
		private const string AppSettingRootKey = "Root";


		private ExcelTab _selectedHeader;
		public ExcelTab SelectedHeader
		{
			get { return _selectedHeader; }
			set { _selectedHeader = value; }
		}

		public ObservableCollection<ExcelTab> HeaderList { get; set; }
		public ObservableCollection<ExcelCellPair> ContentList { get; set; }

		public async void Init()
		{
			// 讀取設定檔
			await PrepareAppSetting();

			// 下載檔案並組合成tab清單
			await PrepareHeaderList();
		}

		private async Task PrepareAppSetting()
		{
			var AppSettings = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<AppSetting>>(AppSettingLoc));
			AppSettingRoot = AppSettings.FirstOrDefault(p => p.Key == AppSettingRootKey);
		}

		private async Task PrepareHeaderList()
		{
			using (WebClient client = new WebClient())
			{
				await client.DownloadFileTaskAsync(new Uri(AppSettingRoot.DownloadUrl,UriKind.Absolute), AppSettingRoot.DownloadLocalDir);

				var dumpExcel = new DumpExcelDataBase(AppSettingRoot.DownloadLocalDir);
				if(dumpExcel.Dump())
				{
					HeaderList = new ObservableCollection<ExcelTab>(dumpExcel.TabList);
				}
			}
		}

		public void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//Todo: Prepare Second List
		}
	}
}
