using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace EnteVisualPanel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }

        public ActionResult Clientes()
        {
            return View();
        }


        #region USUARIO

        [HttpGet]
        public JsonResult listarUsuario()
        {
            List<Usuario> lista = new List<Usuario>();
            lista = new CN_Usuario().Listar();


            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult guardarUsuario(Usuario usuario)
        {
            object resultado;
            string mensaje = string.Empty;
            CN_Usuario negocioUsuario = new CN_Usuario();

            if (usuario.IdUsuario == 0)
            {
                resultado = negocioUsuario.registrarUsuario(usuario, out mensaje);
            }
            else
            {
                resultado = negocioUsuario.editarUsuario(usuario, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult eliminarUsuario(int id)
        {
            CN_Usuario negocioUsuario = new CN_Usuario();
            bool respuesta = false;
            string mensaje = string.Empty;


            respuesta = negocioUsuario.eliminarUsuario(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        #endregion usuario



        #region CLIENTE

        [HttpGet]
        public JsonResult listarCliente()
        {
            List<Cliente> lista = new List<Cliente>();
            lista = new CN_Cliente().Listar();


            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public JsonResult guardarCliente(Cliente cliente)
        {
            object resultado;
            string mensaje = string.Empty;
            CN_Cliente negocioCliente = new CN_Cliente();

            if (cliente.IdCliente == 0)
            {
                resultado = negocioCliente.registrarCliente(cliente, out mensaje);
            }
            else
            {
                resultado = negocioCliente.editarCliente(cliente, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }




        [HttpPost]
        public JsonResult eliminarCliente(int id)
        {
            CN_Cliente negocioCliente = new CN_Cliente();
            bool respuesta = false;
            string mensaje = string.Empty;


            respuesta = negocioCliente.eliminarCliente(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        #endregion CLIENTE

    }
}