using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueASPDemo.Models.EFModel;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Models.BusinessLogic
{
    public static class PayInfoBll
    {
        public static bool Insert(PayInfoModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = new PayInfo()
                {
                    LetID = info.LetID,
                    CCID = info.CCID,
                    PayNum = info.PayNum,
                    CreateEmp = info.CreateEmp,
                    CreateDate = info.CreateDate,
                    PayPrice = info.PayPrice,
                    PayAmount = info.PayAmount,
                    PayBeginDate = info.PayBeginDate,
                    PayEndDate = info.PayEndDate,
                    PayMark = info.PayMark,
                    PayMoney1 = info.PayMoney1,
                    PayMoney2 = info.PayMoney2,
                    PayState = info.PayState,
                };
                db.PayInfo.Add(model);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(PayInfoModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.PayInfo.Find(info.PayID);
                model.LetID = info.LetID;
                model.CCID = info.CCID;
                model.PayNum = info.PayNum;
                model.CreateEmp = info.CreateEmp;
                model.CreateDate = info.CreateDate;
                model.PayPrice = info.PayPrice;
                model.PayAmount = info.PayAmount;
                model.PayBeginDate = info.PayBeginDate;
                model.PayEndDate = info.PayEndDate;
                model.PayMark = info.PayMark;
                model.PayMoney1 = info.PayMoney1;
                model.PayMoney2 = info.PayMoney2;
                model.PayState = info.PayState;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static bool Delete(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.PayInfo.Find(id);
                db.PayInfo.Remove(model);
                return db.SaveChanges() > 0;
            }
        }

        public static PayInfoModel SelectForID(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var info = db.PayInfo.Find(id);
                //转成自定义对象
                return new PayInfoModel()
                {
                    PayID = info.PayID,
                    LetID = info.LetID,
                    CCID = info.CCID,
                    PayNum = info.PayNum,
                    CreateEmp = info.CreateEmp,
                    CreateDate = info.CreateDate,
                    PayPrice = info.PayPrice,
                    PayAmount = info.PayAmount,
                    PayBeginDate = info.PayBeginDate,
                    PayEndDate = info.PayEndDate,
                    PayMark = info.PayMark,
                    PayMoney1 = info.PayMoney1,
                    PayMoney2 = info.PayMoney2,
                    PayState = info.PayState,
                };
            }
        }

        public static List<PayInfoModel> SelectAll()
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var lists = db.PayInfo.Select(info => new PayInfoModel()
                {
                    PayID = info.PayID,
                    LetID = info.LetID,
                    CCID = info.CCID,
                    PayNum = info.PayNum,
                    CreateEmp = info.CreateEmp,
                    CreateDate = info.CreateDate,
                    PayPrice = info.PayPrice,
                    PayAmount = info.PayAmount,
                    PayBeginDate = info.PayBeginDate,
                    PayEndDate = info.PayEndDate,
                    PayMark = info.PayMark,
                    PayMoney1 = info.PayMoney1,
                    PayMoney2 = info.PayMoney2,
                    PayState = info.PayState,
                }).ToList();
                return lists;
            }
        }

        public static List<PayInfoModel> GetPageList(int index, int size, PayInfoModel whereModel, out int countRows)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var wherelist = db.PayInfo;
                //通过短路现象进行拼接条件
                // .Where(t => string.IsNullOrEmpty(whereModel.EmpName) || t.EmpName.Contains(whereModel.EmpName))
                // .Where(t => whereModel.DepID < 1 || t.DepID == whereModel.DepID)
                // wherelist.Where(t => whereModel.DutyID < 1 || t.DutyID == whereModel.DutyID);
                //得到记录数
                countRows = wherelist.Count();
                //做分页
                //返回分页后的数据
                return wherelist.OrderByDescending(info => info.PayID).Skip((index - 1) * size).Take(size).Select(info => new PayInfoModel()
                {
                    PayID = info.PayID,
                    LetID = info.LetID,
                    CCID = info.CCID,
                    PayNum = info.PayNum,
                    CreateEmp = info.CreateEmp,
                    CreateDate = info.CreateDate,
                    PayPrice = info.PayPrice,
                    PayAmount = info.PayAmount,
                    PayBeginDate = info.PayBeginDate,
                    PayEndDate = info.PayEndDate,
                    PayMark = info.PayMark,
                    PayMoney1 = info.PayMoney1,
                    PayMoney2 = info.PayMoney2,
                    PayState = info.PayState,
                }).ToList();
            }
        }
    }
}