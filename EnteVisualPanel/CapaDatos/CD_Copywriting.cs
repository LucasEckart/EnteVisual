using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;


namespace CapaDatos
{
    public class CD_Copywriting
    {
        public List<Copywriting> Listar()
        {
            List<Copywriting> lista = new List<Copywriting>();
            Conexion datos = new Conexion();

            try
            {
                datos.setearConsulta("select CO.Id as Id, CO.IdCliente, CL.Nombre as NombreCliente, CO.IdCombo, C.Nombre as NombreCombo, CO.Precio, CO.Vencimiento, CO.Extras, CO.Mes, CO.Abonado from Copywriting CO\r\ninner join Combo C on C.IdCombo = CO.IdCombo\r\ninner join Cliente CL on CL.IdCliente = CO.IdCliente");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Copywriting aux = new Copywriting();
                    aux.IdCliente = new Cliente();
                    aux.IdCombo = new Combo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdCliente.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.IdCliente.Nombre = (string)datos.Lector["NombreCliente"]; 
                    aux.IdCombo.Id = (int)datos.Lector["IdCombo"];
                    aux.IdCombo.Nombre = (string)datos.Lector["NombreCombo"]; 
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Vencimiento = (string)datos.Lector["Vencimiento"];
                    aux.Extras = datos.Lector["Extras"] != DBNull.Value ? (string)datos.Lector["Extras"] : null;
                    aux.Mes = (string)datos.Lector["Mes"];
                    aux.Abonado = (bool)datos.Lector["Abonado"];

                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar copywritings: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }



        public int registrarCopy(Copywriting copy, out string Mensaje)
        {
            Conexion datos = new Conexion();
            int idAutogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                datos.setearPorcedimiento("sp_registrarCopy");

                datos.setearParametro("@IdCliente", copy.IdCliente.IdCliente);
                datos.setearParametro("@IdCombo", copy.IdCombo.Id);
                datos.setearParametro("@Precio", copy.Precio);
                datos.setearParametro("@Vencimiento", copy.Vencimiento);
                datos.setearParametro("@Extras", copy.Extras);
                datos.setearParametro("@Mes", copy.Mes);
                datos.setearParametro("@Abonado", copy.Abonado);

                datos.setearParametro("@Resultado", SqlDbType.Int);
                datos.setearParametro("@Mensaje", SqlDbType.VarChar);

                datos.ejecutarAccion();

                idAutogenerado = Convert.ToInt32(datos.getearParametro("@Resultado").Value);
                Mensaje = datos.getearParametro("@Mensaje").Value.ToString();
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



        public bool editarCopy(Copywriting copy, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            Conexion datos = new Conexion();

            try
            {
                
                datos.setearPorcedimiento("sp_editarCopy");

                datos.setearParametro("@Id", copy.Id);
                datos.setearParametro("@IdCliente", copy.IdCliente.IdCliente);
                datos.setearParametro("@IdCombo", copy.IdCombo.Id);
                datos.setearParametro("@Precio", copy.Precio);
                datos.setearParametro("@Vencimiento", copy.Vencimiento);
                datos.setearParametro("@Extras", copy.Extras);
                datos.setearParametro("@Mes", copy.Mes);
                datos.setearParametro("@Abonado", copy.Abonado);

                datos.setearParametro("@Resultado", SqlDbType.Bit);
                datos.setearParametro("@Mensaje", SqlDbType.VarChar);

                datos.ejecutarAccion();

                resultado = Convert.ToBoolean(datos.getearParametro("@Resultado").Value);
                Mensaje = datos.getearParametro("@Mensaje").Value.ToString();

            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = "Error en la base de datos: " + ex.Message;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return resultado;

        }


        public bool eliminarCopy(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            Conexion datos = new Conexion();

            try
            {
                datos.setearConsulta("delete top(1) from Copywriting where Id = @id");
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
