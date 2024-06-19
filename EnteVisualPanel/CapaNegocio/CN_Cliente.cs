using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class CN_Cliente
    {

        private CD_Cliente objCapaDato = new CD_Cliente();

        public List<Cliente> Listar()
        {
            return objCapaDato.Listar();
        }


        public int registrarCliente(Cliente cliente, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                Mensaje = "El nombre del cliente no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.registrarCliente(cliente, out Mensaje);
            }
            else
            {
                return 0;
            }

        }


        public bool editarCliente(Cliente cliente, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                Mensaje = "El nombre del cliente no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.editarCliente(cliente, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool eliminarCliente(int id, out string Mensaje)
        {
            return objCapaDato.eliminarCliente(id, out Mensaje);

        }
    }
}
