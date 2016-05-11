using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;

using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;


namespace AppDrPhishel
{
    [Activity(Label = "HistorialPedidosPacienteDoctorActivity")]
    public class HistorialPacienteUsuarioActivity : ConectionActivity
    {
        private List<ClaseHistorial> Historial;
        private ListView ListaHistorial;
       

        // Metodo que llama un GET para obtener las citas 
        public void ConsultarHistorial(string Cedula)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://drphishel-001-site1.ftempurl.com/Home/api/ApiComun/ObtenerHistorialClinico?pCedula=" + Cedula);
                request.Method = "GET";
                String test = String.Empty;
                request.ContentType = "application/json";
                request.Method = "GET";
                request.Expect = "application/json";
                request.ContentLength = 0;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    test = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.ContractResolver = new CustomResolver();

                    List<ClaseHistorial> result = JsonConvert.DeserializeObject<List<ClaseHistorial>>(test,settings);
                  
                    Historial= result;
                    Historial.Insert(0,new ClaseHistorial() {NombreDoctor="Nombre" ,Apellido1Doctor = "Apellido1",
                        Apellido2Doctor = "Apellido2",Consulta = "Consulta",Estudio = "Estudio" , Fecha = "Fecha" ,Hora = "Hora"
                    });
                       

                }
            }



            catch (Exception e)
            {
                Historial = new List<ClaseHistorial>();
                Console.Write(e);
                Historial.Add(new ClaseHistorial() { Apellido1Doctor = e.ToString() , Apellido2Doctor= "Catch" });
               
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.HistorialPacienteUsuarioLayout);

            //Seteando la ListView
            ListaHistorial = FindViewById<ListView>(Resource.Id.HISTORIALPACIENTEUSUARIO_lista);
         
            string CedulaUsuario = Intent.GetStringExtra("Cedula");
            ConsultarHistorial(CedulaUsuario);
           
           
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