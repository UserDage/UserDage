using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueASPDemo.Models.EFModel;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Models.BusinessLogic
{
    public static class HouseCategoryBll
    {
        public static bool Insert(HouseCategoryModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = new HouseCategory()
                {
                    HCName = info.HCName,
                    HCMark = info.HCMark,
                    HCState = info.HCState,
                };
                db.HouseCategory.Add(model);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(HouseCategoryModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.HouseCategory.Find(info.HCID);
                model.HCName = info.HCName;
                model.HCMark = info.HCMark;
                model.HCState = info.HCState;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static bool Delete(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.HouseCategory.Find(id);
                db.HouseCategory.Remove(model);
                return db.SaveChanges() > 0;
            }
        }

        public static HouseCategoryModel SelectForID(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var info = db.HouseCategory.Find(id);
                //转成自定义对象
                return new HouseCategoryModel()
                {
                    HCID = info.HCID,
                    HCName = info.HCName,
                    HCMark = info.HCMark,
                    HCState = info.HCState,
                };
            }
        }

        public static List<HouseCategoryModel> SelectAll()
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var lists = db.HouseCategory.Select(info => new HouseCategoryModel()
                {
                    HCID = info.HCID,
                    HCName = info.HCName,
                    HCMark = info.HCMark,
                    HCState = info.HCState,
                }).ToList();
                return lists;
            }
        }

        public static List<HouseCategoryModel> GetPageList(int index, int size, HouseCategoryModel whereModel, out int countRows)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var wherelist = db.HouseCategory;
                //通过短路现象进行拼接条件
                // .Where(t => string.IsNullOrEmpty(whereModel.EmpName) || t.EmpName.Contains(whereModel.EmpName))
                // .Where(t => whereModel.DepID < 1 || t.DepID == whereModel.DepID)
                // wherelist.Where(t => whereModel.DutyID < 1 || t.DutyID == whereModel.DutyID);
                //得到记录数
                countRows = wherelist.Count();
                //做分页
                //返回分页后的数据
                return wherelist.OrderByDescending(info => info.HCID).Skip((index - 1) * size).Take(size).Select(info => new HouseCategoryModel()
                {
                    HCID = info.HCID,
                    HCName = info.HCName,
                    HCMark = info.HCMark,
                    HCState = info.HCState,
                }).ToList();
            }
        }
    }
}