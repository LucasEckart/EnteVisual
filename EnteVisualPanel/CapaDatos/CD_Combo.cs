using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Combo
    {

        public List<Combo> Listar()
        {
            List<Combo> lista = new List<Combo>();
            Conexion datos = new Conexion();

            datos.setearConsulta("SELECT  IdCombo, Nombre, CantidadPorDia, Precio, Detalle FROM Combo");
            datos.ejecutarLectura();

            try
            {
                while (datos.Lector.Read())
                {
                    Combo aux = new Combo();
                    aux.Id = (int)datos.Lector["IdCombo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.CantPorDia = (int)datos.Lector["CantidadPorDia"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Detalle = (string)datos.Lector["Detalle"];

                    lista.Add(aux);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al listar los combos");
                return new List<Combo>();
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;


        }


        public int registrarCombo(Combo combo, out string Mensaje)
        {
            Conexion datos = new Conexion();
            Mensaje = string.Empty;
            int idAutogenerado = 0;

            try
            {
                datos.setearPorcedimiento("sp_registrarCombo");
                datos.setearParametro("@Nombre", combo.Nombre);
                datos.setearParametro("@CantidadPorDia", combo.CantPorDia);
                datos.setearParametro("@Precio", combo.Precio);
                datos.setearParametro("@Detalle", combo.Detalle);
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



        public bool editarCombo(Combo combo, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            Conexion datos = new Conexion();

            try
            {
                datos.setearPorcedimiento("sp_editarCombo");

                datos.setearParametro("@IdCombo", combo.Id);
                datos.setearParametro("@Nombre", combo.Nombre);
                datos.setearParametro("@CantidadPorDia", combo.CantPorDia);
                datos.setearParametro("@Precio", combo.Precio);
                datos.setearParametro("@Detalle", combo.Detalle);
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



        public bool eliminarCombo(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            Conexion datos = new Conexion();

            try
            {
                datos.setearConsulta("delete top(1) from Combo where IdCombo = @id");
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
