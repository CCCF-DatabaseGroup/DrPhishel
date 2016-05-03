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
    class CitasDoctorAdapter : BaseAdapter<ClaseCita>
    {

        public List<ClaseCita> Citas;
        private Context Contexto;

        public CitasDoctorAdapter(Context contexto,List<ClaseCita> items)
        {
            Citas = items;
            Contexto = contexto;

        }

        public override int Count
        {
            get
            {
                return Citas.Count;
            }
        }

       

        public override long GetItemId(int position)
        {
            return position;
        }

        public override ClaseCita this[int position]
        {
            get
            {
                return Citas[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View Columna= convertView;
            if (Columna == null)
            {
                Columna = LayoutInflater.From(Contexto).Inflate(Resource.Layout.ListViewTextFormatCitasDoctorLayout,null,false);
            }

            TextView TextoNombre = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWCITASDOCTOR_textNombrePaciente);
            TextoNombre.Text = Citas[position].NombrePaciente;

            TextView TextoApellido = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWCITASDOCTOR_textApellidoPaciente);
            TextoApellido.Text = Citas[position].ApellidoPaciente;

            TextView TextoDia = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWCITASDOCTOR_textDia);
            TextoDia.Text = Citas[position].Dia;

            TextView TextoHora = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWCITASDOCTOR_textHora);
            TextoHora.Text = Citas[position].Hora;


            return Columna;
        }


    }
}