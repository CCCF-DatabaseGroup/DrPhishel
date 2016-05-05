using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrPhishel_Web.Controllers
{
    public class HomeController : Controller
    {

        public const string USUARIO = "usuario";
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            if (Session[USUARIO] != null) {
                return Redirect("/Paciente");
            } 

            return View();
        }
        public ActionResult Registrarse()
        {
            if (Session[USUARIO] != null) {

                return Index();
                //return View("Home");
            }
            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpPost]
        public JsonResult SetUsuario() {
            Session.Add(USUARIO,1);
            return Json(null,JsonRequestBehavior.AllowGet);
        }

    }
}
