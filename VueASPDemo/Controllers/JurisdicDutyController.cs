using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VueASPDemo.Models.BusinessLogic;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Controllers
{
    public class JurisdicDutyController : Controller
    {
        // GET: Departmen
        public ActionResult Index()
        {
            return View();
        }

        // ��easyui��ҳ��page��ǰҳ��rowҳ���С������д
        public ActionResult GetData(int page, int rows, JurisdicDutyModel whereModel)
        {
            int count;
            var lists = JurisdicDutyBll.GetPageList(page, rows, whereModel, out count);

            return Json(new { rows = lists, total = count }, JsonRequestBehavior.AllowGet);
        }

        // POST: Departmen/Create
        [HttpPost]
        public ActionResult Create(JurisdicDutyModel model)
        {
            try
            {
                var result = JurisdicDutyBll.Insert(model);
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
            var model = JurisdicDutyBll.SelectForID(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // POST: Departmen/Edit/5
        [HttpPost]
        public ActionResult Edit(JurisdicDutyModel model)
        {
            try
            {
                var result = JurisdicDutyBll.Update(model);

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
            var result = JurisdicDutyBll.Delete(id);
            return Json(result);
        }
    }
}