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
        public const string PROC_ALMACENADO_PEDIR_CITA = "crearCita"; /*PEDIR AL CHAN QUE RETORNA MSJ DE EXITO */
        public const string PROC_ALMACENADO_OBTENER_CITAS_DISP_DOC = "obtenerCitasDisponiblesDoctor"; /*VER SI HAY QUE HACER EL TOQUE DEL .ToJson */
        public const string PROC_ALMACENADO_ELIMINAR_CITA = "eliminarCita"; /*PEDIR AL CHAN QUE RETORNA MSJ DE EXITO */
        public const string PROC_ALMACENADO_CAMBIAR_HORA_CITA = "cambiarHoraCita"; /* PEDIR AL CHAN QUE RETORNA MSJ DE EXITO */

        /* Especialidades */
        public const string PROC_ALMACENADO_SOLICITAR_ESPECIALIDADES = "solicitarEspecialidades";
        public const string PROC_ALMACENADO_AGREGAR_CATEGORIA = "insertarEspecialidad"; /*NO SIRVE EL PROCEDURE */

        /* Historial */
        public const string PROC_ALMACENADO_OBTENER_HISTORIAL_CLINICO_PACIENTE = "verHistorialClinico"; /*VER SI HAY QUE HACER EL TOQUE DEL .ToJson */

        /*Doctor */
        public const string PROC_ALMACENADO_ASOCIAR_PACIENTE_DOCTOR = "relacionarDoctorConPaciente"; /* NOT WORKING */
        public const string PROC_ALMACENADO_ACEPTAR_DOCTOR = "aceptarDoctor"; /* PEDIR CHACHER QUE RETORNE UN MSJ DE EXITO */
        public const string PROC_ALMACENADO_INSERTAR_DOC = "insertarNuevoDoctor"; /* NO DEBE PEDIR ID USUARIO

        /* Cobros */

        public const string PROC_ALMACENADO_VER_COBRO = "verCobroDoctores"; /* PEDIR A CHAN QUE LO ARREGLE PARA 1 SOLO DOC*/
        public const string PROC_ALMACENADO_REALIZAR_COBRO = "realizarCobrosADoctores"; /*PEDIR AL CHANCHER QUE RETORNE UN MSJ DE EXITO, WRONG IDEA EL COBRO ES DE LA APP AL DOCTOR */

        /*Todo */
        public const string PROC_ALMACENADO_REGISTRAR_USUARIO = "registrarUsuario";

        public const string PROC_ALMACENADO_OBTENER_USUARIO = "obtenerUsuario";



        /* SQL PARAMETERS */

        /*citas*/
        public const string SQL_ID_CITA = "@Id_cita";
        public const string SQL_NUM_DOC_CITA = "@Numero_doctor_cita";
        public const string SQL_CED_PACIENT_CITA = "@Cedula_paciente_cita";
        public const string SQL_FECHA_CITA = "Fecha_cita";
        public const string SQL_HORA_CITA = "Hora_cita";
        public const string SQL_FECHA_NUEVA = "@Fecha_nueva";
        public const string SQL_HORA_NUEVA = "@Hora_nueva";

        /*Especialidades*/
        public const string SQL_ID_ESPECIALIDAD = "Id_especialidad";
        public const string SQL_NOMBRE_ESPECIALIDAD = "Nombre_especialidad";

        /* Historial */
        public const string SQL_ID_CITA_HISTORIAL = "@Id_cita_HC";
        public const string SQL_NUM_DOC_HISTORIAL = "@Numero_doctor_HC";
        public const string SQL_CED_PACIENTE_HISTORIAL = "@Cedula_paciente_HC";
        public const string SQL_CONSULTA = "Consulta";
        public const string SQL_ESTUDIO = "Estudio";
        public const string SQL_RECETA = "Receta";
        public const string SQL_NOMBRE_DOC = "Nombre_persona";
        public const string SQL_APEL1_DOC = "Apellido1";
        public const string SQL_APEL2_DOC = "Apellido2";

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
        public const string PARAM_CED_DOC = "@cedulaDoctor";
        public const string PARAM_CED_CLIENTE = "@cedulaCliente";
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
        public const string PARAM_ID_CITA = "@idCita";
        public const string PARAM_ID_USUARIO= "@idUsuario";
        public const string PARAM_ID_ESPE = "@idEspecialidad";
        public const string PARAM_NUM_TARJETA = "@numeroTarjeta";
        public const string PARAM_NUM_DOCTOR = "@numeroDoctor";
        public const string PARAM_EXITO = "@exito";
        public const string PARAM_COSTO_CITA = "@costoCita";



        /* Usuario */
        public const string SQL_CORREO_ELECTRONICO = "@Correo_electronico";
        public const string SQL_CONTRASENA = "@Contrasena";


        /*HEADER TABLAS*/

        public const string HEADER_CEDULA = "Cedula";
        public const string HEADER_NOMBRE_PERSONA = "Nombre_persona";
        public const string HEADER_PRIMER_APELLIDO = "Apellido1";
        public const string HEADER_SEGUNDO_APELLIDO = "Apellido2";
        public const string HEADER_FECHA_NACIMIENTO = "Fecha_nacimiento";
        public const string HEADER_TELEFONO_PERSONA = "Telefono_persona";
        public const string HEADER_DIRECCION_PERSONA = "Direccion_persona";
        public const string HEADER_CORREO_ELECTRONICO = "Correo_electronico";
        public const string HEADER_CONTRASENA = "Contrasena";
        public const string HEADER_HORAS_DISP = "@Horas_disponibles";
        public const string HEADER_FECHA_COBRO = "@Fecha_cobro";
        public const string HEADER_CANT_COBRO = "@Cantidad_cobro";





    }
}