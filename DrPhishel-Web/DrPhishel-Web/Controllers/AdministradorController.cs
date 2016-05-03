using DrPhishel_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrPhishel_Web.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Index()
        {
            return View("~/Views/Administrador/Index.cshtml");
        }
        public ActionResult AgregarEspecialidad()
        {
            return View();
        }
        public ActionResult AgregarDoctor()
        {
            return View();
        }
        public ActionResult AgregarPaciente()
        {
            return View();
        }

        [HttpPost]
        /* Se encarga de agregar una especialidad nueva, retorna un estado true si se logro uno false si no */
        public JsonResult AgregarEspecialidadDoctor(string pNombreCategoria)
        {
            Especialidad nuevaEspecialidad = new Especialidad(0,pNombreCategoria); /* Se pone 0 ya que el ID se agrega automaticamente */
            bool agregado = nuevaEspecialidad.agregarCategoria();
            return Json( new { Status = agregado }, JsonRequestBehavior.AllowGet);

        }



    }
}