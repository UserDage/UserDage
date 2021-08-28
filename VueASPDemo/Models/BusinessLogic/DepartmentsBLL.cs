using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueASPDemo.Models.EFModel;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Models.BusinessLogic
{
    public class DepartmentsBLL
    {
        public static List<DepartmentsModel> DeptSearchALL(int currentPage, int pagesize, string DepName, out int total)
        {
            using (LetDBEntities letDB = new LetDBEntities())
            {
                var DeptData = letDB.Departments.Where(n => n.DepState == true && n.DepName == (DepName == "" ? n.DepName : DepName)).Select(n => new DepartmentsModel()
                {
                    DepID = n.DepID,
                    DepName = n.DepName,
                    DepMark = n.DepMark,
                    DepState = n.DepState
                }).OrderBy(n => n.DepID).Skip((currentPage - 1) * pagesize).Take(pagesize).ToList();
                total = letDB.Departments.Where(n => n.DepState == true).Count();
                return DeptData;
            }
        }

        public static bool AddorUpdate(DepartmentsModel dep)
        {
            using (LetDBEntities letDB = new LetDBEntities())
            {
                if (dep.DepID > 0)
                {
                    var data = letDB.Departments.Find(dep.DepID);
                    data.DepMark = dep.DepMark;
                    data.DepName = dep.DepName;
                    letDB.Entry(data).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    letDB.Departments.Add(new Departments()
                    {
                        DepMark = dep.DepMark,
                        DepName = dep.DepName,
                        DepState = true
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
                var remove = letDB.Departments.Find(id);
                remove.DepState = false;
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

        public static DepartmentsModel SearchByID(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var data = db.Departments.Find(id);
                DepartmentsModel model = new DepartmentsModel()
                {
                    DepID = data.DepID,
                    DepName = data.DepName,
                    DepMark = data.DepMark,
                    DepState = data.DepState
                };
                return model;
            }
        }

        public static List<DepartmentsModel> GetDeptALL()
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var data = db.Departments.Select(n => new DepartmentsModel()
                {
                    DepID = n.DepID,
                    DepName = n.DepName,
                    DepMark = n.DepMark,
                    DepState = n.DepState
                }).ToList();
                return data;
            }
        }
    }
}