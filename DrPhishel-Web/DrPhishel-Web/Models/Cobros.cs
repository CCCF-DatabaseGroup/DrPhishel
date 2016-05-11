using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DrPhishel_Web.Models
{
    public class Cobros
    {

        private int cantidadCobro;
        private DateTime fechaCobro;
        private int NumeroDoctor;
        private string NombreDoctor;
        private string ApellidoDoctor;
        private string SegundoApellidoDoctor;


        /* constructor con dos args */
        public Cobros(int pCantidadCobro, DateTime pFechaCobro)
        {
            cantidadCobro = pCantidadCobro;
            fechaCobro = pFechaCobro;
        }

        /* recibe el ID de un doctor y retorna la lista de sus cobros */
        public static List<object> verCobros()
        {
            List<SqlParameter> parametrosCobro = new List<SqlParameter>();
            List<object> listaCobros = new List<object>();
            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_VER_COBRO, parametrosCobro))
            {
                DataTable tablaCobros = conexion.GetTablaDatos();
                Cobros tmp;
                foreach (DataRow fila in tablaCobros.Rows)
                {
                    tmp = new Cobros((int)fila[CST.HEADER_CANT_COBRO], (DateTime)fila[CST.HEADER_FECHA_COBRO]);
                    tmp.NumeroDoctor = (int)fila[CST.HEADER_NUMERO_DOCTOR_COBRO];
                    tmp.NombreDoctor = (string)fila[CST.HEADER_NOMBRE_PERSONA];
                    tmp.ApellidoDoctor = (string)fila[CST.HEADER_PRIMER_APELLIDO];
                    tmp.SegundoApellidoDoctor = (string)fila[CST.HEADER_SEGUNDO_APELLIDO];
                    tmp.fechaCobro.AddMilliseconds(0);
                    listaCobros.Add(tmp.toJson());
                }

            }
            return listaCobros;
        }

        private object toJson()
        {
            return new
            {
                NumeroDoctor = NumeroDoctor,
                cantidadCobro = cantidadCobro,
                fechaCobro = fechaCobro,
                fechaCobroString = fechaCobro.ToShortDateString(),
                NombreDoctor = NombreDoctor,
                ApellidoDoctor = ApellidoDoctor,
                SegundoApellidoDoctor = SegundoApellidoDoctor
            };
        }

        /* toma el id de un doctor y le realiza un cobro */
        public static bool RealizarCobro(int pCostoCita)
        {
            List<SqlParameter> parametrosCobro = new List<SqlParameter>();
            parametrosCobro.Add(new SqlParameter(CST.PARAM_COSTO_CITA, pCostoCita));
            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_REALIZAR_COBRO, parametrosCobro))
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