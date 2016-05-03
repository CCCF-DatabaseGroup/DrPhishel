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
        public static bool AsociarPacienteADoctor(int pCedulaDoctor, int pCedulaCliente)
        {
            List<SqlParameter> parametrosAsocie = new List<SqlParameter>();
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_CED_DOC, pCedulaDoctor));
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_CED_CLIENTE, pCedulaCliente));

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


        /* Acepta la inscripción de un doctor */

        public static bool AceptarDoctor (int pIdDoctor)
        {
            List<SqlParameter> parametrosAceptar = new List<SqlParameter>();
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_ID_USUARIO, pIdDoctor));
            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_ACEPTAR_DOCTOR, parametrosAceptar))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Solicita insertar un doctor nuevo */
        public static bool SolicitudDoctor(int pNumeroDoctor, int pIdEspecialidad, int pTelefono, int pNumeroDeTarjeta, string pDireccion)
        {
            List<SqlParameter> parametrosAceptar = new List<SqlParameter>();
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_NUM_DOCTOR, pNumeroDoctor));
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_ID_ESPE, pIdEspecialidad));
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_TEL, pTelefono));
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_NUM_TARJETA, pNumeroDeTarjeta));
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_DIREC, pDireccion));
            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_INSERTAR_DOC, parametrosAceptar))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}