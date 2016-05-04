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
    [Activity(Label = "AgregarPacienteDoctorActivity")]
    public class AgregarPacienteDoctorActivity : ConectionActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.AgregarPacienteDoctorLayout);
            base.OnCreate(savedInstanceState);

         
        }
    }
}