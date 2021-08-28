using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VueASPDemo.Models.BusinessLogic;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Departmen
        public ActionResult CustomersPage()
        {
            return View();
        }

        // ��easyui��ҳ��page��ǰҳ��rowҳ���С������д
        public ActionResult GetData(int page, int rows, CustomersModel whereModel)
        {
            int count;
            var lists = CustomersBll.GetPageList(page, rows, whereModel, out count);

            return Json(new { rows = lists, total = count }, JsonRequestBehavior.AllowGet);
        }

        // POST: Departmen/Create
        [HttpPost]
        public ActionResult Create(CustomersModel model)
        {
            try
            {
                var result = CustomersBll.Insert(model);
                return Json(result);
            }
            catch
            {
                return Json(false);
            }
        }

        public ActionResult EditPage()
        {
            return View();
        }

        // GET: Departmen/Edit/5
        public ActionResult Edit(int id)
        {
            var model = CustomersBll.SelectForID(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // POST: Departmen/Edit/5
        [HttpPost]
        public ActionResult AddorUpdate(CustomersModel model)
        {
            try
            {
                var result = CustomersBll.Update(model);

                return Json(result);
            }
            catch
            {
                return Json(false);
            }
        }

        // ɾ������

        public ActionResult Delete(int id)
        {
            var result = CustomersBll.Delete(id);
            return Json(result);
        }
    }
}