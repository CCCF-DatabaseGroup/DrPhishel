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
                Columna = LayoutInflater.From(Contexto).Inflate(Resource.Layout.ListViewTextFormatPacientesLayout,null,false);
            }

            TextView TextoNombre = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWPACIENTEStextNombre);
            TextoNombre.Text = Pacientes[position].Nombre;

            TextView TextoUsuario = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWPACIENTEStextApellido1);
            TextoUsuario.Text = Pacientes[position].PrimerApellido;

            TextView TextoID = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWPACIENTEStextApellido2);
            TextoID.Text = Pacientes[position].SegundoApellido;

            TextView TextoPadecimiento = Columna.FindViewById<TextView>(Resource.Id.LISTVIEWPACIENTEStextPadecimiento);
            TextoPadecimiento.Text = Pacientes[position].Padecimiento;


            return Columna;
        }


    }
}