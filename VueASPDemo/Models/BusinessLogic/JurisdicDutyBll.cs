using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueASPDemo.Models.EFModel;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Models.BusinessLogic
{
    public static class JurisdicDutyBll
    {
        public static bool Insert(JurisdicDutyModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = new JurisdicDuty()
                {
                    JurID = info.JurID,
                    DutyID = info.DutyID,
                };
                db.JurisdicDuty.Add(model);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(JurisdicDutyModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.JurisdicDuty.Find(info.JDID);
                model.JurID = info.JurID;
                model.DutyID = info.DutyID;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static bool Delete(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.JurisdicDuty.Find(id);
                db.JurisdicDuty.Remove(model);
                return db.SaveChanges() > 0;
            }
        }

        public static JurisdicDutyModel SelectForID(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var info = db.JurisdicDuty.Find(id);
                //转成自定义对象
                return new JurisdicDutyModel()
                {
                    JDID = info.JDID,
                    JurID = info.JurID,
                    DutyID = info.DutyID,
                };
            }
        }

        public static List<JurisdicDutyModel> SelectAll()
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var lists = db.JurisdicDuty.Select(info => new JurisdicDutyModel()
                {
                    JDID = info.JDID,
                    JurID = info.JurID,
                    DutyID = info.DutyID,
                }).ToList();
                return lists;
            }
        }

        public static List<JurisdicDutyModel> GetPageList(int index, int size, JurisdicDutyModel whereModel, out int countRows)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var wherelist = db.JurisdicDuty;
                //通过短路现象进行拼接条件
                // .Where(t => string.IsNullOrEmpty(whereModel.EmpName) || t.EmpName.Contains(whereModel.EmpName))
                // .Where(t => whereModel.DepID < 1 || t.DepID == whereModel.DepID)
                // wherelist.Where(t => whereModel.DutyID < 1 || t.DutyID == whereModel.DutyID);
                //得到记录数
                countRows = wherelist.Count();
                //做分页
                //返回分页后的数据
                return wherelist.OrderByDescending(info => info.JDID).Skip((index - 1) * size).Take(size).Select(info => new JurisdicDutyModel()
                {
                    JDID = info.JDID,
                    JurID = info.JurID,
                    DutyID = info.DutyID,
                }).ToList();
            }
        }
    }
}