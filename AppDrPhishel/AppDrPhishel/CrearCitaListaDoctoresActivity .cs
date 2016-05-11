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
    public class CrearCitaListaDoctoresActivity : ConectionActivity
    {
        private List<ClaseDoctor> Doctores;
        private ListView ListaDoctores;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.CrearCitaListaDoctoresLayout);

            //Seteando la ListView
            ListaDoctores = FindViewById<ListView>(Resource.Id.CREARCITALISTADOCTORES_lista);

          
        
            //Lista de pacientes *quemar el primero*
            Doctores = new List<ClaseDoctor>();
            Doctores.Add(new ClaseDoctor() {Nombre ="Chancher",PrimerApellido="Soto",SegundoApellido= "Rojas",Especialidad= "Dentista" });
            Doctores.Add(new ClaseDoctor() { Nombre = "Marcela", PrimerApellido = "Ortega", SegundoApellido = "Castro", Especialidad = "Ginecologia" });
            Doctores.Add(new ClaseDoctor() { Nombre = "Marco", PrimerApellido = "Rivera", SegundoApellido = "Acuña", Especialidad = "Urologia" });
           
            //Creando un adapter con nuestra clase para organizar los datos
            CrearCitaListaDoctoresAdapter adapter = new CrearCitaListaDoctoresAdapter(this, Doctores);

           /*
            Se agrega al adapter para el formato
             */

            ListaDoctores.Adapter = adapter;

            ListaDoctores.ItemLongClick += ListaDoctores_LongClick;
            base.OnCreate(savedInstanceState);
          
     
        }

        private void ListaDoctores_LongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            //capturando nombre del Doctor , NOTA: CAMBIAR POR ID
            String NomDoctor = Doctores[e.Position].Nombre.ToString();

            Intent PasarAConfirmar = new Intent(this, typeof(CrearCitaConfirmarDoctorActivity));
            PasarAConfirmar.PutExtra("IdDoctor", NomDoctor);
            StartActivity(PasarAConfirmar);

        }
    }
}