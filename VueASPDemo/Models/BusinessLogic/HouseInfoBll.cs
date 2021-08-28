using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueASPDemo.Models.EFModel;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Models.BusinessLogic
{
    public static class HouseInfoBll
    {
        public static bool Insert(HouseInfoModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = new HouseInfo()
                {
                    HCID = info.HCID,
                    HAdd = info.HAdd,
                    HNum = info.HNum,
                    HType = info.HType,
                    HArea = info.HArea,
                    HDirection = info.HDirection,
                    HRent = info.HRent,
                    HNet = info.HNet,
                    HElectric = info.HElectric,
                    HWater = info.HWater,
                    HElectricMoney = info.HElectricMoney,
                    HWaterMoney = info.HWaterMoney,
                    HMark = info.HMark,
                    HState = info.HState,
                };
                db.HouseInfo.Add(model);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(HouseInfoModel info)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.HouseInfo.Find(info.HID);
                model.HCID = info.HCID;
                model.HAdd = info.HAdd;
                model.HNum = info.HNum;
                model.HType = info.HType;
                model.HArea = info.HArea;
                model.HDirection = info.HDirection;
                model.HRent = info.HRent;
                model.HNet = info.HNet;
                model.HElectric = info.HElectric;
                model.HWater = info.HWater;
                model.HElectricMoney = info.HElectricMoney;
                model.HWaterMoney = info.HWaterMoney;
                model.HMark = info.HMark;
                model.HState = info.HState;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static bool Delete(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var model = db.HouseInfo.Find(id);
                db.HouseInfo.Remove(model);
                return db.SaveChanges() > 0;
            }
        }

        public static HouseInfoModel SelectForID(int id)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var info = db.HouseInfo.Find(id);
                //转成自定义对象
                return new HouseInfoModel()
                {
                    HID = info.HID,
                    HCID = info.HCID,
                    HAdd = info.HAdd,
                    HNum = info.HNum,
                    HType = info.HType,
                    HArea = info.HArea,
                    HDirection = info.HDirection,
                    HRent = info.HRent,
                    HNet = info.HNet,
                    HElectric = info.HElectric,
                    HWater = info.HWater,
                    HElectricMoney = info.HElectricMoney,
                    HWaterMoney = info.HWaterMoney,
                    HMark = info.HMark,
                    HState = info.HState,
                };
            }
        }

        public static List<HouseInfoModel> SelectAll()
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var lists = db.HouseInfo.Select(info => new HouseInfoModel()
                {
                    HID = info.HID,
                    HCID = info.HCID,
                    HAdd = info.HAdd,
                    HNum = info.HNum,
                    HType = info.HType,
                    HArea = info.HArea,
                    HDirection = info.HDirection,
                    HRent = info.HRent,
                    HNet = info.HNet,
                    HElectric = info.HElectric,
                    HWater = info.HWater,
                    HElectricMoney = info.HElectricMoney,
                    HWaterMoney = info.HWaterMoney,
                    HMark = info.HMark,
                    HState = info.HState,
                }).ToList();
                return lists;
            }
        }

        public static List<HouseInfoModel> GetPageList(int index, int size, HouseInfoModel whereModel, out int countRows)
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var wherelist = db.HouseInfo;
                //通过短路现象进行拼接条件
                // .Where(t => string.IsNullOrEmpty(whereModel.EmpName) || t.EmpName.Contains(whereModel.EmpName))
                // .Where(t => whereModel.DepID < 1 || t.DepID == whereModel.DepID)
                // wherelist.Where(t => whereModel.DutyID < 1 || t.DutyID == whereModel.DutyID);
                //得到记录数
                countRows = wherelist.Count();
                //做分页
                //返回分页后的数据
                return wherelist.OrderByDescending(info => info.HID).Skip((index - 1) * size).Take(size).Select(info => new HouseInfoModel()
                {
                    HID = info.HID,
                    HCID = info.HCID,
                    HAdd = info.HAdd,
                    HNum = info.HNum,
                    HType = info.HType,
                    HArea = info.HArea,
                    HDirection = info.HDirection,
                    HRent = info.HRent,
                    HNet = info.HNet,
                    HElectric = info.HElectric,
                    HWater = info.HWater,
                    HElectricMoney = info.HElectricMoney,
                    HWaterMoney = info.HWaterMoney,
                    HMark = info.HMark,
                    HState = info.HState,
                }).ToList();
            }
        }
    }
}