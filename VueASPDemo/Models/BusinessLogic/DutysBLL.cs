using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueASPDemo.Models.EFModel;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Models.BusinessLogic
{
    public class DutysBLL
    {
        public static List<DutysModel> DutySearchALL(int id, string DutyName, int page, int size, out int count)
        {
            using (LetDBEntities letDB = new LetDBEntities())
            {
                var DutyData = letDB.Dutys.Where(n => n.DutyID == (id == 0 ? n.DutyID : id) && n.DutyState == true && n.DutyName.Contains((DutyName == "" ? n.DutyName : DutyName))).Select(n => new DutysModel()
                {
                    DutyID = n.DutyID,
                    DutyName = n.DutyName,
                    DutyMark = n.DutyMark,
                    DutyState = n.DutyState
                }).OrderByDescending(n => n.DutyID).Skip((page - 1) * size).Take(size).ToList();
                count = letDB.Dutys.Where(n => n.DutyID == (id == 0 ? n.DutyID : id) && n.DutyState == true && n.DutyName.Contains((DutyName == "" ? n.DutyName : DutyName))).Count();
                return DutyData;
            }
        }

        public static bool AddorUpdate(DutysModel dutysModel)
        {
            using (LetDBEntities letDB = new LetDBEntities())
            {
                if (dutysModel.DutyID > 0)
                {
                    var data = letDB.Dutys.Find(dutysModel.DutyID);
                    data.DutyName = dutysModel.DutyName;
                    data.DutyMark = dutysModel.DutyMark;
                    letDB.Entry(data).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    letDB.Dutys.Add(new Dutys()
                    {
                        DutyMark = dutysModel.DutyMark,
                        DutyName = dutysModel.DutyName,
                        DutyState = true
                    });
                }
                if (letDB.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static DutysModel SearchByID(int id)
        {
            using (LetDBEntities letDB = new LetDBEntities())
            {
                var data = letDB.Dutys.Find(id);
                DutysModel dutys = new DutysModel()
                {
                    DutyID = data.DutyID,
                    DutyName = data.DutyName,
                    DutyMark = data.DutyMark,
                    DutyState = data.DutyState
                };
                return dutys;
            }
        }

        public static bool Delete(int id)
        {
            using (LetDBEntities letDB = new LetDBEntities())
            {
                var remove = letDB.Dutys.Find(id);
                remove.DutyState = false;
                letDB.Entry(remove).State = System.Data.Entity.EntityState.Modified;
                if (letDB.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<DutysModel> GetDutyALL()
        {
            using (LetDBEntities db = new LetDBEntities())
            {
                var data = db.Dutys.Select(n => new DutysModel()
                {
                    DutyID = n.DutyID,
                    DutyName = n.DutyName,
                    DutyMark = n.DutyMark,
                    DutyState = n.DutyState
                }).ToList();
                return data;
            }
        }
    }
}