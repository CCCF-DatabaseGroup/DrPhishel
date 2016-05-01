using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrPhishel_Web.Models
{
    /*This class has any constant that needs to be used, such as stored procedures */
    public class CST
    {
        /*PROCEDIMIENTOS ALMACENADOS*/

        
        /*  citas */
        public const string PROC_ALMACENADO_PEDIR_CITA = "crearCita";
        public const string PROC_ALMACENADO_OBTENER_CITAS_DISP_DOC = "obtenerCitasDisponiblesDoctor";
        public const string PROC_ALMACENADO_ELIMINAR_CITA = "eliminarCita"; /* MISSING */
        public const string PROC_ALMACENADO_CAMBIAR_HORA_CITA = "cambiarHoraCita"; /* MISSING */

        /* Especialidades */
        public const string PROC_ALMACENADO_SOLICITAR_ESPECIALIDADES = "solicitarEspecialidades"; /* MISSING */
        public const string PROC_ALMACENADO_AGREGAR_CATEGORIA = "insertarEspecialidad";

        /* Historial */
        public const string PROC_ALMACENADO_OBTENER_HISTORIAL_CLINICO_PACIENTE = "obtenerHistorialClinicoPaciente";

        /*Doctor */
        public const string PROC_ALMACENADO_ASOCIAR_PACIENTE_DOCTOR = "asociarPacienteADoctor"; /* MISSING */

        /*Home */
        public const string PROC_ALMACENADO_REGISTRAR_USUARIO = "registrarUsuario";


        /* SQL PARAMETERS */

        /*citas*/
        public const string SQL_ID_CITA = "@Id_cita";
        public const string SQL_NUM_DOC_CITA = "@Numero_doctor_cita";
        public const string SQL_CED_PACIENT_CITA = "@Cedula_paciente_cita";
        public const string SQL_FECHA_CITA = "@Fecha_cita";
        public const string SQL_HORA_CITA = "@Hora_cita";
        public const string SQL_FECHA_NUEVA = "@Fecha_nueva";
        public const string SQL_HORA_NUEVA = "@Hora_nueva";

        /*Especialidades*/
        public const string SQL_ID_ESPECIALIDAD = "@Id_especialidad";
        public const string SQL_NOMBRE_ESPECIALIDAD = "@Nombre_especialidad";

        /* Historial */
        public const string SQL_ID_CITA_HISTORIAL = "@Id_cita_HC";
        public const string SQL_NUM_DOC_HISTORIAL = "@Numero_doctor_HC";
        public const string SQL_CED_PACIENTE_HISTORIAL = "@Cedula_paciente_HC";
        public const string SQL_CONSULTA = "@Consulta";
        public const string SQL_ESTUDIO = "@Estudio";
        public const string SQL_RECETA = "@Receta";
        public const string SQL_NOMBRE_DOC = "@Nombre_Doctor";
        public const string SQL_APEL1_DOC = "@Apellido1_Doctor";
        public const string SQL_APEL2_DOC = "@Apellido2_Doctor";

        /* Doctor */
        public const string SQL_ID_DOCTOR_ASOCIE = "@Id_doctor"; /*MISSING*/
        public const string SQL_ID_PACIENTE_ASOCIE = "@Id_paciente"; /*MISSING*/

        /* Persona */
        public const string SQL_CEDULA = "@Cedula";
        public const string SQL_NOMBRE_PERSONA = "@Nombre_persona";
        public const string SQL_PRIMER_APELLIDO = "@Apellido1";
        public const string SQL_SEGUNDO_APELLIDO = "@Apellido2";
        public const string SQL_FECHA_NACIMIENTO = "@Fecha_nacimiento";
        public const string SQL_TELEFONO_PERSONA = "@Telefono_persona";
        public const string SQL_DIRECCION_PERSONA = "@Direccion_persona";

        /* Parametros para stored procedures */
        public const string PARAM_CEDULA = "@cedula";
        public const string PARAM_NOMBRE = "@nombre";
        public const string PARAM_APELL1 = "@apellido1";
        public const string PARAM_APELL2 = "@apellido2";
        public const string PARAM_FECHA_NAC = "@FechaNacimiento";
        public const string PARAM_TEL = "@telefono";
        public const string PARAM_DIREC = "@direccion";
        public const string PARAM_CORREO = "@correo";
        public const string PARAM_CONTRA = "@contrasena";
        public const string PARAM_DOCT = "@doctor";
        public const string PARAM_FECHA_MAYUS = "@Fecha";
        public const string PARAM_FECHA_MINUS = "@fecha";
        public const string PARAM_HORA = "@hora";
        public const string PARAM_ESPECI = "@especialidad";
        public const string PARAM_MESSAGE = "@message";
        public const string PARAM_ID_ADMIN = "@idAdministrador";
        public const string PARAM_ID_DOCTOR = "@idDoctor";
        public const string PARAM_HORAS_DISP = "@Horas_disponibles";


        /* Usuario */
        public const string SQL_CORREO_ELECTRONICO = "@Correo_electronico";
        public const string SQL_CONTRASENA = "@Contrasena";




    }
}