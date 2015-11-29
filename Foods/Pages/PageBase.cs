using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Foods.PageViewModels;

namespace Foods.Pages
{
    public class PageBase: Page
    {
        private PageViewModelBase _viewModel;

        public PageBase()
        {

            this.DataContextChanged += MainPage_DataContextChanged;
            //this.NavigationCacheMode = NavigationCacheMode.Required;

            // 依名稱找對應的ViewModel
            SetDataContext();
        }

        private void MainPage_DataContextChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            _viewModel = DataContext as PageViewModelBase;
        }

        /// <summary>
        /// 依名稱找對應的ViewModel
        /// </summary>
        public virtual void SetDataContext()
        {
            var viewType = this.GetType();

            var viewModelName = viewType.AssemblyQualifiedName.Replace("Page", "PageViewModel");
            var viewModelType = Type.GetType(viewModelName);

            DataContext = Activator.CreateInstance(viewModelType);
        }
    }
}
