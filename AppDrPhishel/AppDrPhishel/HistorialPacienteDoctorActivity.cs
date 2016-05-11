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

            
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://drphishel-001-site1.ftempurl.com/Home/api/ApiComun/ObtenerUsuario?pCedula=" + Cedula);
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

                } }



            catch (Exception e)
            {
                Pacientes = new List<ClasePaciente>();
                Console.Write(e);
                Pacientes.Add(new ClasePaciente() { Nombre = "Lo sentimos error al conectar :(" });
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