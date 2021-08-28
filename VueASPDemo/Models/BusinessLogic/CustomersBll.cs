using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueASPDemo.Models.EFModel;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Models.BusinessLogic
{
    public static class CustomersBll
    {
        public static bool Insert(CustomersModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = new Customers()
                {
                    CusName = info.CusName,
                    CusSex = info.CusSex,
                    CusTel = info.CusTel,
                    CusCard = info.CusCard,
                    CusState = info.CusState,
                };
                db.Customers.Add(model);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(CustomersModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.Customers.Find(info.CusID);
                model.CusName = info.CusName;
                model.CusSex = info.CusSex;
                model.CusTel = info.CusTel;
                model.CusCard = info.CusCard;
                model.CusState = info.CusState;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static bool Delete(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.Customers.Find(id);
                db.Customers.Remove(model);
                return db.SaveChanges() > 0;
            }
        }

        public static CustomersModel SelectForID(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var info = db.Customers.Find(id);
                //转成自定义对象
                return new CustomersModel()
                {
                    CusID = info.CusID,
                    CusName = info.CusName,
                    CusSex = info.CusSex,
                    CusTel = info.CusTel,
                    CusCard = info.CusCard,
                    CusState = info.CusState,
                };
            }
        }

        public static List<CustomersModel> SelectAll()
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var lists = db.Customers.Select(info => new CustomersModel()
                {
                    CusID = info.CusID,
                    CusName = info.CusName,
                    CusSex = info.CusSex,
                    CusTel = info.CusTel,
                    CusCard = info.CusCard,
                    CusState = info.CusState,
                }).ToList();
                return lists;
            }
        }

        public static List<CustomersModel> GetPageList(int index, int size, CustomersModel whereModel, out int countRows)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var wherelist = db.Customers.Where(t => t.CusName.Contains(whereModel.CusName == null ? t.CusName : whereModel.CusName));
                //通过短路现象进行拼接条件
                //得到记录数
                countRows = wherelist.Count();
                //做分页
                //返回分页后的数据
                return wherelist.OrderByDescending(info => info.CusID).Skip((index - 1) * size).Take(size).Select(info => new CustomersModel()
                {
                    CusID = info.CusID,
                    CusName = info.CusName,
                    CusSex = info.CusSex,
                    CusTel = info.CusTel,
                    CusCard = info.CusCard,
                    CusState = info.CusState,
                }).ToList();
            }
        }
    }
}