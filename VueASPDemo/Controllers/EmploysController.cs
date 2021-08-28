using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VueASPDemo.Models.BusinessLogic;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Controllers
{
    public class EmploysController : Controller
    {
        // GET: Employs
        public ActionResult EmploysPage()
        {
            return View();
        }

        public ActionResult EmpData(EmpModel emp, int page, int rows)
        {
            int count;
            var data = EmploysBLL.EmpSearchALL(emp, page, rows, out count);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDept()
        {
            var data = DepartmentsBLL.GetDeptALL();
            data.Insert(0, new DepartmentsModel() { DepID = -1, DepName = "全部" });
            return Json(data);
        }

        public ActionResult GetDuty()
        {
            var data = DutysBLL.GetDutyALL();
            data.Insert(0, new DutysModel() { DutyID = -1, DutyName = "全部" });
            return Json(data);
        }

        public ActionResult Edit(EmpModel emp)
        {
            var data = EmploysBLL.AddorUpdate(emp);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmpData(int id)
        {
            var data = EmploysBLL.EmpSearchByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = EmploysBLL.Delete(id);
            return Json(data);
        }
    }
}