using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Foods.Class;
using Foods.Enum;
using Foods.PageViewModels;

namespace Foods.ControlViewModels
{
    public class DishTextBoxControlViewModel : BaseUserControlViewModel
    {
        private string _text = "";

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                this.OnPropertyChanged("Text");
            }
        }

        private IEnumerable<string> _items;

        public IEnumerable<string> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                this.OnPropertyChanged("Items");
            }
        }


        public void TextTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
	        var txtbox = sender as TextBox;
			if(txtbox == null) return;

	        Text = txtbox.Text;

            var list =
                DumpExcelDataBase.DishList.Where(p => p.C_DishKey.Contains(Text) || p.C_DishName.Contains(Text)).ToList();

            if (list.Count > 0)
            {
                Items = GetDishNames(list).ToList();
            }
        }

        private IEnumerable<string> GetDishNames(IEnumerable<Dish> list)
        {
	        return list.Select(p => p.C_DishName);
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
