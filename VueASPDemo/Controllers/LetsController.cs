using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VueASPDemo.Models.BusinessLogic;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Controllers
{
    public class LetsController : Controller
    {
        // GET: Departmen
        public ActionResult Index()
        {
            return View();
        }

        // ��easyui��ҳ��page��ǰҳ��rowҳ���С������д
        public ActionResult GetData(int page, int rows, LetsModel whereModel)
        {
            int count;
            var lists = LetsBll.GetPageList(page, rows, whereModel, out count);

            return Json(new { rows = lists, total = count }, JsonRequestBehavior.AllowGet);
        }

        // POST: Departmen/Create
        [HttpPost]
        public ActionResult Create(LetsModel model)
        {
            try
            {
                var result = LetsBll.Insert(model);
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
            var model = LetsBll.SelectForID(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // POST: Departmen/Edit/5
        [HttpPost]
        public ActionResult Edit(LetsModel model)
        {
            try
            {
                var result = LetsBll.Update(model);

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
            var result = LetsBll.Delete(id);
            return Json(result);
        }
    }
}