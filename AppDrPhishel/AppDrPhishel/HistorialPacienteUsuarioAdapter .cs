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
    class HistorialPacienteUsuarioAdapter : BaseAdapter<ClaseHistorial>
    {

        public List<ClaseHistorial> Historial;
        private Context Contexto;

        public HistorialPacienteUsuarioAdapter(Context contexto, List<ClaseHistorial> items)
        {
            Historial = items;
            Contexto = contexto;

        }

        public override int Count
        {
            get
            {
                return Historial.Count;
            }
        }



        public override long GetItemId(int position)
        {
            return position;
        }

        public override ClaseHistorial this[int position]
        {
            get
            {
                return Historial[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View Columna = convertView;
            if (Columna == null)
            {
                Columna = LayoutInflater.From(Contexto).Inflate(Resource.Layout.ListViewTextFormatHistorialPaciente, null, false);
            }
            TextView TextoNombreDoctor = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWHISTORIALUSUARIO_textNombreDoctor);
            TextoNombreDoctor.Text = Historial[position].NombreDoctor;

            TextView TextoFecha = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWHISTORIALUSUARIO_textFecha);
            TextoFecha.Text = Historial[position].Fecha;

            TextView TextoDescripcion = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWHISTORIALUSUARIO_textDescripcion);
            TextoDescripcion.Text = Historial[position].Descripcion;




            return Columna;

        }
    }
}