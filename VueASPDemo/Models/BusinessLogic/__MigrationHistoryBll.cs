using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueASPDemo.Models.EFModel;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Models.BusinessLogic
{
    public static class __MigrationHistoryBll
    {
        public static bool Insert(__MigrationHistoryModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = new C__MigrationHistory()
                {
                    Model = info.Model,
                    ProductVersion = info.ProductVersion,
                };
                db.C__MigrationHistory.Add(model);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(__MigrationHistoryModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.C__MigrationHistory.Find(info.ContextKey);
                model.Model = info.Model;
                model.ProductVersion = info.ProductVersion;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static bool Delete(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.C__MigrationHistory.Find(id);
                db.C__MigrationHistory.Remove(model);
                return db.SaveChanges() > 0;
            }
        }

        public static __MigrationHistoryModel SelectForID(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var info = db.C__MigrationHistory.Find(id);
                //转成自定义对象
                return new __MigrationHistoryModel()
                {
                    ContextKey = info.ContextKey,
                    Model = info.Model,
                    ProductVersion = info.ProductVersion,
                };
            }
        }

        public static List<__MigrationHistoryModel> SelectAll()
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var lists = db.C__MigrationHistory.Select(info => new __MigrationHistoryModel()
                {
                    ContextKey = info.ContextKey,
                    Model = info.Model,
                    ProductVersion = info.ProductVersion,
                }).ToList();
                return lists;
            }
        }

        public static List<__MigrationHistoryModel> GetPageList(int index, int size, __MigrationHistoryModel whereModel, out int countRows)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var wherelist = db.C__MigrationHistory;
                //通过短路现象进行拼接条件
                // .Where(t => string.IsNullOrEmpty(whereModel.EmpName) || t.EmpName.Contains(whereModel.EmpName))
                // .Where(t => whereModel.DepID < 1 || t.DepID == whereModel.DepID)
                // wherelist.Where(t => whereModel.DutyID < 1 || t.DutyID == whereModel.DutyID);
                //得到记录数
                countRows = wherelist.Count();
                //做分页
                //返回分页后的数据
                return wherelist.OrderByDescending(info => info.ContextKey).Skip((index - 1) * size).Take(size).Select(info => new __MigrationHistoryModel()
                {
                    ContextKey = info.ContextKey,
                    Model = info.Model,
                    ProductVersion = info.ProductVersion,
                }).ToList();
            }
        }
    }
}