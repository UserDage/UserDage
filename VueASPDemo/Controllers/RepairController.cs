using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VueASPDemo.Models.BusinessLogic;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Controllers
{
    public class RepairController : Controller
    {
        // GET: Departmen
        public ActionResult Index()
        {
            return View();
        }

        // 用easyui分页，page当前页，row页面大小不能乱写
        public ActionResult GetData(int page, int rows, RepairModel whereModel)
        {
            int count;
            var lists = RepairBll.GetPageList(page, rows, whereModel, out count);

            return Json(new { rows = lists, total = count }, JsonRequestBehavior.AllowGet);
        }

        // POST: Departmen/Create
        [HttpPost]
        public ActionResult Create(RepairModel model)
        {
            try
            {
                var result = RepairBll.Insert(model);
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
            var model = RepairBll.SelectForID(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // POST: Departmen/Edit/5
        [HttpPost]
        public ActionResult Edit(RepairModel model)
        {
            try
            {
                var result = RepairBll.Update(model);

                return Json(result);
            }
            catch
            {
                return Json(false);
            }
        }

        // 删除数据

        public ActionResult Delete(int id)
        {
            var result = RepairBll.Delete(id);
            return Json(result);
        }
    }
}