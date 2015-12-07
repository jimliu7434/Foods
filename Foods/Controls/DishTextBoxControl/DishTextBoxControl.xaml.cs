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
using Foods.ControlViewModels;


namespace Foods.Controls
{
    /// <summary>
    /// DishTextBoxControl.xaml 的互動邏輯
    /// </summary>
    public partial class DishTextBoxControl : BaseUserControl
    {
	    public DishTextBoxControlViewModel ViewModel;

        public DishTextBoxControl()
        {
            InitializeComponent();
			this.DataContextChanged += DishTextBoxControl_DataContextChanged; ;
		}

		private void DishTextBoxControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			ViewModel = DataContext as DishTextBoxControlViewModel;

		}


	}
}
