using DrPhishel_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace DrPhishel_Web.Controllers
{
    public class ApiDoctorController : ApiController
    {


        [HttpGet]
        /* Obtiene una lista con el historial clinico de un paciente a partir de su cedula */
        public IHttpActionResult ObtenerHistorialClinicoPaciente (int pCedulaPaciente)
        {
            List<object> historialPaciente = Historial.ObtenerHistorialClinicoPaciente(pCedulaPaciente);
            return Json(historialPaciente);

        }

        [HttpPost]
        /* Asocia un paciente a un doctor, true si se logró, false si no */
        public IHttpActionResult AsociarPacienteADoctor(int pNumeroDoctor, int pCedulaPaciente)
        {
            return Ok(Doctor.AsociarPacienteADoctor(pNumeroDoctor, pCedulaPaciente));
        }

    }
}
