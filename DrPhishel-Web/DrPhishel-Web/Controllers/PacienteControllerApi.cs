using DrPhishel_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DrPhishel_Web.Controllers
{
    public class PacienteControllerApi : ApiController
    {

        /*  Llama al metodo de eliminación de citas, si se logra eliminar retorna true sino false */
        public IHttpActionResult EliminarCita (int pIdCita)
        {
            return Ok(Citas.EliminarCita(pIdCita));      
        }

        /* recibe la cedula del paciente y el id de la cita por cambiar ademas de la nueva hora y la nueva fecha
        retorna true si se pudo cambiar, false si no */

        public IHttpActionResult cambiarHoraCita (int pCedulaPaciente, int pIdCita, string pFechaNueva, string pHoraNueva)
        {
            Citas citaNuevaHora = new Citas(pIdCita, 0, pCedulaPaciente, pFechaNueva, pHoraNueva);
            bool cambio = citaNuevaHora.CambiarHoraCita();
            return Ok(cambio);
        }

    }

}
