using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DrPhishel_Web.Models
{
    public class Especialidad
    {
        private int IdAdmin { set; get;} /*quien lo agrega */
        private string NombreEspecialidad { set; get;} 

        /* Constructor con los dos argumentos */
        public Especialidad(int pIdAdmin, string pNombreEspecialidad)
        {
            IdAdmin = pIdAdmin;
            NombreEspecialidad = pNombreEspecialidad;
        }

        /* Obtiene una lista de todas las especialidades de los doctores */
        public static List<object> SolicitarEspecialidades()
        {
            List<object> listaEspecialidades = new List<object>();

            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_SOLICITAR_ESPECIALIDADES, new List<SqlParameter>()))
            {
                DataTable TablaEspecialidades = conexion.GetTablaDatos();
                foreach(DataRow fila in TablaEspecialidades.Rows)
                {
                    listaEspecialidades.Add(
                        (new Especialidad((int)fila[CST.SQL_ID_ESPECIALIDAD], (string)fila[CST.SQL_NOMBRE_ESPECIALIDAD])).toJson()
                        );
                }
            }
            return listaEspecialidades;
        }


        public object toJson() {
            return new {IdEspecialidad = this.IdAdmin, Nombre= this.NombreEspecialidad };
        }

        /* Agrega una especialidad nueva a partir de su nombre, retorna true si se pudo, false si no */
        public bool agregarCategoria()
        {
            List<SqlParameter> parametrosCategoria = new List<SqlParameter>();           
            parametrosCategoria.Add(new SqlParameter(CST.PARAM_ESPECI, this.NombreEspecialidad));
            Connection conexion = new Connection();
            if (conexion.abrirConexionNoRetorno(CST.PROC_ALMACENADO_AGREGAR_CATEGORIA, parametrosCategoria))
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