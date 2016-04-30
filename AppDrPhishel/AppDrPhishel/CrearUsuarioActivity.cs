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
    public class CrearUsuarioActivity : ConectionActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CrearUsuarioLayout);
            // Create your application here

            ImageButton CrearUsuario = FindViewById<ImageButton>(Resource.Id.CREARUSUARIO_BotonRegresar);
            CrearUsuario.Click += (sender, e) =>
            {

                StartActivity(typeof(MainActivity));
            };

        }
    }
}