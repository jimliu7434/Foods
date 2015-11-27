using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foods.Class
{
	public class ExcelCellPair
	{
        /// <summary>
        /// 菜色編號/供應商編號/食材編號
        /// </summary>
		public string Key { get; set; }

        /// <summary>
        /// 菜色名稱/供應商名稱/食材名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 食材類別
        /// </summary>
        public string Catagory { get; set; }
	}
}
