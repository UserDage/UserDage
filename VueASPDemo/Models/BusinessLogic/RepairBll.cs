using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueASPDemo.Models.EFModel;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Models.BusinessLogic
{
    public static class RepairBll
    {
        public static bool Insert(RepairModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = new Repair()
                {
                    LetID = info.LetID,
                    RepDate = info.RepDate,
                    RepContent = info.RepContent,
                    RepEmp = info.RepEmp,
                    RepState = info.RepState,
                    RepMark = info.RepMark,
                    RepEndDate = info.RepEndDate,
                    CreateEmp = info.CreateEmp,
                    CreateDate = info.CreateDate,
                };
                db.Repair.Add(model);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(RepairModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.Repair.Find(info.RepID);
                model.LetID = info.LetID;
                model.RepDate = info.RepDate;
                model.RepContent = info.RepContent;
                model.RepEmp = info.RepEmp;
                model.RepState = info.RepState;
                model.RepMark = info.RepMark;
                model.RepEndDate = info.RepEndDate;
                model.CreateEmp = info.CreateEmp;
                model.CreateDate = info.CreateDate;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static bool Delete(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.Repair.Find(id);
                db.Repair.Remove(model);
                return db.SaveChanges() > 0;
            }
        }

        public static RepairModel SelectForID(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var info = db.Repair.Find(id);
                //转成自定义对象
                return new RepairModel()
                {
                    RepID = info.RepID,
                    LetID = info.LetID,
                    RepDate = info.RepDate,
                    RepContent = info.RepContent,
                    RepEmp = info.RepEmp,
                    RepState = info.RepState,
                    RepMark = info.RepMark,
                    RepEndDate = info.RepEndDate,
                    CreateEmp = info.CreateEmp,
                    CreateDate = info.CreateDate,
                };
            }
        }

        public static List<RepairModel> SelectAll()
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var lists = db.Repair.Select(info => new RepairModel()
                {
                    RepID = info.RepID,
                    LetID = info.LetID,
                    RepDate = info.RepDate,
                    RepContent = info.RepContent,
                    RepEmp = info.RepEmp,
                    RepState = info.RepState,
                    RepMark = info.RepMark,
                    RepEndDate = info.RepEndDate,
                    CreateEmp = info.CreateEmp,
                    CreateDate = info.CreateDate,
                }).ToList();
                return lists;
            }
        }

        public static List<RepairModel> GetPageList(int index, int size, RepairModel whereModel, out int countRows)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var wherelist = db.Repair;
                //通过短路现象进行拼接条件
                // .Where(t => string.IsNullOrEmpty(whereModel.EmpName) || t.EmpName.Contains(whereModel.EmpName))
                // .Where(t => whereModel.DepID < 1 || t.DepID == whereModel.DepID)
                // wherelist.Where(t => whereModel.DutyID < 1 || t.DutyID == whereModel.DutyID);
                //得到记录数
                countRows = wherelist.Count();
                //做分页
                //返回分页后的数据
                return wherelist.OrderByDescending(info => info.RepID).Skip((index - 1) * size).Take(size).Select(info => new RepairModel()
                {
                    RepID = info.RepID,
                    LetID = info.LetID,
                    RepDate = info.RepDate,
                    RepContent = info.RepContent,
                    RepEmp = info.RepEmp,
                    RepState = info.RepState,
                    RepMark = info.RepMark,
                    RepEndDate = info.RepEndDate,
                    CreateEmp = info.CreateEmp,
                    CreateDate = info.CreateDate,
                }).ToList();
            }
        }
    }
}