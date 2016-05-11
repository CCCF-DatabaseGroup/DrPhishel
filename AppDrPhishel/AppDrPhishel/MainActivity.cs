using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Text;

namespace AppDrPhishel
{
    [Activity(Label = "@string/_application_name", MainLauncher = true, Icon = "@drawable/Drphi")]
    public class MainActivity : Activity
    {

       
        //Clase para Logearse


       private List<ClasePaciente> PacienteLogin ;


        public void Logearse(string User, string Password,string Tipo, ImageButton x, EditText y)
        {
            String ProcedureLogearse1 = "http://drphishel-001-site1.ftempurl.com/Home/api/ApiComun/LoginUsuario?pCorreoElectronico=";
            String ProcedureLogearse2 = "&pContrasena=";
            String ProcedureLogearse3 = "&pTipoUsuario=";
            this.PacienteLogin = new List<ClasePaciente>();
        

            /** WebClient cliente = new WebClient();
             Uri url = new Uri(ProcedureLogearse1 + User + ProcedureLogearse2 + Password + ProcedureLogearse3 + Tipo);
             cliente.UploadString(url,);*/
            try
            {

                

                Uri url = new Uri(ProcedureLogearse1 + User + ProcedureLogearse2 + Password + ProcedureLogearse3 + Tipo);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                 request.ContentType="application/json";
                 request.Method = "POST";
                request.Expect = "application/json";

                /**    
               // y.Text = ProcedureLogearse1 + User + ProcedureLogearse2 + Password + ProcedureLogearse3 + Tipo;
                 String test = String.Empty;
                x.SetX(10);




                // using (WebClient wc = new WebClient())
                // {

                //   wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*//*//;q=0.8//");
                //  wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.22 (KHTML, like Gecko) Chrome/25.0.1364.172 Safari/537.22");
                // wc.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                // wc.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                // wc.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.3");
                **/




             //   string dataString = @"{""pCorreoElectronico"":""crisrivlop@gmail.com"",""pContrasena"":""1111"",""pTipo"":3}";

             // byte[] dataBytes = Encoding.UTF8.GetBytes(dataString);
              //  request.GetRequestStream().Write(dataBytes, 0, dataBytes.Length);
                request.ContentLength = 0;







                using (WebResponse response = (WebResponse)request.GetResponse())
                {
                  
                    Stream stream = response.GetResponseStream();
                    StreamReader SR = new StreamReader(stream);
                    y.Text = SR.ReadToEnd().ToString();
                    SR.Close();


                    stream.Close();
                }
                /**


                         Stream dataStream = response.GetResponseStream();
                         StreamReader reader = new StreamReader(dataStream);
                         test = reader.ReadToEnd();
                        reader.Close();
                        dataStream.Close();
                        x.SetX(80);
                       

                        if (Tipo == "3")
                         {

                            
                             ClasePaciente result = JsonConvert.DeserializeObject<ClasePaciente>(test);
                             this.PacienteLogin.Add(result);
                            x.SetX(150);

                        }
                         

                     }**/







                }
            catch (Exception e)
            {
                y.Text += e.Message;
            }

        

        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            


            SetContentView(Resource.Layout.Main);

            //Entradas del Usuario
            EditText EntradaUsuario = FindViewById<EditText>(Resource.Id.MAIN_entryUsuario);
            EditText EntradaContraseña = FindViewById<EditText>(Resource.Id.MAIN_entryContraseña);
           

            // Login cuando el usuario da click en el boton doctor

        
        ImageButton LogearUsuarioPaciente = FindViewById<ImageButton>(Resource.Id.MAIN_botonLogearsePaciente);
            LogearUsuarioPaciente.Click += (sender, e) =>
            {
                try
                {

                    //Capturando User y password
                    String User = EntradaUsuario.Text.ToString();
                    String Password = EntradaContraseña.Text.ToString();


                    //Se llama al store Procedure
                       Logearse("crisrivlop@gmail.com", "1111","3", LogearUsuarioPaciente, EntradaUsuario);

                    EntradaUsuario.Text = this.PacienteLogin[0].Nombre.ToString();

                        
                            //Intent PasarADoctor = new Intent(this, typeof(VistaDoctorActivity));
                           // PasarADoctor.PutExtra("Usuario", this.PacienteLogin[0].ID);
                           // StartActivity(PasarADoctor);

                        



                    

                   

                }
                catch
                {

                }
                
               
                
            };

            
            
        }
    }
}

