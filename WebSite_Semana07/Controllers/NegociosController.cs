using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//REFERENCIA A LOS DOMINIOS
using Dominio.Repositorio;
using Dominio.Entidades;

namespace WebSite_Semana07.Controllers
{
    public class NegociosController : Controller
    {
        // INSTANCIA DE LA CLASE  Repositorio: METODOS
        clienteBL cliente = new clienteBL();
        paisBL pais = new paisBL();
        public ActionResult Index()
        {
            return View(cliente.listado());
        }

        // GET, porque envio los datos en blanco
        public ActionResult Create()
        {
            // ENVIAR LA LISTA DE PAISES
            //SelectList (lista, campo valor, campo a listar)
            ViewBag.paises = new SelectList(pais.listado(), "idpais", "nombrepais");
            // ENVIAR UN NUEVO CLIENTE
            return View(new clienteEntidad());
        }

        // POST, recibo los datos y proceso
        [HttpPost]

        public ActionResult Create(clienteEntidad reg)
        {
            //AL ENVIAR LA PAGINA, ENVIO NUEVAMENTE LOS PAISES

            ViewBag.paises = new SelectList(pais.listado(), "idpais", "nombrepais", reg.idpais);

            ViewBag.mensaje = cliente.Agregar(reg);
            
            // IR NUEVAMENTE A LA PAGINA CON LOS DATOS INGRESADOS

            return View(reg);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(cliente.listado().Where(x => x.idcliente == id).FirstOrDefault());
            }
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
                return RedirectToAction("Index");
            
                // ALMACENO EL REGISTRO POR SU id
                var reg = cliente.listado().Where(x => x.idcliente == id).FirstOrDefault();

                // ENVIO LOS PAISES
                ViewBag.paises = new SelectList(pais.listado(), "idpais", "nombrepais", reg.idpais);

                return View(reg);
            
        }

        [HttpPost]
        public ActionResult Edit(clienteEntidad reg)
        {
            // ENVIO LOS PAISES
            ViewBag.paises = new SelectList(pais.listado(), "idpais", "nombrepais", reg.idpais);

            // EJECUTO
            ViewBag.mensaje = cliente.Actualizar(reg);

            // ENVIAR LA VISTA
            return View(reg);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
                return RedirectToAction("Index");

            // ALMACENO EL REGISTRO POR SU id
            var reg = cliente.listado().Where(x => x.idcliente == id).FirstOrDefault();

            // EJECUTO
            ViewBag.mensaje = cliente.Eliminar(reg);

            // ENVIAR LA VISTA
            return RedirectToAction("Index");
        }

        
    }
}