using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Foods.Class;
using Foods.Enum;

namespace Foods.PageViewModels
{
	public class DishSubPageViewModel : PageViewModelBase
	{
	    private string _testText;

        public string TestText
	    {
            get { return _testText; }
            set
            {
                _testText = value;
                this.OnPropertyChanged("TestText");
            }
	    }

        private List<AutoCompleteItem> _testItems;

        public List<AutoCompleteItem> TestItems
        {
            get { return _testItems; }
            set
            {
                _testItems = value;
                this.OnPropertyChanged("TestItems");
            }
        }

        public DishSubPageViewModel()
		{
			//var list0 = DumpExcelDataBase.DishList;
			//var list1 = DumpExcelDataBase.SupplierList;
			//var list2 = DumpExcelDataBase.MaterialList;



		}

        public void TextTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var list =
                DumpExcelDataBase.DishList.Where(p => p.C_DishKey.Contains(TestText) || p.C_DishName.Contains(TestText)).ToList();

            if (list.Count > 0)
            {
                TestItems = ConvertDishs2AutoCompleteItems(list).ToList();
            }
        }

        private IEnumerable<AutoCompleteItem> ConvertDishs2AutoCompleteItems(List<Dish> list)
        {
            return list.Select(Dish2AutoCompleteItem);
        }

	    private AutoCompleteItem Dish2AutoCompleteItem(Dish dish)
	    {
	        return new AutoCompleteItem()
	        {
	            HeaderKey = WorkSheetEnum.菜色編號對照,
                ContentKey = dish.C_DishKey,
                Value = dish.C_DishName,
	        };
	    }
    }
}
