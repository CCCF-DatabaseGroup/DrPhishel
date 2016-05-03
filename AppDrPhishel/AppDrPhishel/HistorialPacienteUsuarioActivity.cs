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
    public class HistorialPacienteUsuarioActivity : ConectionActivity
    {
        private List<ClaseHistorial> Historial;
        private ListView ListaHistorial;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.HistorialPacienteUsuarioLayout);

            //Seteando la ListView
            ListaHistorial = FindViewById<ListView>(Resource.Id.HISTORIALPACIENTEUSUARIO_lista);

          
        
            //Lista de pacientes *quemar el primero*
            Historial = new List<ClaseHistorial>();
            Historial.Add(new ClaseHistorial() {NombreDoctor ="Cristiam",Fecha="13/09/2016",Descripcion= "Gripe" });
            Historial.Add(new ClaseHistorial() { NombreDoctor = "Esteban", Fecha = "22/05/2016",  Descripcion = "Diarrea" });
            Historial.Add(new ClaseHistorial() { NombreDoctor = "Cristofer", Fecha = "24/04/2016", Descripcion = "Dolor de Cabeza" });
           
            //Creando un adapter con nuestra clase para organizar los datos
            HistorialPacienteUsuarioAdapter adapter = new HistorialPacienteUsuarioAdapter(this, Historial);

            /*
             Se agrega al adapter para el formato
              */

            ListaHistorial.Adapter = adapter;

            ListaHistorial.ItemClick += ListaPacientes_ItemClick;

            base.OnCreate(savedInstanceState);

     
        }
        /*
         * Se crean los eventos en los clicks 
         */
        private void ListaPacientes_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            
        }
    }
}