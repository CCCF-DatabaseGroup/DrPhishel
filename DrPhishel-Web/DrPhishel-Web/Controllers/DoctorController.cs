using DrPhishel_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrPhishel_Web.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            if (Session[HomeController.USUARIO] != null)
            {
                HomeController.CustomUser user = (HomeController.CustomUser)Session[HomeController.USUARIO];
                if (user.TipoUsuario == "Doctor") return View();
            }
            return Redirect("/Home");
        }

        public ActionResult AgregarPaciente()
        {
            if (Session[HomeController.USUARIO] != null)
            {
                HomeController.CustomUser user = (HomeController.CustomUser)Session[HomeController.USUARIO];
                if (user.TipoUsuario == "Doctor") return View();
            }
            return Redirect("/Home");
        }

        public ActionResult VerCalendario()
        {
            if (Session[HomeController.USUARIO] != null)
            {
                HomeController.CustomUser user = (HomeController.CustomUser)Session[HomeController.USUARIO];
                if (user.TipoUsuario == "Doctor") return View();
            }
            return Redirect("/Home");
        }

        public ActionResult AgregarHistorialClinico()
        {
            if (Session[HomeController.USUARIO] != null)
            {
                HomeController.CustomUser user = (HomeController.CustomUser)Session[HomeController.USUARIO];
                if (user.TipoUsuario == "Doctor") return View();
            }
            return Redirect("/Home");
        }

        public ActionResult EditarHistorialClinico()
        {
            if (Session[HomeController.USUARIO] != null)
            {
                HomeController.CustomUser user = (HomeController.CustomUser)Session[HomeController.USUARIO];
                if (user.TipoUsuario == "Doctor") return View();
            }
            return Redirect("/Home");
        }



        public JsonResult InsertarHistorialClinico(int pIdCita, string pConsulta, string pEstudios)
        {
            bool historial = Historial.InsertarHistorialClinico(pIdCita, pConsulta, pEstudios);
            return Json(new {Status =  historial }, JsonRequestBehavior.AllowGet);
        }

    }

}