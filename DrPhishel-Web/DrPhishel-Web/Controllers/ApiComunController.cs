using DrPhishel_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DrPhishel_Web.Controllers
{
    public class ApiComunController : ApiController
    {

        [HttpPost]
        public IHttpActionResult RegistrarUsuario(int pCedula, string pNombre, string pPrimerApellido, string pSegundoApellido,
            string pFechaNacimiento, int pTelefono, string pDireccion, string pCorreo, string pContrasena)
        {
            Usuario usuarioACrear = new Usuario(
                pCedula, pNombre, pPrimerApellido, pSegundoApellido, pFechaNacimiento, pTelefono, pDireccion, pCorreo, pContrasena

            );
            usuarioACrear.crearUsuario();
            return Json (new { Status =  true });

        }
        



        [HttpGet]
        public IHttpActionResult ObtenerUsuario(int pCedula)
        {
            return Json(Usuario.obtenerUsuarioPorCedula(pCedula));
        }


        [HttpGet]
        public IHttpActionResult ObtenerHistorialClinico(int pCedula) {
            List<object> historial = Historial.ObtenerHistorialClinicoPaciente(pCedula);
            return Json(historial.ToList());
        }

        [HttpPost]
        public IHttpActionResult LoginUsuario(string pCorreoElectronico, string pContrasena, int pTipoUsuario)
        {
            object usuario = Usuario.LoginUsuario(pCorreoElectronico,pContrasena, pTipoUsuario);
            return Json(usuario);
        }


        [HttpPost]
        /* insertar un doctor temporalmente*/
        public IHttpActionResult SolicitudDoctor(int pCedulaUsuario, int pNumeroDoctor, int pIdEspecialidad, int pTelefono, int pNumeroDeTarjeta, string pDireccion)
        {
            bool insertado = Doctor.SolicitudDoctor(pCedulaUsuario,pNumeroDoctor, pIdEspecialidad, pTelefono, pNumeroDeTarjeta, pDireccion);
            return Json(new { Status = insertado });
        }



    }
}
