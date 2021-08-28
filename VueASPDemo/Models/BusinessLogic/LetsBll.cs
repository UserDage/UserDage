using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueASPDemo.Models.EFModel;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Models.BusinessLogic
{
    public static class LetsBll
    {
        public static bool Insert(LetsModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = new Lets()
                {
                    HID = info.HID,
                    CusID = info.CusID,
                    EmpID = info.EmpID,
                    LetBeginDate = info.LetBeginDate,
                    ExpectEndDate = info.ExpectEndDate,
                    LetEndDate = info.LetEndDate,
                    LetRent = info.LetRent,
                    LetNet = info.LetNet,
                    BeginElectric = info.BeginElectric,
                    BeginWater = info.BeginWater,
                    EndElectric = info.EndElectric,
                    EndWater = info.EndWater,
                    EndMoney = info.EndMoney,
                    CurrentNetDate = info.CurrentNetDate,
                    CurrentRentDate = info.CurrentRentDate,
                    CreateEmp = info.CreateEmp,
                    CreateDate = info.CreateDate,
                    LetState = info.LetState,
                    LetMark = info.LetMark,
                    LetElectric = info.LetElectric,
                    LetWater = info.LetWater,
                };
                db.Lets.Add(model);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(LetsModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.Lets.Find(info.LetID);
                model.HID = info.HID;
                model.CusID = info.CusID;
                model.EmpID = info.EmpID;
                model.LetBeginDate = info.LetBeginDate;
                model.ExpectEndDate = info.ExpectEndDate;
                model.LetEndDate = info.LetEndDate;
                model.LetRent = info.LetRent;
                model.LetNet = info.LetNet;
                model.BeginElectric = info.BeginElectric;
                model.BeginWater = info.BeginWater;
                model.EndElectric = info.EndElectric;
                model.EndWater = info.EndWater;
                model.EndMoney = info.EndMoney;
                model.CurrentNetDate = info.CurrentNetDate;
                model.CurrentRentDate = info.CurrentRentDate;
                model.CreateEmp = info.CreateEmp;
                model.CreateDate = info.CreateDate;
                model.LetState = info.LetState;
                model.LetMark = info.LetMark;
                model.LetElectric = info.LetElectric;
                model.LetWater = info.LetWater;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static bool Delete(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.Lets.Find(id);
                db.Lets.Remove(model);
                return db.SaveChanges() > 0;
            }
        }

        public static LetsModel SelectForID(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var info = db.Lets.Find(id);
                //转成自定义对象
                return new LetsModel()
                {
                    LetID = info.LetID,
                    HID = info.HID,
                    CusID = info.CusID,
                    EmpID = info.EmpID,
                    LetBeginDate = info.LetBeginDate,
                    ExpectEndDate = info.ExpectEndDate,
                    LetEndDate = info.LetEndDate,
                    LetRent = info.LetRent,
                    LetNet = info.LetNet,
                    BeginElectric = info.BeginElectric,
                    BeginWater = info.BeginWater,
                    EndElectric = info.EndElectric,
                    EndWater = info.EndWater,
                    EndMoney = info.EndMoney,
                    CurrentNetDate = info.CurrentNetDate,
                    CurrentRentDate = info.CurrentRentDate,
                    CreateEmp = info.CreateEmp,
                    CreateDate = info.CreateDate,
                    LetState = info.LetState,
                    LetMark = info.LetMark,
                    LetElectric = info.LetElectric,
                    LetWater = info.LetWater,
                };
            }
        }

        public static List<LetsModel> SelectAll()
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var lists = db.Lets.Select(info => new LetsModel()
                {
                    LetID = info.LetID,
                    HID = info.HID,
                    CusID = info.CusID,
                    EmpID = info.EmpID,
                    LetBeginDate = info.LetBeginDate,
                    ExpectEndDate = info.ExpectEndDate,
                    LetEndDate = info.LetEndDate,
                    LetRent = info.LetRent,
                    LetNet = info.LetNet,
                    BeginElectric = info.BeginElectric,
                    BeginWater = info.BeginWater,
                    EndElectric = info.EndElectric,
                    EndWater = info.EndWater,
                    EndMoney = info.EndMoney,
                    CurrentNetDate = info.CurrentNetDate,
                    CurrentRentDate = info.CurrentRentDate,
                    CreateEmp = info.CreateEmp,
                    CreateDate = info.CreateDate,
                    LetState = info.LetState,
                    LetMark = info.LetMark,
                    LetElectric = info.LetElectric,
                    LetWater = info.LetWater,
                }).ToList();
                return lists;
            }
        }

        public static List<LetsModel> GetPageList(int index, int size, LetsModel whereModel, out int countRows)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var wherelist = db.Lets;
                //通过短路现象进行拼接条件
                // .Where(t => string.IsNullOrEmpty(whereModel.EmpName) || t.EmpName.Contains(whereModel.EmpName))
                // .Where(t => whereModel.DepID < 1 || t.DepID == whereModel.DepID)
                // wherelist.Where(t => whereModel.DutyID < 1 || t.DutyID == whereModel.DutyID);
                //得到记录数
                countRows = wherelist.Count();
                //做分页
                //返回分页后的数据
                return wherelist.OrderByDescending(info => info.LetID).Skip((index - 1) * size).Take(size).Select(info => new LetsModel()
                {
                    LetID = info.LetID,
                    HID = info.HID,
                    CusID = info.CusID,
                    EmpID = info.EmpID,
                    LetBeginDate = info.LetBeginDate,
                    ExpectEndDate = info.ExpectEndDate,
                    LetEndDate = info.LetEndDate,
                    LetRent = info.LetRent,
                    LetNet = info.LetNet,
                    BeginElectric = info.BeginElectric,
                    BeginWater = info.BeginWater,
                    EndElectric = info.EndElectric,
                    EndWater = info.EndWater,
                    EndMoney = info.EndMoney,
                    CurrentNetDate = info.CurrentNetDate,
                    CurrentRentDate = info.CurrentRentDate,
                    CreateEmp = info.CreateEmp,
                    CreateDate = info.CreateDate,
                    LetState = info.LetState,
                    LetMark = info.LetMark,
                    LetElectric = info.LetElectric,
                    LetWater = info.LetWater,
                }).ToList();
            }
        }
    }
}