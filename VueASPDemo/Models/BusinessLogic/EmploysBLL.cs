using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueASPDemo.Models.EFModel;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Models.BusinessLogic
{
    public class EmploysBLL
    {
        public static List<EmpModel> EmpSearchALL(EmpModel emp, int page, int size, out int count)
        {
            using (LetDBEntities letDB = new LetDBEntities())
            {
                var EmpData = letDB.Employs.Where(n => n.EmpState != 0 && n.DepID == (emp.DepID > 0 ? emp.DepID : n.DepID) && n.DutyID == (emp.DutyID > 0 ? emp.DutyID : n.DutyID) && n.EmpName.Contains((emp.EmpName == null ? n.EmpName : emp.EmpName))).Select(n => new EmpModel()
                {
                    EmpID = n.EmpID,
                    EmpMark = n.EmpMark,
                    EmpName = n.EmpName,
                    EmpState = n.EmpState,
                    EmpSex = n.EmpSex,
                    EmpAdd = n.EmpAdd,
                    EmpTel = n.EmpTel,
                    LoginName = n.LoginName,
                    DepID = n.DepID,
                    DepName = n.Departments.DepName,
                    DutyID = n.DutyID,
                    DutyName = n.Dutys.DutyName
                }).OrderByDescending(n => n.EmpID).Skip((page - 1) * size).Take(size).ToList();
                count = EmpData.Count;
                return EmpData;
            }
        }

        public static bool AddorUpdate(EmpModel emp)
        {
            using (LetDBEntities letDB = new LetDBEntities())
            {
                if (emp.EmpID > 0)
                {
                    var data = letDB.Employs.Find(emp.EmpID);
                    data.EmpMark = emp.EmpMark;
                    data.EmpName = emp.EmpName;
                    data.EmpSex = emp.EmpSex;
                    data.EmpAdd = emp.EmpAdd;
                    data.EmpTel = emp.EmpTel;
                    data.LoginName = emp.LoginName;
                    data.DepID = emp.DepID;
                    data.DutyID = emp.DutyID;
                    letDB.Entry(data).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    letDB.Employs.Add(new Employs()
                    {
                        EmpMark = emp.EmpMark,
                        EmpName = emp.EmpName,
                        EmpSex = emp.EmpSex,
                        EmpAdd = emp.EmpAdd,
                        EmpTel = emp.EmpTel,
                        LoginName = emp.LoginName,
                        DepID = emp.DepID,
                        DutyID = emp.DutyID,
                        EmpState = 1
                    });
                }
                if (letDB.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool Delete(int id)
        {
            using (LetDBEntities letDB = new LetDBEntities())
            {
                var remove = letDB.Employs.Find(id);
                remove.EmpState = 0;
                letDB.Entry(remove).State = System.Data.Entity.EntityState.Modified;
                if (letDB.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static EmpModel EmpSearchByID(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var emp = db.Employs.Find(id);
                EmpModel emps = new EmpModel()
                {
                    EmpMark = emp.EmpMark,
                    EmpName = emp.EmpName,
                    EmpSex = emp.EmpSex,
                    EmpAdd = emp.EmpAdd,
                    EmpTel = emp.EmpTel,
                    LoginName = emp.LoginName,
                    DepID = emp.DepID,
                    DutyID = emp.DutyID
                };
                return emps;
            }
        }
    }
}