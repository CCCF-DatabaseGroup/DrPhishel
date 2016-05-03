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
    [Activity(Label = "HistorialPedidosPacienteDoctorActivity")]
    public class CitasDoctorActivity : ConectionActivity
    {
        private List<ClaseCita> Citas;
        private ListView ListaCitas;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.CitasDoctorLayout);

            //Seteando la ListView
            ListaCitas = FindViewById<ListView>(Resource.Id.CITASDOCTORLAYOUTlista);
           

            //Lista de pacientes *quemar el primero*
            Citas = new List<ClaseCita>();
            Citas.Add(new ClaseCita() {NombrePaciente ="Juan",ApellidoPaciente="Rojas",Dia= "13/04/2016",Hora= "6:00" });
            Citas.Add(new ClaseCita() { NombrePaciente = "Mario", ApellidoPaciente = "Castañeda", Dia = "14/08/2016", Hora = "7:30" });
            Citas.Add(new ClaseCita() { NombrePaciente = "Sonia", ApellidoPaciente = "Casas", Dia = "11/09/2001", Hora = "8:00" });

            //Creando un adapter con nuestra clase para organizar los datos
            CitasDoctorAdapter adapter = new CitasDoctorAdapter(this, Citas);

           
            ListaCitas.Adapter = adapter;

            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}