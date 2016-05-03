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
        private string fechaCobro;

        /* constructor con dos args */
        public Cobros(int pCantidadCobro, string pFechaCobro)
        {
            cantidadCobro = pCantidadCobro;
            fechaCobro = pFechaCobro;
        }

        /* recibe el ID de un doctor y retorna la lista de sus cobros */
        public static List<Cobros> verCobros(int pidDoctor)
        {
            List<SqlParameter> parametrosCobro = new List<SqlParameter>();
            parametrosCobro.Add(new SqlParameter(CST.PARAM_ID_DOCTOR, pidDoctor));
            List<Cobros> listaCobros = new List<Cobros>();
            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_VER_COBRO, parametrosCobro))
            {
                DataTable tablaCobros = conexion.GetTablaDatos();
                foreach (DataRow fila in tablaCobros.Rows)
                {
                    listaCobros.Add(new Cobros((int)fila[CST.HEADER_CANT_COBRO], (string)fila[CST.HEADER_FECHA_COBRO]));
                }
            }
            return listaCobros;
        }

        /* toma el id de un doctor y le realiza un cobro */
        public static bool RealizarCobro(int pIdDoctor) 
        {
            List<SqlParameter> parametrosCobro = new List<SqlParameter>();
            parametrosCobro.Add(new SqlParameter(CST.PARAM_NUM_DOCTOR, pidDoctor));
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