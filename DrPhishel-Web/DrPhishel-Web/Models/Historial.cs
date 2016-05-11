using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DrPhishel_Web.Models
{
    public class Historial
    {
        private DateTime Fecha { set; get; }
        private TimeSpan Hora { set; get; }
        private string NombreDoctor { set; get; }
        private string Apellido1Doctor { set; get; }
        private string Apellido2Doctor { set; get; }
        private string Consulta { set; get; }
        private string Estudio { set; get; }

        /* Constructor con todos los argumentos */
        public Historial(DateTime pFecha, TimeSpan pHora, string pNombreDoctor, string pApellido1Doctor, string pApellido2Doctor, string pConsulta, string pEstudio)
        {
            Fecha = pFecha;
            Hora = pHora;
            NombreDoctor = pNombreDoctor;
            Apellido1Doctor = pApellido1Doctor;
            Apellido2Doctor = pApellido2Doctor;
            Consulta = pConsulta;
            Estudio = pEstudio;
        }

        /* Obtiene el historial clinico de un paciente a partir de su cedula */

        public static List<object> ObtenerHistorialClinicoPaciente(int pCedulaPaciente)
        {
            List<SqlParameter> ParametrosHistorial = new List<SqlParameter>();
            ParametrosHistorial.Add(new SqlParameter(CST.PARAM_CEDULA, pCedulaPaciente));

            List<object> listaHistorialPaciente = new List<object>();
            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_OBTENER_HISTORIAL_CLINICO_PACIENTE, ParametrosHistorial))
            {
                DataTable tablaHistorial = conexion.GetTablaDatos();
                foreach (DataRow fila in tablaHistorial.Rows)
                {
                    listaHistorialPaciente.Add((new Historial(
                        (DateTime)fila[CST.SQL_FECHA_CITA], 
                        (TimeSpan)fila[CST.SQL_HORA_CITA], 
                        (string)fila[CST.SQL_NOMBRE_DOC], 
                        (string) fila[CST.SQL_APEL1_DOC], 
                        (string) fila[CST.SQL_APEL2_DOC],
                        (string)fila[CST.SQL_CONSULTA],
                        (string)fila[CST.SQL_ESTUDIO] )).toJson());
                }

            }
            return listaHistorialPaciente;

        }



        /* inserta una nueva entrada en el historial clínico retorna true si fue posible */
        public static bool InsertarHistorialClinico(int pIdCita, string pConsulta, string pEstudios)
        {
            List<SqlParameter> ParametrosHistorial = new List<SqlParameter>();
            ParametrosHistorial.Add(new SqlParameter(CST.PARAM_ID_CITA, pIdCita));
            ParametrosHistorial.Add(new SqlParameter(CST.PARAM_CONSULTA, pConsulta));
            ParametrosHistorial.Add(new SqlParameter(CST.PARAM_ESTUDIOS, pEstudios));
            Connection conexion = new Connection();
            if (conexion.abrirConexionNoRetorno(CST.PROC_ALMACENADO_INSERTAR_HISTORIAL_CLINICO, ParametrosHistorial))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public object toJson() {
            return new {
                Fecha = Fecha,
            Hora = Hora,
            NombreDoctor = NombreDoctor,
            Apellido1Doctor = Apellido1Doctor,
            Apellido2Doctor = Apellido2Doctor,
            Consulta = Consulta,
            Estudio = Estudio,
        };
        }

    }
}