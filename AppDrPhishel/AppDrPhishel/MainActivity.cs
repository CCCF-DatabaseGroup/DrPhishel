using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AppDrPhishel
{
    [Activity(Label = "@string/_application_name", MainLauncher = true, Icon = "@drawable/IconoDoctor")]
    public class MainActivity : ConectionActivity
    {

       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Boton que me abre el layout de Crear Usuario
           Button BotonCrearUsuario = FindViewById<Button>(Resource.Id.MAIN_botonCrear);
            BotonCrearUsuario.Click += (sender, e) =>
            {

                StartActivity(typeof(CrearUsuarioActivity));
            };
            // Entrada del User
            EditText EntradaUsuario = FindViewById<EditText>(Resource.Id.MAIN_entryUsuario);
            //Contraseña que inserta el User
            EditText EntradaContraseña = FindViewById<EditText>(Resource.Id.MAIN_entryContraseña);

            Button BotonLogearse = FindViewById<Button>(Resource.Id.MAIN_botonLogearse);

            ImageButton BotonLogearUsuario = FindViewById<ImageButton>(Resource.Id.MAIN_botonLogearse);
            BotonCrearUsuario.Click += (sender, e) =>
            {
                string Usuario = EntradaUsuario.Text.ToString();
                string Contraseña = EntradaContraseña.Text.ToString();
                if (Usuario == "doctor" && Contraseña == "doctor")
                {
                    StartActivity(typeof(VistaDoctorActivity));
                }
                else
                {
                    EntradaUsuario.Text= "Usurio Invalido ";
                }
            };


        }
      
    }
}

