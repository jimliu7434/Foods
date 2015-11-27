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
	/// MainPage.xaml 的互動邏輯
	/// </summary>
	public partial class MainPage : PageBase
	{
        MainPageViewModel ViewModel;
        public MainPage()
		{
			InitializeComponent();
            this.DataContextChanged += MainPage_DataContextChanged; ;
        }

        private void MainPage_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ViewModel = DataContext as MainPageViewModel;
        }

    }
}
