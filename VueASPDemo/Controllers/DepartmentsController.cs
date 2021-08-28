using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VueASPDemo.Models.BusinessLogic;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Departments

        public ActionResult DepartmentsPage()
        {
            return View();
        }

        public ActionResult GetPageData(int currentPage, int pagesize, string DepName = "")
        {
            int total;
            if (DepartmentsBLL.DeptSearchALL(currentPage, pagesize, DepName, out total) != null)
            {
                var data = DepartmentsBLL.DeptSearchALL(currentPage, pagesize, DepName, out total);
                return Json(new { Dept = data, total = total, pagecount = Math.Ceiling(total / (decimal)pagesize) });
            }
            else
            {
                return Json("");
            }
        }

        public ActionResult DeptJson(int id)
        {
            if (id > 0)
            {
                var data = DepartmentsBLL.SearchByID(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult AddorUpdate(DepartmentsModel model)
        {
            var backdata = DepartmentsBLL.AddorUpdate(model);
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
            var yesno = DepartmentsBLL.Delete(id);
            return Json(yesno);
        }
    }
}