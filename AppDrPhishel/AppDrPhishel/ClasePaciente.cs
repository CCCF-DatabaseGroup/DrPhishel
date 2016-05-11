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
    class ClasePaciente
    {
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string ID { get; set; }
        public string Padecimiento { get; set; }
        public int Cedula { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string FechaNacimiento { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaTmp { get; set; }
        

    }
}