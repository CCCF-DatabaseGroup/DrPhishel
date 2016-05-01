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
    public class DoctorControllerApi : ApiController
    {

        /* Obtiene todas las citas disponibles para el doctor */
        public IHttpActionResult ObtenerCitasDisponiblesDoctor(int pIdDoctor, string pDia)
        {
            List<string> listaCitas = Citas.ObtenerCitasDisponiblesDoctor(pIdDoctor, pDia);
            return Ok(listaCitas);

        }

        /* Obtiene una lista con el historial clinico de un paciente a partir de su cedula */
        public IHttpActionResult ObtenerHistorialClinicoPaciente (int pCedulaPaciente)
        {
            List<Historial> historialPaciente = Historial.ObtenerHistorialClinicoPaciente(pCedulaPaciente);
            return Ok(historialPaciente);

        }

        /* Asocia un paciente a un doctor, true si se logró, false si no */
        public IHttpActionResult AsociarPacienteADoctor(int pIdDoctor, int pIdPaciente)
        {
            return Ok(Doctor.AsociarPacienteADoctor(pIdDoctor, pIdPaciente));
        }

    }
}
