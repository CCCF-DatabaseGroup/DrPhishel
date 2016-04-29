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
    [Activity(Label = "@string/_application_name")]
    public class VistaDoctorActivity : ConectionActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            SetContentView(Resource.Layout.VistaDoctorLayout);
            Button BotonHistorialPacientes = FindViewById<Button>(Resource.Id.DOCTOR_BotonHistorialPacientes);
         



            base.OnCreate(savedInstanceState);

            
        }
    }
}