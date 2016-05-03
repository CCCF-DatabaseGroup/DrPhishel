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
    [Activity(Label = "@string/_application_name", Icon = "@drawable/Drphi")]
    public class VistaUsuarioActivity : ConectionActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            SetContentView(Resource.Layout.VistaUsuarioLayout);
        
            //Poner Nombre del Usuario en el texto
            TextView NombreDelUsuario = FindViewById<TextView>(Resource.Id.USUARIO_textUsuario);
            NombreDelUsuario.Text = Intent.GetStringExtra("Usuario");

            /*
             Boton que abre el historial clinico del paciente
             */

            Button BotonHistorialPaciente = FindViewById<Button>(Resource.Id.USUARIO_BotonHistorialPacientes);
            BotonHistorialPaciente.Click += (sender, e) =>
            {

                StartActivity(typeof(HistorialPacienteUsuarioActivity));
            };

            Button BotonCrearCita = FindViewById<Button>(Resource.Id.USARIO_BotonCalendarioCitas);
            BotonCrearCita.Click += (sender, e) =>
            {

                StartActivity(typeof(CrearCitaListaDoctoresActivity));
            };


            base.OnCreate(savedInstanceState);


        }
    }
}