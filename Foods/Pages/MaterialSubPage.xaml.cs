using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Foods.PageViewModels;

namespace Foods.Pages
{
	/// <summary>
	/// MaterialSubPage.xaml 的互動邏輯
	/// </summary>
	public partial class MaterialSubPage : PageBase
	{
		MaterialSubPageViewModel ViewModel;
		public MaterialSubPage()
		{
			InitializeComponent();
			this.DataContextChanged += MaterialSubPage_DataContextChanged; ;
		}

		private void MaterialSubPage_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			ViewModel = DataContext as MaterialSubPageViewModel;
			if (ViewModel != null)
			{
				ViewModel.Parameter = this.Tag;
			}
		}
	}
}
