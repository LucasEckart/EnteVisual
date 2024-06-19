using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;


namespace CapaNegocio
{
    public class CN_Copywriting
    {
        private CD_Copywriting objCapaDato = new CD_Copywriting();

        public List<Copywriting> Listar()
        {
            return objCapaDato.Listar();
        }


        public int registrarCopy(Copywriting copy, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (copy.IdCliente.IdCliente == 0)
            {
                Mensaje = "Seleccionar un cliente";
            }

            else if (copy.IdCombo.Id == 0)
            {
                Mensaje = "Seleccionar un combo disponible";
            }

            else if (copy.Precio == 0)
            {
                Mensaje = "Ingresar un Precio";
            }

            else if (string.IsNullOrEmpty(copy.Vencimiento) || string.IsNullOrWhiteSpace(copy.Vencimiento))
            {
                Mensaje = "Ingresar el vencimiento";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.registrarCopy(copy, out Mensaje);
            }
            else
            {
                return 0;
            }

        }

        public bool editarCopy(Copywriting copy, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (copy.IdCliente.IdCliente == 0)
            {
                Mensaje = "Seleccionar un cliente";
            }

            else if (copy.IdCombo.Id == 0)
            {
                Mensaje = "Seleccionar un combo disponible";
            }

            else if (copy.Precio == 0)
            {
                Mensaje = "Ingresar un Precio";
            }

            else if (string.IsNullOrEmpty(copy.Vencimiento) || string.IsNullOrWhiteSpace(copy.Vencimiento))
            {
                Mensaje = "Ingresar el vencimiento";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.editarCopy(copy, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool eliminarCopy(int id, out string Mensaje)
        {
            return objCapaDato.eliminarCopy(id, out Mensaje);

        }




    }
}
