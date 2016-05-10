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
            return View("~/Views/Doctor/Index.cshtml");
        }

        public ActionResult AgregarPaciente()
        {
            return View();
        }

        public ActionResult VerCalendario()
        {
            return View();
        }

        public ActionResult AgregarHistorialClinico()
        {
            return View();
        }

        public ActionResult EditarHistorialClinico()
        {
            return View();
        }

        public JsonResult InsertarHistorialClinico(int pIdCita, string pConsulta, string pEstudios)
        {
            bool insertado = Historial.InsertarHistorialClinico(pIdCita, pConsulta, pEstudios);
            return Json(new { Status = insertado }, JsonRequestBehavior.AllowGet);
        }
    }

}