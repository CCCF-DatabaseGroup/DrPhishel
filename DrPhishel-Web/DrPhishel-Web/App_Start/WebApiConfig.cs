using System;
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
                 routeTemplate: "Home/api/ApiComun/{action}/{pCedula}"
            );
            /*
            config.Routes.MapHttpRoute(
                 name: "api9",
                 routeTemplate: "Paciente/api/{controller}/{action}/{pIdCita}"
            );
            */

            config.Routes.MapHttpRoute(
                 name: "api10",
                 routeTemplate: "Paciente/api/ApiPaciente/EliminarCita/{pIdCita}"
            );


            config.Routes.MapHttpRoute(
                 name: "api4",
            //, , , , , , , , 
            //{pCedula}/{pNombre}/{pPrimerApellido}/{pSegundoApellido}/{pFechaNacimiento}/{pTelefono}/{pDireccion}/{pCorreo}/{pContrasena}
            routeTemplate: "Home/api/ApiComun/RegistrarUsuario/{pCedula}/{pNombre}/{pPrimerApellido}/{pSegundoApellido}/{pFechaNacimiento}/{pTelefono}/{pDireccion}/{pCorreo}/{pContrasena}"
          //routeTemplate: "Home/api/ApiComun/RegistrarUsuario/{pCedula}/{pNombre}/{pPrimerApellido}/{pSegundoApellido}/{pFechaNacimiento}/{pTelefono}/{pDireccion}/{pCorreo}/{pContrasena}"
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
