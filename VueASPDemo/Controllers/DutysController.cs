using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VueASPDemo.Models.BusinessLogic;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Controllers
{
    public class DutysController : Controller
    {
        // GET: Dutys
        public ActionResult DutysPage()
        {
            return View();
        }

        public ActionResult DutysPageData(int currentPage, int pagesize, string DutyName = "")
        {
            int count;
            if (DutysBLL.DutySearchALL(0, DutyName, currentPage, pagesize, out count) != null)
            {
                var data = DutysBLL.DutySearchALL(0, DutyName, currentPage, pagesize, out count);
                return Json(new { DutysInfo = data, total = count, pagecount = Math.Ceiling(count / (decimal)pagesize) }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("");
            }
        }

        public ActionResult DutysJson(int id)
        {
            if (id > 0)
            {
                var data = DutysBLL.SearchByID(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult AddorUpdate(DutysModel dutys)
        {
            var backdata = DutysBLL.AddorUpdate(dutys);
            if (backdata)
            {
                return Json(backdata);
            }
            else
            {
                return Json(backdata);
            }
        }

        public ActionResult Delete(int id)
        {
            var yesno = DutysBLL.Delete(id);
            return Json(yesno);
        }
    }
}