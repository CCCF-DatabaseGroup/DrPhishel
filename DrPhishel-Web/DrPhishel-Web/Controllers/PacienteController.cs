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
            if (Session[HomeController.USUARIO] != null)
            {
                HomeController.CustomUser user = (HomeController.CustomUser)Session[HomeController.USUARIO];
                if (user.TipoUsuario == "Paciente") return View();
            }
            return Redirect("/Home");
        }

        // GET: Paciente
        public ActionResult ReservarCita()
        {
            if (Session[HomeController.USUARIO] != null)
            {
                HomeController.CustomUser user = (HomeController.CustomUser)Session[HomeController.USUARIO];
                if (user.TipoUsuario == "Paciente") return View();
            }
            return Redirect("/Home");
        }


        // GET: Paciente
        public ActionResult VerHistorialClinico()
        {
            if (Session[HomeController.USUARIO] != null)
            {
                HomeController.CustomUser user = (HomeController.CustomUser)Session[HomeController.USUARIO];
                if (user.TipoUsuario == "Paciente") return View();
            }
            return Redirect("/Home");
        }





        // GET: Paciente
        public ActionResult DatosPersonales()
        {
            if (Session[HomeController.USUARIO] != null)
            {
                HomeController.CustomUser user = (HomeController.CustomUser)Session[HomeController.USUARIO];
                if (user.TipoUsuario == "Paciente") return View();
            }
            return Redirect("/Home");
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