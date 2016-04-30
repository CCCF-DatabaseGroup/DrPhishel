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
    class HistorialPacienteAdapter : BaseAdapter<ClasePaciente>
    {

        public List<ClasePaciente> Pacientes;
        private Context Contexto;

        public HistorialPacienteAdapter(Context contexto,List<ClasePaciente> items)
        {
            Pacientes = items;
            Contexto = contexto;

        }

        public override int Count
        {
            get
            {
                return Pacientes.Count;
            }
        }

       

        public override long GetItemId(int position)
        {
            return position;
        }

        public override ClasePaciente this[int position]
        {
            get
            {
                return Pacientes[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View Columna= convertView;
            if (Columna == null)
            {
                Columna = LayoutInflater.From(Contexto).Inflate(Resource.Layout.Test,null,false);
            }

            TextView TextoNombre = Columna.FindViewById<TextView>(Resource.Id.TESTtextNombre);
            TextoNombre.Text = Pacientes[position].Nombre;

            TextView TextoUsuario = Columna.FindViewById<TextView>(Resource.Id.TESTtextUsuario);
            TextoUsuario.Text = Pacientes[position].Usuario;

            TextView TextoID = Columna.FindViewById<TextView>(Resource.Id.TESTtextId);
            TextoID.Text = Pacientes[position].ID;

            TextView TextoPadecimiento = Columna.FindViewById<TextView>(Resource.Id.TESTtextPadecimiento);
            TextoPadecimiento.Text = Pacientes[position].Padecimiento;


            return Columna;
        }


    }
}