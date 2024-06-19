using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace EnteVisualPanel.Controllers
{
    public class CopywritingController : Controller
    {
        // GET: Copywriting
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Combos()
        {
            return View();
        }

        public ActionResult Precios()
        {
            return View();
        }



        #region Copy

        [HttpGet]
        public JsonResult listarCopy()
        {
            List<Copywriting> lista = new List<Copywriting>();
            lista = new CN_Copywriting().Listar();


            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult guardarCopy(Copywriting copy)
        {
            object resultado;
            string mensaje = string.Empty;
            CN_Copywriting negocioCopy = new CN_Copywriting();

            if (copy.Id == 0)
            {
                resultado = negocioCopy.registrarCopy(copy, out mensaje);
            }
            else
            {
                resultado = negocioCopy.editarCopy(copy, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }




        [HttpPost]
        public JsonResult eliminarCopy(int id)
        {
            CN_Copywriting negocioCopy = new CN_Copywriting();
            bool respuesta = false;
            string mensaje = string.Empty;


            respuesta = negocioCopy.eliminarCopy(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }


        #endregion Copy





        #region Combo

        [HttpGet]
        public JsonResult listarCombo()
        {
            List<Combo> lista = new List<Combo>();
            lista = new CN_Combo().Listar();


            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult guardarCombo(Combo combo)
        {
            object resultado;
            string mensaje = string.Empty;
            CN_Combo negocioCombo = new CN_Combo();

            if (combo.Id == 0)
            {
                resultado = negocioCombo.registrarCombo(combo, out mensaje);
            }
            else
            {
                resultado = negocioCombo.editarCombo(combo, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje}, JsonRequestBehavior.AllowGet);

        }



        [HttpPost]
        public JsonResult eliminarCombo(int id)
        {
            CN_Combo negocioCombo = new CN_Combo();
            bool respuesta = false;
            string mensaje = string.Empty;


            respuesta = negocioCombo.eliminarCombo(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        #endregion Combo




        #region Precio
        [HttpGet]
        public JsonResult listarPrecio()
        {
            List<Precio> lista = new List<Precio>();
            lista = new CN_Precio().Listar();


            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }





        [HttpPost]
        public JsonResult guardarPrecio(Precio precio)
        {
            object resultado;
            string mensaje = string.Empty;
            CN_Precio negocioPrecio = new CN_Precio();

            if (precio.Id == 0)
            {
                resultado = negocioPrecio.registrarPrecio(precio, out mensaje);
            }
            else
            {
                resultado = negocioPrecio.editarPrecio(precio, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult eliminarPrecio(int id)
        {
            CN_Precio negocioPrecio = new CN_Precio();
            bool respuesta = false;
            string mensaje = string.Empty;


            respuesta = negocioPrecio.eliminarPrecio(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        #endregion Precio



    }
}