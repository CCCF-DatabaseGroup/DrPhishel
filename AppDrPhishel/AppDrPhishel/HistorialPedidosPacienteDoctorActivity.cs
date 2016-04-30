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
    public class HistorialPedidosPacienteDoctorActivity : ConectionActivity
    {
        private List<ClasePaciente> Pacientes;
        private ListView ListaPacientes;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.HistorialPedidoPacienteDoctorLayout);

            //Seteando la ListView
            ListaPacientes = FindViewById<ListView>(Resource.Id.HISTORIALPEDIDOSDOCTORlista);
           

            //Lista de pacientes *quemar el primero*
            Pacientes = new List<ClasePaciente>();
            Pacientes.Add(new ClasePaciente() {Nombre ="Juan",Usuario="Juan1",ID= "1",Padecimiento= "Gripe" });
            Pacientes.Add(new ClasePaciente() { Nombre = "Mario", Usuario = "Marito", ID = "13", Padecimiento = "Diarrea" });
            Pacientes.Add(new ClasePaciente() { Nombre = "Sonia", Usuario = "S33", ID = "11", Padecimiento = "Dolor de Cabeza" });

            //Creando un adapter con nuestra clase para organizar los datos
            HistorialPacienteAdapter adapter = new HistorialPacienteAdapter(this, Pacientes);

           
            ListaPacientes.Adapter = adapter;

            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}