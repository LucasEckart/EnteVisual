using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Precio
    {
        private CD_Precio objCapaDato = new CD_Precio();

        public List<Precio> Listar()
        {
            return objCapaDato.Listar();
        }


        public int registrarPrecio(Precio precio, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(precio.Caracteres))
            {
                Mensaje = "Ingresar la cantidad de caracteres";
            }

            else if (precio.Precios == 0)
            {
                Mensaje = "Ingresar el precio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.registrarPrecio(precio, out Mensaje);
            }
            else
            {
                return 0;
            }
        }


        public bool editarPrecio(Precio precio, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(precio.Caracteres))
            {
                Mensaje = "Ingresar la cantidad de caracteres";
            }

            else if (precio.Precios == 0)
            {
                Mensaje = "Ingresar el precio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.editarPrecio(precio, out Mensaje);
            }
            else
            {
                return false;
            }
        }



        public bool eliminarPrecio(int id, out string Mensaje)
        {
            return objCapaDato.eliminarPrecio(id, out Mensaje);

        }


    }
}
