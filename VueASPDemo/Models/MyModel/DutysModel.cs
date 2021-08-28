using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueASPDemo.Models.MyModel
{
    public class DutysModel
    {
        public int DutyID { get; set; }
        public string DutyName { get; set; }
        public string DutyMark { get; set; }
        public Nullable<bool> DutyState { get; set; }
    }
}