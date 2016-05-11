using DrPhishel_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrPhishel_Web.Controllers
{
    public class HomeController : Controller
    {

        public class CustomUser
        {
            public int Cedula { get; set; }
            public string Nombre { get; set; }
            public string PrimerApellido { get; set; }
            public string SegundoApellido { get; set; }
            public string FechaNacimiento { get; set; }
            public int Telefono { get; set; }
            public string Direccion { get; set; }
            public string Correo { get; set; }
            public string Contrasena { get; set; }
            public string TipoUsuario { get; set; }
        }


        public const string USUARIO = "usuario";
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            if (Session[USUARIO] != null)
            {
                try
                {
                    CustomUser user = (CustomUser)Session[USUARIO];
                    if (user.TipoUsuario == "Paciente") return Redirect("/Paciente");
                    else if (user.TipoUsuario == "Doctor") return Redirect("/Doctor");
                    else if (user.TipoUsuario == "Administrador") return Redirect("/Administrador");
                    else Session.Remove(USUARIO);
                }
                catch(Exception e)
                {
                }
            }

            return View();
        }
        public ActionResult Registrarse()
        {
            if (Session[USUARIO] != null)
            {

                return Index();
                //return View("Home");
            }
            ViewBag.Title = "Home Page";

            return View();
        }

        /*
        [HttpPost]
        public JsonResult LoginUsuario(string pCorreoElectronico, string pContrasena, int pTipoUsuario)
        {
            object usuario = Usuario.LoginUsuario(pCorreoElectronico, pContrasena, pTipoUsuario);
            return Json(usuario);
        }
        */

        [HttpPost]
        public JsonResult SetUsuario(CustomUser pUsuario)
        {
            bool status = false;
            try
            {
                Session.Add(USUARIO, pUsuario);
                status = true;
            }
            catch (Exception e)
            {
                //return Json(new {Status = false, Error = e.Message}, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Status = status }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Logout()
        {
            Session.Remove(USUARIO);
            return Json(new { Status = true},JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult obtenerMiCedula()
        {
            if(Session[USUARIO] != null)
                return Json(new { Cedula = ((CustomUser)Session[USUARIO]).Cedula }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Cedula = -1 }, JsonRequestBehavior.AllowGet);
        }


    }
}
