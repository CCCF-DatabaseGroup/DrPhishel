using DrPhishel_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DrPhishel_Web.Controllers
{
    public class AdministradorControllerApi : ApiController
    {

        /*  Obtiene una lista de todas las especialidades */
        public IHttpActionResult SolicitarEspecialidades()
        {
            return Ok(Especialidad.SolicitarEspecialidades());
        }

    }
}
