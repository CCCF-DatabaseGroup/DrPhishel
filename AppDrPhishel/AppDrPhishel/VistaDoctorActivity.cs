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
    public class VistaDoctorActivity : ConectionActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            SetContentView(Resource.Layout.VistaDoctorLayout);
            //Boton que abre la main activity
            ImageButton BotonRegresar = FindViewById<ImageButton>(Resource.Id.DOCTOR_botonRegresar);
            BotonRegresar.Click += (sender, e) =>
            {

                StartActivity(typeof(MainActivity));
            };
            //Poner Nombre del Usuario en el texto
            TextView NombreDelUsuario = FindViewById<TextView>(Resource.Id.DOCTOR_textNombreUsuario);
            NombreDelUsuario.Text = Intent.GetStringExtra("Usuario");

            /*
             Boton que abre el historial de los pacientes asociados al Doctor
             */

            Button BotonHistorialPacientes = FindViewById<Button>(Resource.Id.DOCTOR_BotonHistorialPacientes);
            BotonHistorialPacientes.Click += (sender, e) =>
            {

                StartActivity(typeof(HistorialPacienteDoctorActivity));
            };

            /*
             Boton de  historial de citas asociadas al doctor 
             */
            Button BotonCalendarioCitas = FindViewById<Button>(Resource.Id.DOCTOR_BotonCalendarioCitas);
            BotonCalendarioCitas.Click += (sender, e) =>
            {

                StartActivity(typeof(CitasDoctorActivity));
            };

            /*
            Boton de inicia la activy de agregar paciente
            */

            Button BotonAgregarPaciente = FindViewById<Button>(Resource.Id.DOCTOR_BotonAgregarPaciente);
            BotonAgregarPaciente.Click += (sender, e) =>
            {

                StartActivity(typeof(AgregarPacienteDoctorActivity));
            };



            base.OnCreate(savedInstanceState);


        }
    }
}