using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foods.Enum;

namespace Foods.Class
{
    public class AutoCompleteItem
    {
        public WorkSheetEnum HeaderKey { get; set; }
        public string ContentKey { get; set; }
        //public int IdentifyKey { get; set; }
        public string Value { get; set; }
    }
}
