using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using Android.Graphics;
using System.Net;
using System;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
namespace AppDrPhishel
{
    [Activity(Label = "ConectionActivity")]
    public class ConectionActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
        //Metodo para probar conexion a WebApi
        void CargarDatosWebApi()
        {
            WebClient Client = new WebClient();
            //URL de la base de datos
            Uri uri = new Uri("http//192.168.");
            NameValueCollection Parametros = new NameValueCollection();
          
        }
    }


}