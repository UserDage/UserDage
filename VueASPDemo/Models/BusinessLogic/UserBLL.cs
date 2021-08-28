using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueASPDemo.Models.EFModel;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Models.BusinessLogic
{
    public class UserBLL
    {
        public static EmpModel Login(string name, string pwd)
        {
            using (LetDBEntities letDB = new LetDBEntities())
            {
                pwd = MD5Service.GetMD5CodeToString(pwd);
                var data = letDB.Employs.Where(n => n.LoginName == name && n.LoginPWD == pwd).Select(n => new EmpModel()
                {
                    EmpID = n.EmpID,
                    EmpName = n.EmpName,
                    EmpSex = n.EmpSex,
                    EmpAdd = n.EmpAdd,
                    EmpMark = n.EmpMark,
                    EmpState = n.EmpState,
                    EmpTel = n.EmpTel,
                    DepID = n.DepID,
                    DutyID = n.DutyID,
                    LoginName = n.LoginName,
                    LoginPWD = n.LoginPWD
                }).FirstOrDefault();
                return data;
            }
        }
    }
}