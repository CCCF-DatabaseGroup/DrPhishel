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
    /**
     * Clase que acomoda el ListView para el historial clinico del Paciente 
     * **/

    class HistorialPacienteUsuarioAdapter : BaseAdapter<ClaseHistorial>
    {

        public List<ClaseHistorial> Historial;
        private Context Contexto;

        public HistorialPacienteUsuarioAdapter(Context contexto, List<ClaseHistorial> items)
        {
            Historial = items;
            Contexto = contexto;

        }
        //Count para obtener tama�o de la list view
        public override int Count
        {
            get
            {
                return Historial.Count;
            }
        }

        // Para obtener la posicion por ID

        public override long GetItemId(int position)
        {
            return position;
        }
        // ClaseHistorial que se va  a usar por el Adapter
        public override ClaseHistorial this[int position]
        {
            get
            {
                return Historial[position];
            }
        }
        // se acomodan los datos de la lista a los componenetes de la listview
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

            TextView TextoEstudio = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWHISTORIALUSUARIO_textEstudio);
            TextoEstudio.Text = Historial[position].Estudio;

            TextView TextoApellido1Doctor = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWHISTORIALUSUARIO_textApellido1Doctor);
            TextoApellido1Doctor.Text = Historial[position].Apellido1Doctor;

            TextView TextoApellido2Doctor = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWHISTORIALUSUARIO_textApellido2Doctor);
            TextoApellido2Doctor.Text = Historial[position].Apellido2Doctor;

            TextView TextoConsulta = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWHISTORIALUSUARIO_textConsulta);
            TextoConsulta.Text = Historial[position].Consulta;

            TextView TextoHora = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWHISTORIALUSUARIO_textHora);
            TextoHora.Text = Historial[position].Hora;





            return Columna;

        }
    }
}