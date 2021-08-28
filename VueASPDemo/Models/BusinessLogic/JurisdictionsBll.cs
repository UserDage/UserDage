using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueASPDemo.Models.EFModel;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Models.BusinessLogic
{
    public static class JurisdictionsBll
    {
        public static bool Insert(JurisdictionsModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = new Jurisdictions()
                {
                    JurName = info.JurName,
                    JurValue = info.JurValue,
                    JurState = info.JurState,
                };
                db.Jurisdictions.Add(model);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(JurisdictionsModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.Jurisdictions.Find(info.JurID);
                model.JurName = info.JurName;
                model.JurValue = info.JurValue;
                model.JurState = info.JurState;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static bool Delete(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.Jurisdictions.Find(id);
                db.Jurisdictions.Remove(model);
                return db.SaveChanges() > 0;
            }
        }

        public static JurisdictionsModel SelectForID(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var info = db.Jurisdictions.Find(id);
                //转成自定义对象
                return new JurisdictionsModel()
                {
                    JurID = info.JurID,
                    JurName = info.JurName,
                    JurValue = info.JurValue,
                    JurState = info.JurState,
                };
            }
        }

        public static List<JurisdictionsModel> SelectAll()
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var lists = db.Jurisdictions.Select(info => new JurisdictionsModel()
                {
                    JurID = info.JurID,
                    JurName = info.JurName,
                    JurValue = info.JurValue,
                    JurState = info.JurState,
                }).ToList();
                return lists;
            }
        }

        public static List<JurisdictionsModel> GetPageList(int index, int size, JurisdictionsModel whereModel, out int countRows)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var wherelist = db.Jurisdictions;
                //通过短路现象进行拼接条件
                // .Where(t => string.IsNullOrEmpty(whereModel.EmpName) || t.EmpName.Contains(whereModel.EmpName))
                // .Where(t => whereModel.DepID < 1 || t.DepID == whereModel.DepID)
                // wherelist.Where(t => whereModel.DutyID < 1 || t.DutyID == whereModel.DutyID);
                //得到记录数
                countRows = wherelist.Count();
                //做分页
                //返回分页后的数据
                return wherelist.OrderByDescending(info => info.JurID).Skip((index - 1) * size).Take(size).Select(info => new JurisdictionsModel()
                {
                    JurID = info.JurID,
                    JurName = info.JurName,
                    JurValue = info.JurValue,
                    JurState = info.JurState,
                }).ToList();
            }
        }
    }
}