using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;


namespace CapaNegocio
{
    public class CN_Combo
    {
        private CD_Combo objCapaDato = new CD_Combo();

        public List<Combo> Listar()
        {
            return objCapaDato.Listar();
        }


        public int registrarCombo(Combo combo, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(combo.Nombre) || string.IsNullOrWhiteSpace(combo.Nombre))
            {
                Mensaje = "El nombre del combo no puede ser vacio";
            }
            else if (combo.CantPorDia == 0)
            {
                Mensaje = "Ingresar la cantidad por día";
            }
            else if (combo.Precio == 0)
            {
                Mensaje = "Ingresar precio del combo";
            }
            else if (string.IsNullOrEmpty(combo.Detalle) || string.IsNullOrWhiteSpace(combo.Detalle))
            {
                Mensaje = "Ingresar detalles del combo";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.registrarCombo(combo, out Mensaje);
            }
            else
            {
                return 0;
            }


        }

        public bool editarCombo(Combo combo, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(combo.Nombre) || string.IsNullOrWhiteSpace(combo.Nombre))
            {
                Mensaje = "El nombre del combo no puede ser vacio";
            }
            else if (combo.CantPorDia == 0)
            {
                Mensaje = "Ingresar la cantidad por día";
            }
            else if (combo.Precio == 0)
            {
                Mensaje = "Ingresar precio del combo";
            }
            else if (string.IsNullOrEmpty(combo.Detalle) || string.IsNullOrWhiteSpace(combo.Detalle))
            {
                Mensaje = "Ingresar detalles del combo";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.editarCombo(combo, out Mensaje);
            }
            else
            {
                return false;
            }


        }



        public bool eliminarCombo(int id, out string Mensaje)
        {
            return objCapaDato.eliminarCombo(id, out Mensaje);

        }


    }
}
