using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foods.Class;
using Foods.Enum;

namespace Foods.PageViewModels
{
	public class DishSubPageViewModel : PageViewModelBase
	{
		public DishSubPageViewModel()
		{
			var list0 = DumpExcelDataBase.DishList;
			var list1 = DumpExcelDataBase.SupplierList;
			var list2 = DumpExcelDataBase.MaterialList;

		}
	}
}
