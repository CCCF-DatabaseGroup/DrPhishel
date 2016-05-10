using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DrPhishel_Web.Models
{
    public class Usuario
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string FechaNacimiento { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string TipoUsuario{ get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaTmp { get; set; }


        public Usuario(int pCedula, string pNombre, string pPrimerApellido, string pSegundoApellido,
            string pFechaNacimiento, int pTelefono, string pDireccion, string pCorreo, string pContrasena) {
            Cedula = pCedula;
            Nombre = pNombre;
            PrimerApellido = pPrimerApellido;
            SegundoApellido = pSegundoApellido;
            FechaNacimiento = pFechaNacimiento;
            Telefono = pTelefono;
            Direccion = pDireccion;
            Correo = pCorreo;
            Contrasena = pContrasena;

        }



        public void crearUsuario() {
            DateTime dt = DateTime.Parse("29-03-1995");

            List<SqlParameter> parametroUsuario = new List<SqlParameter>();
            parametroUsuario.Add(new SqlParameter(CST.PARAM_CEDULA,this.Cedula));
            parametroUsuario.Add(new SqlParameter(CST.PARAM_NOMBRE, this.Nombre));
            parametroUsuario.Add(new SqlParameter(CST.PARAM_APELL1, this.PrimerApellido));
            parametroUsuario.Add(new SqlParameter(CST.PARAM_APELL2, this.SegundoApellido));
            parametroUsuario.Add(new SqlParameter(CST.PARAM_FECHA_NAC, this.FechaNacimiento));
            parametroUsuario.Add(new SqlParameter(CST.PARAM_TEL, this.Telefono));
            parametroUsuario.Add(new SqlParameter(CST.PARAM_DIREC, this.Direccion));
            parametroUsuario.Add(new SqlParameter(CST.PARAM_CORREO, this.Correo));
            parametroUsuario.Add(new SqlParameter(CST.PARAM_CONTRA, this.Contrasena));
            Connection conexion = new Connection();
            if (conexion.abrirConexionNoRetorno(CST.PROC_ALMACENADO_REGISTRAR_USUARIO,parametroUsuario))
            {

            }
            else {

            }


        }


        public object toJson() {
            return new
            {
                Cedula = this.Cedula,
                Nombre = this.Nombre,
                PrimerApellido = this.PrimerApellido,
                SegundoApellido = this.SegundoApellido,
                FechaNacimiento = this.FechaTmp,
                Telefono = this.Telefono,
                Direccion = this.Direccion,
                Correo = this.Correo,
                Contrasena = this.Contrasena,
                TipoUsuario = this.TipoUsuario
            };
        }


        public static object obtenerUsuarioPorCedula(int pCedula)
        {
            List<SqlParameter> parametroUsuario = new List<SqlParameter>();
            parametroUsuario.Add(new SqlParameter(CST.SQL_CEDULA,pCedula));
            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_OBTENER_USUARIO, parametroUsuario))
            {
                foreach(DataRow usuario in conexion.GetTablaDatos().Rows)
                {
                    DateTime tmp = (DateTime)usuario[CST.HEADER_FECHA_NACIMIENTO];
                    Usuario UsuarioRetorno = new Usuario(
                        (int)usuario[CST.HEADER_CEDULA],
                        (string)usuario[CST.HEADER_NOMBRE_PERSONA],
                        (string)usuario[CST.HEADER_PRIMER_APELLIDO],
                        (string)usuario[CST.HEADER_SEGUNDO_APELLIDO],
                        (tmp.Day + "/" + tmp.Month + "/" + tmp.Year ).ToString(),
                        (int)usuario[CST.HEADER_TELEFONO_PERSONA],
                        (string)usuario[CST.HEADER_DIRECCION_PERSONA],
                        (string)usuario[CST.HEADER_CORREO_ELECTRONICO],
                        ""
                        );
                    UsuarioRetorno.FechaTmp = tmp;
                    return UsuarioRetorno.toJson();
                }
            }
            else {

            }

            return null;
        }


        public static object LoginUsuario(string pCorreoElectronico,string pContrasena, int pTipo)
        {
            List<SqlParameter> parametroUsuario = new List<SqlParameter>();
            parametroUsuario.Add(new SqlParameter(CST.PARAM_CORREO, pCorreoElectronico));
            parametroUsuario.Add(new SqlParameter(CST.PARAM_CONTRA, pContrasena));
            parametroUsuario.Add(new SqlParameter(CST.PARAM_TIPO_USUARIO, pTipo));
            Connection conexion = new Connection();
            if (conexion.abrirConexion(CST.PROC_ALMACENADO_LOGEAR_USUARIO, parametroUsuario))
            {
                foreach (DataRow usuario in conexion.GetTablaDatos().Rows)
                {
                    DateTime tmp = (DateTime)usuario[CST.HEADER_FECHA_NACIMIENTO];
                    Usuario UsuarioRetorno = new Usuario(
                        (int)usuario[CST.HEADER_CEDULA],
                        (string)usuario[CST.HEADER_NOMBRE_PERSONA],
                        (string)usuario[CST.HEADER_PRIMER_APELLIDO],
                        (string)usuario[CST.HEADER_SEGUNDO_APELLIDO],
                        (tmp.Day + "/" + tmp.Month + "/" + tmp.Year).ToString(),
                        (int)usuario[CST.HEADER_TELEFONO_PERSONA],
                        (string)usuario[CST.HEADER_DIRECCION_PERSONA],
                        (string)usuario[CST.HEADER_CORREO_ELECTRONICO],
                        ""
                        );
                    UsuarioRetorno.FechaTmp = tmp;
                    UsuarioRetorno.TipoUsuario = (string)usuario[CST.HEADER_NOMBRE_RANGO];
                    return UsuarioRetorno.toJson();
                }
            }
            else {

            }

            return null;
        }




    }
}