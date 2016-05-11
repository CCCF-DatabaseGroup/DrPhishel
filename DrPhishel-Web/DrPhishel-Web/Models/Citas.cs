using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DrPhishel_Web.Models
{
    public class Citas
    {
        private int IdCita { get; set; }
        private int NumeroDoctor { get; set; }
        private int CedulaPaciente { get; set; }
        private string fechaCita { get; set; }
        private string horaCita { get; set; }

        /* Constructor que crea una cita con todos sus parametros */
        public Citas(int pIdCita, int pNumeroDoctor, int pCedulaPaciente, string pFechaCita, string pHoraCita)
        {
            IdCita = pIdCita;
            NumeroDoctor = pNumeroDoctor;
            CedulaPaciente = pCedulaPaciente;
            fechaCita = pFechaCita;
            horaCita = pHoraCita;               
        }

        /*  Constructor para crear un objeto cita sin ID */
        public Citas(int pNumeroDoctor, int pCedulaPaciente, string pFechaCita, string pHoraCita)
        {
            IdCita = 0;
            NumeroDoctor = pNumeroDoctor;
            CedulaPaciente = pCedulaPaciente;
            fechaCita = pFechaCita;
            horaCita = pHoraCita;
        }

        /* Constructor por defecto */
        public Citas()
        {
            IdCita = 0;
            NumeroDoctor = 0;
            CedulaPaciente = 0;
            fechaCita = "";
            horaCita = "";
        }
        
        /*  pide la cita para el paciente
            retorna true si la cita se pidió
            false si no se pudo pedir   */

        public bool crearCita()
        {
            List<SqlParameter> ParametrosCita = new List<SqlParameter>();
            ParametrosCita.Add(new SqlParameter(CST.PARAM_DOCT, this.NumeroDoctor));
            ParametrosCita.Add(new SqlParameter(CST.PARAM_CEDULA, this.CedulaPaciente));
            ParametrosCita.Add(new SqlParameter(CST.PARAM_FECHA_MINUS, this.fechaCita));
            ParametrosCita.Add(new SqlParameter(CST.PARAM_HORA, this.horaCita));

            Connection conexion = new Connection();
            if (conexion.abrirConexionNoRetorno(CST.PROC_ALMACENADO_PEDIR_CITA, ParametrosCita))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /*  recibe el dia y el id del doctor y obtiene todas las citas para ese día */
        public static List<string> ObtenerCitasDisponiblesDoctor(int pIdDoctor, DateTime pDia)
        {
            List<SqlParameter> ParametrosObtenerCita = new List<SqlParameter>();
            ParametrosObtenerCita.Add(new SqlParameter(CST.PARAM_ID_DOCTOR, pIdDoctor));
            ParametrosObtenerCita.Add(new SqlParameter(CST.PARAM_FECHA_MAYUS, pDia));

            Connection conexion = new Connection();
            List<string> ListaCitas = new List<string>();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_OBTENER_CITAS_DISP_DOC, ParametrosObtenerCita))
            {

                DataTable TablaCitas = conexion.GetTablaDatos();
                foreach (DataRow fila in TablaCitas.Rows)
                {
                    ListaCitas.Add( ((TimeSpan)fila[CST.HEADER_HORAS_DISP]).ToString());
                }
        
            }
            return ListaCitas;
        }

        public static List<object> ObtenerCitasPaciente(int pCedula) {
            List<SqlParameter> ParametrosObtenerCita = new List<SqlParameter>();
            ParametrosObtenerCita.Add(new SqlParameter(CST.PARAM_CEDULA, pCedula));

            Connection conexion = new Connection();
            List<object> ListaCitas = new List<object>();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_CITAS_PACIENTE, ParametrosObtenerCita))
            {

                DataTable TablaCitas = conexion.GetTablaDatos();
                foreach (DataRow fila in TablaCitas.Rows)
                {
                    ListaCitas.Add(new
                    {
                        HoraCita = ((TimeSpan)fila[CST.SQL_HORA_CITA]).ToString(),
                        IdCita = ((int)fila[CST.HEADER_ID_CITA])
                    }
                    );
                }

            }
            return ListaCitas;
        }


        public static List<object> ObtenerCitasDoctor(int pCedula,DateTime pDia)
        {
            List<SqlParameter> ParametrosObtenerCita = new List<SqlParameter>();
            ParametrosObtenerCita.Add(new SqlParameter(CST.PARAM_CEDULA, pCedula));
            ParametrosObtenerCita.Add(new SqlParameter(CST.PARAM_FECHA_MINUS, pDia));
            Connection conexion = new Connection();
            List<object> ListaCitas = new List<object>();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_CITAS_DOCTORES, ParametrosObtenerCita))
            {

                DataTable TablaCitas = conexion.GetTablaDatos();
                foreach (DataRow fila in TablaCitas.Rows)
                {
                    ListaCitas.Add(new {
                        HorasCita = ((TimeSpan)fila[CST.SQL_HORA_CITA]).ToString(),
                        NombrePaciente = ((String)fila[CST.HEADER_NOMBRE_PERSONA]),
                        PrimerApellidoPaciente = ((String)fila[CST.HEADER_PRIMER_APELLIDO]),
                        SegundoApellidoPaciente = (String)fila[CST.HEADER_SEGUNDO_APELLIDO],
                        IdCita = ((int)fila[CST.HEADER_ID_CITA])
                    });
                }

            }
            return ListaCitas;
        }



        /* Elimina una cita por el Id de la cita y al cedula del paciente, si se logra 
        eliminar retorna verdadero, sino falso */
        public static bool EliminarCita(int pIdCita)
        {
            List<SqlParameter> ParametrosEliminarCita = new List<SqlParameter>();
            ParametrosEliminarCita.Add(new SqlParameter(CST.PARAM_ID_CITA, pIdCita));

            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_ELIMINAR_CITA, ParametrosEliminarCita))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*  Cambia la fecha u hora de la cita por una fecha nueva o una hora nueva */
        public bool CambiarHoraCita ()
        {
            List<SqlParameter> ParametrosCambiarCita = new List<SqlParameter>();
            ParametrosCambiarCita.Add(new SqlParameter(CST.PARAM_ID_CITA, this.IdCita));
            ParametrosCambiarCita.Add(new SqlParameter(CST.PARAM_NUM_DOCTOR, this.CedulaPaciente));
            ParametrosCambiarCita.Add(new SqlParameter(CST.PARAM_FECHA_MINUS, this.fechaCita));
            ParametrosCambiarCita.Add(new SqlParameter(CST.PARAM_HORA, this.horaCita));
            ParametrosCambiarCita.Add(new SqlParameter(CST.PARAM_EXITO, 0));

            Connection conexion = new Connection();

            if (conexion.abrirConexion(CST.PROC_ALMACENADO_CAMBIAR_HORA_CITA, ParametrosCambiarCita))
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