using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Precio
    {

        public List<Precio> Listar()
        {
            List<Precio> lista = new List<Precio>();
            Conexion datos = new Conexion();

            datos.setearConsulta("SELECT  Id, Caracteres, Precio FROM Precios");
            datos.ejecutarLectura();

            try
            {
                while (datos.Lector.Read())
                {
                    Precio aux = new Precio();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Caracteres = (string)datos.Lector["Caracteres"];
                    aux.Precios = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al listar los precios");
                return new List<Precio>();
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;


        }


        public int registrarPrecio(Precio precio, out string Mensaje)
        {
            Conexion datos = new Conexion();
            Mensaje = string.Empty;
            int idAutogenerado = 0;

            try
            {
                datos.setearPorcedimiento("sp_registrarPrecio");
                datos.setearParametro("@Caracteres", precio.Caracteres);
                datos.setearParametro("@Precio", precio.Precios);
                datos.setearParametro("@Resultado", SqlDbType.Int);
                datos.setearParametro("@Mensaje", SqlDbType.VarChar);


                datos.ejecutarAccion();

                idAutogenerado = Convert.ToInt32(datos.getearParametro("@Resultado").Value);
                Mensaje = datos.getearParametro("@Mensaje").Value.ToString();

            }
            catch (Exception ex)
            {
                idAutogenerado = 0;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return idAutogenerado;
        }



        public bool editarPrecio(Precio precio, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            Conexion datos = new Conexion();

            try
            {
                datos.setearPorcedimiento("sp_editarPrecio");

                datos.setearParametro("@Id", precio.Id);
                datos.setearParametro("@Caracteres", precio.Caracteres);
                datos.setearParametro("@Precio", precio.Precios);
                datos.setearParametro("@Resultado", SqlDbType.Bit);
                datos.setearParametro("@Mensaje", SqlDbType.VarChar);


                datos.ejecutarAccion();

                resultado = Convert.ToBoolean(datos.getearParametro("@Resultado").Value);
                Mensaje = datos.getearParametro("@Mensaje").Value.ToString();


            }
            catch (Exception ex)
            {
                resultado = false;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return resultado;
        }


        public bool eliminarPrecio(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            Conexion datos = new Conexion();

            try
            {
                datos.setearConsulta("delete top(1) from Precios where Id = @id");
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
