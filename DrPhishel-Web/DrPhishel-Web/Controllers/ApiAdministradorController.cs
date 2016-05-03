using DrPhishel_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DrPhishel_Web.Controllers
{
    public class ApiAdministradorController : ApiController
    {


        [HttpGet]
        /*  Obtiene una lista de todas las especialidades */
        public IHttpActionResult SolicitarEspecialidades()
        {
            System.Diagnostics.Debug.WriteLine("Se esta llamando al web api");
            return Json(Especialidad.SolicitarEspecialidades().ToList());
        }


    }
}
