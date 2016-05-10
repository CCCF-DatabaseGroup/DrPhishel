using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DrPhishel_Web.Models
{
    public class Receta
    {

        private string nombreMedicamento { set; get; }
        private int cantidadMedicamento { set; get; }
        private string observacionesMedicamento { set; get; }

        /* constructor con todos los args */
        public Receta (string pNombreMed, int pCantidadMed, string pObservaciones)
        {
            nombreMedicamento = pNombreMed;
            cantidadMedicamento = pCantidadMed;
            observacionesMedicamento = pObservaciones;
        }

        /* Obtiene los productos de una receta */
        public static List<object> ObtenerProductosDeReceta(int pIdCita)
        {
            List<object> listaDeRecetas = new List<object>();
            List<SqlParameter> parametrosReceta = new List<SqlParameter>();
            parametrosReceta.Add(new SqlParameter(CST.PARAM_ID_CITA, pIdCita));
            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_OBT_PROD_REC, parametrosReceta))
            {
                DataTable TablaCitas = conexion.GetTablaDatos();
                foreach (DataRow fila in TablaCitas.Rows)
                {
                    listaDeRecetas.Add(new Receta
                        ((string) fila [CST.HEADER_NOM_MEDIC],
                        (int) fila[CST.HEADER_CANT_MR],
                        (string)fila[CST.HEADER_OBSERVA_MR] ).toJson());
                }

            }
            return listaDeRecetas;
        }

        public object toJson()
        {
            return new
            {
                nombreMedicamento = nombreMedicamento,
                cantidadMedicamento = cantidadMedicamento,
                observacionesMedicamento = observacionesMedicamento
            };
        }
    }
}