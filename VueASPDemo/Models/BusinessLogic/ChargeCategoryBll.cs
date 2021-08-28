using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueASPDemo.Models.EFModel;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Models.BusinessLogic
{
    public static class ChargeCategoryBll
    {
        public static bool Insert(ChargeCategoryModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = new ChargeCategory()
                {
                    CCName = info.CCName,
                    CCMark = info.CCMark,
                    ISDate = info.ISDate,
                    CCState = info.CCState,
                    CCColumn1 = info.CCColumn1,
                    CCColumn2 = info.CCColumn2,
                    CDateColumn = info.CDateColumn,
                };
                db.ChargeCategory.Add(model);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(ChargeCategoryModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.ChargeCategory.Find(info.CCID);
                model.CCName = info.CCName;
                model.CCMark = info.CCMark;
                model.ISDate = info.ISDate;
                model.CCState = info.CCState;
                model.CCColumn1 = info.CCColumn1;
                model.CCColumn2 = info.CCColumn2;
                model.CDateColumn = info.CDateColumn;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static bool Delete(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.ChargeCategory.Find(id);
                db.ChargeCategory.Remove(model);
                return db.SaveChanges() > 0;
            }
        }

        public static ChargeCategoryModel SelectForID(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var info = db.ChargeCategory.Find(id);
                //转成自定义对象
                return new ChargeCategoryModel()
                {
                    CCID = info.CCID,
                    CCName = info.CCName,
                    CCMark = info.CCMark,
                    ISDate = info.ISDate,
                    CCState = info.CCState,
                    CCColumn1 = info.CCColumn1,
                    CCColumn2 = info.CCColumn2,
                    CDateColumn = info.CDateColumn,
                };
            }
        }

        public static List<ChargeCategoryModel> SelectAll()
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var lists = db.ChargeCategory.Select(info => new ChargeCategoryModel()
                {
                    CCID = info.CCID,
                    CCName = info.CCName,
                    CCMark = info.CCMark,
                    ISDate = info.ISDate,
                    CCState = info.CCState,
                    CCColumn1 = info.CCColumn1,
                    CCColumn2 = info.CCColumn2,
                    CDateColumn = info.CDateColumn,
                }).ToList();
                return lists;
            }
        }

        public static List<ChargeCategoryModel> GetPageList(int index, int size, ChargeCategoryModel whereModel, out int countRows)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var wherelist = db.ChargeCategory;
                //通过短路现象进行拼接条件
                // .Where(t => string.IsNullOrEmpty(whereModel.EmpName) || t.EmpName.Contains(whereModel.EmpName))
                // .Where(t => whereModel.DepID < 1 || t.DepID == whereModel.DepID)
                // wherelist.Where(t => whereModel.DutyID < 1 || t.DutyID == whereModel.DutyID);
                //得到记录数
                countRows = wherelist.Count();
                //做分页
                //返回分页后的数据
                return wherelist.OrderByDescending(info => info.CCID).Skip((index - 1) * size).Take(size).Select(info => new ChargeCategoryModel()
                {
                    CCID = info.CCID,
                    CCName = info.CCName,
                    CCMark = info.CCMark,
                    ISDate = info.ISDate,
                    CCState = info.CCState,
                    CCColumn1 = info.CCColumn1,
                    CCColumn2 = info.CCColumn2,
                    CDateColumn = info.CDateColumn,
                }).ToList();
            }
        }
    }
}