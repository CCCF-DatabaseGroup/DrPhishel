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


       private ClasePaciente PacienteLogin ;
        private ClaseDoctor DoctorLogin;


        // Metodo que procede a llamar al POST y revisar si el Usuario esta registrado
        public void Logearse(string User, string Password,string Tipo,EditText Texto)
        {
            String ProcedureLogearse1 = "http://drphishel-001-site1.ftempurl.com/Home/api/ApiComun/LoginUsuario?pCorreoElectronico=";
            String ProcedureLogearse2 = "&pContrasena=";
            String ProcedureLogearse3 = "&pTipoUsuario=";
            this.PacienteLogin = new ClasePaciente();
        
            //Try que llama al post
           
            try
            {
                String Logeado = String.Empty;
                Uri url = new Uri(ProcedureLogearse1 + User + ProcedureLogearse2 + Password + ProcedureLogearse3 + Tipo);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                 request.ContentType="application/json";
                 request.Method = "POST";
                request.Expect = "application/json";
                request.ContentLength = 0;
                using (WebResponse response = (WebResponse)request.GetResponse())
                {
                  
                    Stream stream = response.GetResponseStream();
                    StreamReader SR = new StreamReader(stream);
                    
                   // si el pedido de revision es un Usuario
                    if (Tipo == "3")
                    {

                        Logeado = SR.ReadToEnd();
                        ClasePaciente result = JsonConvert.DeserializeObject<ClasePaciente>(Logeado);
                        this.PacienteLogin=result; 
                        SR.Close();
                        stream.Close();
                    }
                    // si el pedido de revision es un Doctor
                    if (Tipo == "2")
                    {

                        Logeado = SR.ReadToEnd();
                        ClaseDoctor result = JsonConvert.DeserializeObject<ClaseDoctor>(Logeado);
                        this.DoctorLogin = result;
                        SR.Close();
                        stream.Close();
                    }



                }


            }
            catch (Exception e)
            {
                Texto.Text = e.ToString();
            }

        

        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            


            SetContentView(Resource.Layout.Main);

            //Entradas del Usuario
            EditText EntradaUsuario = FindViewById<EditText>(Resource.Id.MAIN_entryUsuario);
            EditText EntradaContraseña = FindViewById<EditText>(Resource.Id.MAIN_entryContraseña);
           

            // Login cuando el usuario da click en el boton Paciente

        
        ImageButton LogearUsuarioPaciente = FindViewById<ImageButton>(Resource.Id.MAIN_botonLogearsePaciente);
            LogearUsuarioPaciente.Click += (sender, e) =>
            {
                try
                {

                    //Capturando User y password
                    String User = EntradaUsuario.Text.ToString();
                    String Password = EntradaContraseña.Text.ToString();


                    //Se llama al store Procedure
                       Logearse(User, Password,"3",EntradaUsuario);
                    EntradaUsuario.Text += PacienteLogin.Correo;
                    EntradaUsuario.Text += PacienteLogin.Contrasena;

                        // si el usuario existe
                         if (PacienteLogin != null)
                        {

                        // se hace un Inten para pasar parametros a la proxima Activity
                        Intent PasarAPaciente = new Intent(this, typeof(VistaUsuarioActivity));
                         
                          PasarAPaciente.PutExtra("Usuario Cedula", PacienteLogin.Cedula.ToString());
                        PasarAPaciente.PutExtra("Usuario Nombre", PacienteLogin.Nombre);

                        PacienteLogin = null;
                        StartActivity(PasarAPaciente);
                       }
                       else
                       {
                           EntradaUsuario.Text = "Usuario Invalido, intente de nuevo";
                    }



                }
                catch(Exception f)
                {
                    EntradaUsuario.Text = "Usuario Invalido, intente de nuevo";
                }
                
               
                
            };
            // Boton y evento que del login del Doctor
            ImageButton LogearUsuarioDoctor = FindViewById<ImageButton>(Resource.Id.MAIN_botonLogearseDoctor);
            LogearUsuarioDoctor.Click += (sender, e) =>
            {
                try
                {

                    //Capturando User y password
                    String User = EntradaUsuario.Text.ToString();
                    String Password = EntradaContraseña.Text.ToString();


                    //Se llama al store Procedure
                    Logearse(User, Password, "2",EntradaUsuario);


                    //Si el usuario existe
                    if (DoctorLogin!= null)
                    {

                        // se pasan los datos al siguente view
                        Intent PasarADoctor = new Intent(this, typeof(VistaUsuarioActivity));
                        PasarADoctor.PutExtra("Cedula Doctor", DoctorLogin.Cedula);
                        PasarADoctor.PutExtra("Nombre Doctor", DoctorLogin.Nombre);
                        DoctorLogin = null;
                        StartActivity(PasarADoctor);

                    }
                    else
                    {
                        EntradaUsuario.Text = "Usuario Invalido, intente de nuevo";
                    }
                   

                }
                catch(Exception ex)
                {
                    EntradaUsuario.Text = "Usuario Invalido, intente de nuevo";
                }



            };



        }
    }
}

