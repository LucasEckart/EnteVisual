using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Cliente
    {

        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            Conexion datos = new Conexion();

            datos.setearConsulta("SELECT  IdCliente, Nombre, Activo, Servicio FROM cliente");
            datos.ejecutarLectura();

            try
            {
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.Servicio = (string)datos.Lector["Servicio"];

                    lista.Add(aux);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al listar los combos");
                return new List<Cliente>();
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;


        }


        public int registrarCliente(Cliente cliente, out string Mensaje)
        {
            Conexion datos = new Conexion();
            int idAutogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                datos.setearPorcedimiento("sp_registrarCliente");
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Activo", cliente.Activo);
                datos.setearParametro("@Servicio", cliente.Servicio);
                datos.setearParametro("@Resultado", SqlDbType.Int);

                datos.ejecutarAccion();

                idAutogenerado = Convert.ToInt32(datos.getearParametro("@Resultado").Value);


            }
            catch (Exception ex)
            {
                idAutogenerado = 0;
                Mensaje = ex.Message;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return idAutogenerado;
        }


        public bool editarCliente(Cliente cliente, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            Conexion datos = new Conexion();

            try
            {
                datos.setearPorcedimiento("sp_editarCliente");

                datos.setearParametro("@IdCliente", cliente.IdCliente);
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Activo", cliente.Activo);
                datos.setearParametro("@Servicio", cliente.Servicio);
                datos.setearParametro("@Resultado", SqlDbType.Bit);


                datos.ejecutarAccion();

                resultado = Convert.ToBoolean(datos.getearParametro("@Resultado").Value);


            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return resultado;
        }


        public bool eliminarCliente(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            Conexion datos = new Conexion();

            try
            {
                datos.setearConsulta("delete top(1) from Cliente where IdCliente = @id");
                datos.setearParametro("@id", id);
                resultado = datos.ejecutarAccion() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return resultado;
        }


    }
}
