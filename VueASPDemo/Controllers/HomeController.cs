using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VueASPDemo.Models.BusinessLogic;
using VueASPDemo.Models.MyModel;

namespace VueASPDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            Session["user"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string LoginName, string LoginPWD)
        {
            if (UserBLL.Login(LoginName, LoginPWD) != null)
            {
                Session["user"] = UserBLL.Login(LoginName, LoginPWD);
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public ActionResult Main()
        {
            try
            {
                ViewBag.UserName = (Session["user"] as EmpModel).EmpName;
                return View();
            }
            catch (Exception ex)
            {
                return Redirect("Login");
            }
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}