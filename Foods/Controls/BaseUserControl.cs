using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Foods.ControlViewModels;
using Foods.PageViewModels;

namespace Foods.Controls
{
	public class BaseUserControl : UserControl
	{
		private BaseUserControlViewModel _viewModel;

		public BaseUserControl()
		{

			this.DataContextChanged += BaseUserControl_DataContextChanged;
			//this.NavigationCacheMode = NavigationCacheMode.Required;

			// 依名稱找對應的ViewModel
			SetDataContext();
		}

		private void BaseUserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs args)
		{
			_viewModel = DataContext as BaseUserControlViewModel;
		}

		/// <summary>
		/// 依名稱找對應的ViewModel
		/// </summary>
		public virtual void SetDataContext()
		{
			var viewType = this.GetType();

			var viewModelName = viewType.AssemblyQualifiedName.Replace("Control", "ControlViewModel");
			var viewModelType = Type.GetType(viewModelName);

			DataContext = Activator.CreateInstance(viewModelType);
		}

	}
}
