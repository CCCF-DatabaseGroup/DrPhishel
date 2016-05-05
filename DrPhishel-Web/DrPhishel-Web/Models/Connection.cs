using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DrPhishel_Web.Models
{
    /*This class is the one that implements the database connection */
    public class Connection
    {
        //public const string CONNECTION_STRING = "workstation id=drphishel.mssql.somee.com;packet size=4096;user id=crisferlop_SQLLogin_1;pwd=iufoc6fjnc;data source=drphishel.mssql.somee.com;persist security info=False;initial catalog=drphishel";
        public const string CONNECTION_STRING = "Data Source=ELBARTO5;Initial Catalog=DrPhishel;Integrated Security=True";
        private SqlConnection SqlConexion;
        private DataTable TablaDatos;
        public List<SqlParameter> _Parametros;
        public bool abrirConexion(string pProcedimiento, List<SqlParameter> pParametros)
        {
            bool conexionStatus = false;
            SqlConexion = new SqlConnection();
            this.TablaDatos = new DataTable();
            try
            {
                SqlConexion.ConnectionString = CONNECTION_STRING;
                SqlConexion.Open();
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = pProcedimiento;
                SqlComando.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parametro in pParametros)
                {
                    SqlComando.Parameters.Add(parametro);
                }
                SqlComando.ExecuteNonQuery();
            
                SqlDataAdapter SqlAdaptadorDatos = new SqlDataAdapter(SqlComando);
                SqlAdaptadorDatos.Fill(TablaDatos);
                SqlComando.Parameters.Clear();
                conexionStatus = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            finally
            {
                SqlConexion.Close();
            }
            return conexionStatus;
        }



        public bool abrirConexionNoRetorno(string pProcedimiento, List<SqlParameter> pParametros)
        {
            bool conexionStatus = false;
            SqlConexion = new SqlConnection();
            this.TablaDatos = new DataTable();
            try
            {
                SqlConexion.ConnectionString = CONNECTION_STRING;
                SqlConexion.Open();
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = pProcedimiento;
                SqlComando.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parametro in pParametros)
                {
                    SqlComando.Parameters.Add(parametro);
                }
                SqlComando.ExecuteNonQuery();
                foreach (SqlParameter parametro in pParametros)
                SqlComando.Parameters.Clear();

                conexionStatus = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            finally
            {
                SqlConexion.Close();
            }
            return conexionStatus;
        }


        public DataTable GetTablaDatos()
        {
            return TablaDatos;
        }
    }
}