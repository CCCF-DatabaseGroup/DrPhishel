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
    [Activity(Label = "CrearCitaConfirmarDoctorActivity")]
    public class CrearCitaConfirmarDoctorActivity : ConectionActivity
    {
        public string IDdoctor;
       private Button BotonConfirmar;
        private Button BotonDenegar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
             

            this.IDdoctor = Intent.GetStringExtra("IdDoctor");
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CrearCitaConfirmarDoctorLayout);
             BotonConfirmar = FindViewById<Button>(Resource.Id.CREARCITACONFIRMARDOCTOR_BotonSI);
             BotonDenegar = FindViewById<Button>(Resource.Id.CREARCITACONFIRMARDOCTOR_BotonNO);

            BotonConfirmar.Click += BotonConfirmar_Click;
            BotonDenegar.Click += BotonDenegar_Click;
        }

        private void BotonDenegar_Click(object sender, EventArgs e)
        {
            this.IDdoctor = null;
            StartActivity(typeof(CrearCitaListaDoctoresActivity));
        }

        private void BotonConfirmar_Click(object sender, EventArgs e)
        {
           
        }
    }
}