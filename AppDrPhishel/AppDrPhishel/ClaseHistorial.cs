using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppDrPhishel
{
    class ClaseHistorial
    {
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string NombreDoctor { get; set; }
        public string Apellido1Doctor { get; set; }
        public string Apellido2Doctor { get; set; }
        public string Consulta { get; set; }
        public string Estudio { get; set; }
    }
}