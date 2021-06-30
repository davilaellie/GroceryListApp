using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Common.GroceryList.ViewModels
{
    public class ApiResult
    {
        public bool SuccesfullCall { get; set; }
        public object Content { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}
