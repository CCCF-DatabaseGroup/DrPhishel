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
    [Activity(Label = "@string/_application_name", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button CrearUsuario = FindViewById<Button>(Resource.Id.botonCrearMain);
            CrearUsuario.Click += (sender, e) =>
            {

                StartActivity(typeof(CrearUsuarioActivity));
            };



        }
      
    }
}

