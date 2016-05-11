using System;
using System.Collections.Generic;
using System.Data;
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
        private string NombreEspecialidad;
        private int NumeroTarjetaCredito;

        /* Asocia un paciente a un doctor, true si se logró, false si no */
        public static bool AsociarPacienteADoctor(int pNumeroDoctor, int pCedulaCliente)
        {
            List<SqlParameter> parametrosAsocie = new List<SqlParameter>();
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_NUMERO_DOCTOR, pNumeroDoctor));
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_CEDULA_PACIENTE, pCedulaCliente));

            Connection conexion = new Connection();
            if (conexion.abrirConexionNoRetorno(CST.PROC_ALMACENADO_ASOCIAR_PACIENTE_DOCTOR, parametrosAsocie))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /* Acepta la inscripción de un doctor */

        public static bool AceptarDoctor(int pNumeroDoctor)
        {
            List<SqlParameter> parametrosAceptar = new List<SqlParameter>();
            parametrosAceptar.Add(new SqlParameter(CST.PARAM_NUMERO_DOCTOR, pNumeroDoctor));
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
        public static bool SolicitudDoctor(int pCedulaUsuario, int pNumeroDoctor, int pIdEspecialidad, int pTelefono, int pNumeroDeTarjeta, string pDireccion)
        {
            List<SqlParameter> parametrosAsocie = new List<SqlParameter>();
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_CEDULA, pCedulaUsuario));
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_NUM_DOCTOR, pNumeroDoctor));
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_ID_ESPE, pIdEspecialidad));
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_TEL, pTelefono));
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_NUM_TARJETA, pNumeroDeTarjeta));
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_DIREC, pDireccion));
            Connection conexion = new Connection();
            if (conexion.abrirConexionNoRetorno(CST.PROC_ALMACENADO_INSERTAR_DOC, parametrosAsocie))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<object> VerSolicitudDoctor()
        {
            List<SqlParameter> parametrosAsocie = new List<SqlParameter>();
            List<object> solicitudes = new List<object>();
            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_VER_SOLICITUD_DOCTOR, parametrosAsocie))
            {
                foreach(DataRow fila in conexion.GetTablaDatos().Rows)
                {
                    Doctor dr = new Doctor();
                    dr.NumeroDoctor = (int)fila[CST.HEADER_NUMERO_DOCTOR_DT];
                    dr.NombreDoctor = (string)fila[CST.HEADER_NOMBRE_PERSONA];
                    dr.Apellido1 = (string)fila[CST.HEADER_PRIMER_APELLIDO];
                    dr.Apellido2 = (string)fila[CST.HEADER_SEGUNDO_APELLIDO];
                    //dr.LugarDeResidencia = (string)fila[CST.HEADER_DIRECCION_CONSULTORIO_DT];
                    dr.TelefonoConsultorio = (int)fila[CST.HEADER_NUMERO_TELEFONO_CONSULTORIO_DT];
                    dr.DireccionConsultorio = (string)fila[CST.HEADER_DIRECCION_CONSULTORIO_DT];
                    dr.NombreEspecialidad = (string)fila[CST.HEADER_NOMBRE_ESPECIALIDAD];
                    dr.NumeroTarjetaCredito = (int)fila[CST.HEADER_NUMERO_TARJETA_CREDITO];
                    solicitudes.Add(dr.toJson());
                }
                return solicitudes;
            }
            else
            {
                return solicitudes;
            }
        }



        public static List<object> VerDoctoresDePaciente(int pCedula)
        {
            List<SqlParameter> parametrosAsocie = new List<SqlParameter>();
            parametrosAsocie.Add(new SqlParameter(CST.PARAM_CEDULA,pCedula));
            List<object> misDoctores = new List<object>();
            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_VER_MIS_DOCTOR, parametrosAsocie))
            {
                foreach (DataRow fila in conexion.GetTablaDatos().Rows)
                {
                    Doctor dr = new Doctor();
                    dr.NumeroDoctor = (int)fila[CST.HEADER_NUMERO_DOCTOR_DP];
                    dr.NombreDoctor = (string)fila[CST.HEADER_NOMBRE_PERSONA];
                    dr.Apellido1 = (string)fila[CST.HEADER_PRIMER_APELLIDO];
                    dr.Apellido2 = (string)fila[CST.HEADER_SEGUNDO_APELLIDO];
                    dr.NombreEspecialidad = (string)fila[CST.HEADER_NOMBRE_ESPECIALIDAD];
                    misDoctores.Add(dr.toJson());
                }
                return misDoctores;
            }
            else
            {
                return misDoctores;
            }
        }


        public object toJson()
        {
            return new
            {
                NumeroDoctor = NumeroDoctor,
                NombreDoctor = NombreDoctor,
                PrimerApellido = Apellido1,
                SegundoApellido = Apellido2,
                TelefonoConsultorio = TelefonoConsultorio,
                DireccionConsultorio = DireccionConsultorio,
                NombreEspecialidad = NombreEspecialidad,
                NumeroTarjetaCredito = NumeroTarjetaCredito
            };
        }


    }
}