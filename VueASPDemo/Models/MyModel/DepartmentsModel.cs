using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueASPDemo.Models.MyModel
{
    public class DepartmentsModel
    {
        public int DepID { get; set; }
        public string DepName { get; set; }
        public Nullable<bool> DepState { get; set; }
        public string DepMark { get; set; }
    }
}