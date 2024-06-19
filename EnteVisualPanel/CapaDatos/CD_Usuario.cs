using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public  class CD_Usuario
    {

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            Conexion datos = new Conexion();

            try
            {
                datos.setearConsulta("SELECT  IdUsuario, Nombre, Apellido, Correo, Clave, Telefono, Reestablecer, Activo, Rol FROM USUARIO");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Correo = (string)datos.Lector["Correo"];
                    aux.Clave = (string)datos.Lector["Clave"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Reestablecer = (bool)datos.Lector["Reestablecer"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.Rol = (string)datos.Lector["Rol"];

                    lista.Add(aux);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al listar los usuarios");
                return new List<Usuario>();
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista; 

        }




        public int registrarUsuario(Usuario usuario, out string Mensaje)
        {
            Conexion datos = new Conexion();
            int idAutogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                datos.setearPorcedimiento("sp_RegistrarUsuario");

                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Correo", usuario.Correo);
                datos.setearParametro("@Clave", usuario.Clave);
                datos.setearParametro("@Telefono", usuario.Telefono);
                datos.setearParametro("@Rol", usuario.Rol);
                datos.setearParametro("@Activo", usuario.Activo);

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



        public bool editarUsuario(Usuario usuario, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            Conexion datos = new Conexion();

            try
            {
                datos.setearPorcedimiento("sp_editarUsuario");

                datos.setearParametro("@IdUsuario", usuario.IdUsuario);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Correo", usuario.Correo);
                datos.setearParametro("@Telefono", usuario.Telefono);
                datos.setearParametro("@Rol", usuario.Rol);
                datos.setearParametro("@Activo", usuario.Activo);

                datos.setearParametro("@Resultado", SqlDbType.Bit);
                datos.setearParametro("@Mensaje", SqlDbType.VarChar);

                datos.ejecutarAccion();

                resultado = Convert.ToBoolean(datos.getearParametro("@Resultado").Value);
                Mensaje = datos.getearParametro("@Mensaje").Value.ToString();

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


        public bool eliminarUsuario(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            Conexion datos = new Conexion();

            try
            {
                datos.setearConsulta("delete top(1) from USUARIO where IdUsuario = @id");
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


        public bool cambiarClave(int IdUsuario, string nuevaClave, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            Conexion datos = new Conexion();

            try
            {
                datos.setearConsulta("update usuario set Clave = @nuevaClave, Reestablecer = 0 where IdUsuario = @id");
                datos.setearParametro("@id", IdUsuario);
                datos.setearParametro("@nuevaClave", nuevaClave);
                resultado = datos.ejecutarAccion() > 0 ? true : false;

            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return resultado;

        }

        public bool reestablecerClave(int idUsuario, string clave, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            Conexion datos = new Conexion();

            try
            {
                datos.setearConsulta("update usuario set clave = @clave, Reestablecer = 1 where IdUsuario = @id");
                datos.setearParametro("@id", idUsuario);
                datos.setearParametro("@clave", clave);
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
