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
        private string Fecha { set; get; }
        private string Hora { set; get; }
        private string NombreDoctor { set; get; }
        private string Apellido1Doctor { set; get; }
        private string Apellido2Doctor { set; get; }
        private string Consulta { set; get; }
        private string Estudio { set; get; }
        private string Receta { set; get; }

        /* Constructor con todos los argumentos */
        public Historial(string pFecha, string pHora, string pNombreDoctor, string pApellido1Doctor, string pApellido2Doctor, string pConsulta, string pEstudio, string pReceta)
        {
            Fecha = pFecha;
            Hora = pHora;
            NombreDoctor = pNombreDoctor;
            Apellido1Doctor = pApellido1Doctor;
            Apellido2Doctor = pApellido2Doctor;
            Consulta = pConsulta;
            Estudio = pEstudio;
            Receta = pReceta;
        }

        /* Obtiene el historial clinico de un paciente a partir de su cedula */

        public static List<Historial> ObtenerHistorialClinicoPaciente(int pCedulaPaciente)
        {
            List<SqlParameter> ParametrosHistorial = new List<SqlParameter>();
            ParametrosHistorial.Add(new SqlParameter(CST.PARAM_CEDULA, pCedulaPaciente));

            List<Historial> listaHistorialPaciente = new List<Historial>();
            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_OBTENER_HISTORIAL_CLINICO_PACIENTE, ParametrosHistorial))
            {
                DataTable tablaHistorial = conexion.GetTablaDatos();
                foreach (DataRow fila in tablaHistorial.Rows)
                {
                    listaHistorialPaciente.Add(new Historial((string)fila[CST.SQL_FECHA_CITA], (string)fila[CST.SQL_HORA_CITA], (string)fila[CST.SQL_CONSULTA], (string)fila[CST.SQL_ESTUDIO], (string)fila[CST.SQL_RECETA], (string)fila[CST.SQL_NOMBRE_DOC], (string) fila[CST.SQL_APEL1_DOC], (string) fila[CST.SQL_APEL2_DOC]));
                }

            }
            return listaHistorialPaciente;

        }

    }
}