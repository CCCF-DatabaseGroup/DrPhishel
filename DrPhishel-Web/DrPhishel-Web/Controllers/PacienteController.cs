using DrPhishel_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrPhishel_Web.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult Index()
        {
            return View("~/Views/Paciente/Index.cshtml");
        }

        // GET: Paciente
        public ActionResult ReservarCita()
        {
            return View();
        }


        // GET: Paciente
        public ActionResult VerHistorialClinico()
        {
            return View();
        }





        // GET: Paciente
        public ActionResult DatosPersonales()
        {
            return View();
        }


        [HttpPost]
        /* Crea la cita del paciente,retorna true si se creo, false si no se pudo crear */
        public JsonResult CrearCita (int pCedulaPaciente, string pFecha, string pHora, int pNumeroDoctor)
        {
            Citas cita = new Citas(pNumeroDoctor, pCedulaPaciente, pFecha, pHora);
            if (cita.crearCita())
            {
                return Json(new { Status = true } , JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = false }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}