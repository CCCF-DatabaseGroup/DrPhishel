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
using AppDrPhishel;
namespace AppDrPhishel
{
    class CrearCitaListaDoctoresAdapter : BaseAdapter<ClaseDoctor>
    {

        public List<ClaseDoctor> Doctor;
        private Context Contexto;

        public CrearCitaListaDoctoresAdapter(Context contexto, List<ClaseDoctor> items)
        {
            Doctor = items;
            Contexto = contexto;

        }

        public override int Count
        {
            get
            {
                return Doctor.Count;
            }
        }



        public override long GetItemId(int position)
        {
            return position;
        }

        public override ClaseDoctor this[int position]
        {
            get
            {
                return Doctor[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View Columna = convertView;
            if (Columna == null)
            {
                Columna = LayoutInflater.From(Contexto).Inflate(Resource.Layout.ListViewTextFormatListaDoctoresCita, null, false);
            }
            TextView TextoNombreDoctor = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWLISTADOCTORES_textNombreDoctor);
            TextoNombreDoctor.Text = Doctor[position].Nombre;


            TextView TextoApellido1 = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWLISTADOCTORES_textApellido1);
            TextoApellido1.Text = Doctor[position].PrimerApellido;

            TextView TextoApellido2 = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWLISTADOCTORES_textApellido2);
            TextoApellido2.Text = Doctor[position].SegundoApellido;


            TextView TextoEspecialidad = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWLISTADOCTORES_textEspecialidad);
            TextoEspecialidad.Text = Doctor[position].Especialidad;

            




            return Columna;

        }
    }
}