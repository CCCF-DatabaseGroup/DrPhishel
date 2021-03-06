﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace DrPhishel_Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();
            /*
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            */
            config.Routes.MapHttpRoute(
                 name: "api8",
                 routeTemplate: "api/ApiComun/{action}/{pCedula}"
            );

            config.Routes.MapHttpRoute(
                 name: "api9",
                 routeTemplate: "api/ApiPaciente/cambiarHoraCita/{pCedulaPaciente}/{pIdCita}/{pFechaNueva}/{pHoraNueva}"
            );

            config.Routes.MapHttpRoute(
                 name: "api10",
                 routeTemplate: "api/ApiPaciente/EliminarCita/{pIdCita}"
            );
            //SolicitudDoctor(int pNumeroDoctor, string pNombreDoctor, string pApellido1, string pApellido2, string pLugarDeResidencia, int pTelefonoConsultorio, string pDireccionConsultorio, int pIdEspecialidad, int pNumeroTarjetaCredito, string pNombreUsuario, string pContraseña, string pCorreoElectronico)
            config.Routes.MapHttpRoute(
                 name: "api12",
                 routeTemplate: "api/ApiDoctor/SolicitudDoctor/{pNumeroDoctor}/{pNombreDoctor}/{pApellido1}/{pApellido2}/{pLugarDeResidencia}/{pTelefonoConsultorio}/{pDireccionConsultorio}/{pIdEspecialidad}/{pNumeroTarjetaCredito}/{pNombreUsuario}/{pContrasena}/{pCorreoElectronico}"
            );

            config.Routes.MapHttpRoute(
                 name: "api13",
                 routeTemplate: "Home/api/ApiComun/LoginUsuario/{pCorreoElectronico}/{pContrasena}/{pTipoUsuario}"
            );


            config.Routes.MapHttpRoute(
                 name: "api4",
            //, , , , , , , , 
            //{pCedula}/{pNombre}/{pPrimerApellido}/{pSegundoApellido}/{pFechaNacimiento}/{pTelefono}/{pDireccion}/{pCorreo}/{pContrasena}
            routeTemplate: "Home/api/ApiComun/RegistrarUsuario/{pCedula}/{pNombre}/{pPrimerApellido}/{pSegundoApellido}/{pFechaNacimiento}/{pTelefono}/{pDireccion}/{pCorreo}/{pContrasena}"
          //routeTemplate: "Home/api/ApiComun/RegistrarUsuario/{pCedula}/{pNombre}/{pPrimerApellido}/{pSegundoApellido}/{pFechaNacimiento}/{pTelefono}/{pDireccion}/{pCorreo}/{pContrasena}"
            );


            config.Routes.MapHttpRoute(
                name: "apiDoctorAceptarPaciente",
                routeTemplate: "Doctor/api/ApiDoctor/AsociarPacienteADoctor/{pNumeroDoctor}/{pCedulaPaciente}"
            );


            config.Routes.MapHttpRoute(
                name: "apiDoctorObtenerCitas",
                routeTemplate: "Paciente/api/ApiPaciente/ObtenerCitasDisponiblesDoctor/{pIdDoctor}/{pDia}"
            );
            /*
            config.Routes.MapHttpRoute(
                name: "apiDoctorInsertarHistorialClinico",
                routeTemplate: "Paciente/api/ApiDoctor/InsertarHistorialClinico/{pIdDoctor}/{pDia}"
            );
            */
            //SolicitudDoctor
            config.Routes.MapHttpRoute(
                name: "apiComunSolicitudDoctor",
                //{pNumeroDoctor}/{pIdEspecialidad}/{pTelefono}/{pNumeroDeTarjeta}/{pDireccion}
                routeTemplate: "Paciente/api/ApiComun/SolicitudDoctor/{pCedulaUsuario}/{pNumeroDoctor}/{pIdEspecialidad}/{pTelefono}/{pNumeroDeTarjeta}/{pDireccion}"
            );



            config.Routes.MapHttpRoute(
                name: "api",
                routeTemplate: "Administrador/api/{controller}/{action}"
            );

            config.Routes.MapHttpRoute(
                name: "apiDoctor",
                routeTemplate: "Doctor/api/{controller}/{action}"
            );




            config.Routes.MapHttpRoute(
                 name: "api2",
                 routeTemplate: "Home/api/{controller}/{action}"
            );


            config.Routes.MapHttpRoute(
                name: "api11",
                routeTemplate: "Paciente/api/{controller}/{action}"
            );
        }
    }
}
