using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueASPDemo.Models.MyModel
{
    public class EmpModel
    {
        public int EmpID { get; set; }
        public Nullable<int> DepID { get; set; }
        public string DutyName { get; set; }
        public string DepName { get; set; }
        public Nullable<int> DutyID { get; set; }
        public string LoginName { get; set; }
        public string LoginPWD { get; set; }
        public string EmpName { get; set; }
        public string EmpSex { get; set; }
        public string EmpTel { get; set; }
        public string EmpAdd { get; set; }
        public Nullable<int> EmpState { get; set; }
        public string EmpMark { get; set; }
    }
}