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
    [Activity(Label = "@string/_application_name", MainLauncher = true, Icon = "@drawable/Drphi")]
    public class MainActivity : Activity
    {
    

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Entradas del Usuario
            EditText EntradaUsuario = FindViewById<EditText>(Resource.Id.MAIN_entryUsuario);
            EditText EntradaContraseña = FindViewById<EditText>(Resource.Id.MAIN_entryContraseña);

            Button CrearUsuario = FindViewById<Button>(Resource.Id.MAIN_botonCrear);
            CrearUsuario.Click += (sender, e) =>
            {

                StartActivity(typeof(CrearUsuarioActivity));
            };

            ImageButton LogearUsuario = FindViewById<ImageButton>(Resource.Id.MAIN_botonLogearse);
            LogearUsuario.Click += (sender, e) =>
            {
                //Capturando User y password
                String User = EntradaUsuario.Text.ToString();
                String Password = EntradaContraseña.Text.ToString();

                /*
                 Cambiar por un try y un catch , capturar ID , 
                 */
                if (User == "doctor" && Password == "doctor")
                {
                    //Se Pasa a la vista Doctor y se envia el User Usando un intent
                    Intent PasarADoctor = new Intent(this,typeof(VistaDoctorActivity));
                    PasarADoctor.PutExtra("Usuario", User);
                    StartActivity(PasarADoctor);

                }
                if (User== "user" && Password == "user")
                {
                    //Se Pasa a la vista Usuario y se envia el User Usando un intent
                    Intent PasarAUsuario = new Intent(this, typeof(VistaUsuarioActivity));
                    PasarAUsuario.PutExtra("Usuario", User);
                    StartActivity(PasarAUsuario);
                }


                else
                {
                    EntradaUsuario.Text = "Usuario Invalido|No existe";
                }
            };


        }
    }
}

