using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DrPhishel_Web.Models
{
    public class Doctor
    {
        private int NumeroDoctor;
        private string NombreDoctor;
        private string Apellido1;
        private string Apellido2;
        private string LugarDeResidencia;
        private int TelefonoConsultorio;
        private string DireccionConsultorio;
        private int IdEspecialidad;
        private int NumeroTarjetaCredito;

        /* Asocia un paciente a un doctor, true si se logró, false si no */
        public static bool AsociarPacienteADoctor(int pIdDoctor, int pIdPaciente)
        {
            List<SqlParameter> parametrosAsocie = new List<SqlParameter>();
            parametrosAsocie.Add(new SqlParameter(CST.SQL_ID_DOCTOR_ASOCIE, pIdDoctor));
            parametrosAsocie.Add(new SqlParameter(CST.SQL_ID_PACIENTE_ASOCIE, pIdPaciente));

            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_ASOCIAR_PACIENTE_DOCTOR, parametrosAsocie))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Solicita la inscripción de un doctor */

    }
}