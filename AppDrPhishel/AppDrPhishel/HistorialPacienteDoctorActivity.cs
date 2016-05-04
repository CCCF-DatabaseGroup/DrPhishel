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
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace AppDrPhishel
{
    [Activity(Label = "HistorialPedidosPacienteDoctorActivity")]
    public class HistorialPacienteDoctorActivity : ConectionActivity
    {
        private List<ClasePaciente> Pacientes;
        private ListView ListaPacientes;

        public void AgregarDatos(string Cedula)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://192.168.0.18/Doctor/api/ApiComun/ObtenerUsuario?pCedula="+Cedula);
            request.Method = "GET";
            String test = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                Console.WriteLine(test);
                ClasePaciente result = JsonConvert.DeserializeObject<ClasePaciente>(test);
                Pacientes.Add(result);

            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.HistorialPacienteDoctorLayout);

            //Seteando la ListView
            ListaPacientes = FindViewById<ListView>(Resource.Id.HISTORIALPEDIDOSDOCTORlista);



            //Lista de pacientes *quemar el primero*
            Pacientes = new List<ClasePaciente>();
            AgregarDatos("604220930");
            AgregarDatos("401080178");

            //Creando un adapter con nuestra clase para organizar los datos
            HistorialPacienteAdapter adapter = new HistorialPacienteAdapter(this, Pacientes);

           /*
            Se agrega al adapter para el formato
             */

            ListaPacientes.Adapter = adapter;

            ListaPacientes.ItemClick += ListaPacientes_ItemClick;

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