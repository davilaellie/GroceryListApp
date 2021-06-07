using OH.Common.GroceryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Business.GroceryList.Models
{
    public class SecureUser : ExtendedUser
    {
        public string DrivingLicense { get; set; }
        public DateTime DOB { get; set; }
    }
}
