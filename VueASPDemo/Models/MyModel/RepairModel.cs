using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueASPDemo.Models.MyModel
{
    public class RepairModel
    {
        #region ϵͳ�Զ����ɵı��ֶ�

        public int? RepID { get; set; }

        public int? LetID { get; set; }

        public DateTime? RepDate { get; set; }

        public System.String RepContent { get; set; }

        public int? RepEmp { get; set; }

        public int? RepState { get; set; }

        public System.String RepMark { get; set; }

        public DateTime? RepEndDate { get; set; }

        public int? CreateEmp { get; set; }

        public DateTime? CreateDate { get; set; }

        #endregion ϵͳ�Զ����ɵı��ֶ�
    }
}