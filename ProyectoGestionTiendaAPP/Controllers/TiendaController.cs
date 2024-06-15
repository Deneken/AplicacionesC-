using ProyectoGestionTiendaAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProyectoGestionTiendaAPP.Controllers
{
    public class TiendaController : Controller
    {
        GestionHDEFactoryEntities conexion = new GestionHDEFactoryEntities();
        // GET: Tienda
        //Tiendas = cine //ListaCine = ListaTiendas  //Cines = Tienda  cines = tiendas
        public ActionResult ListaTienda()
        {
            ViewBag.rolcliente = 1;
            var tienda = conexion.Tienda.ToList();
            return View(tienda);
        }
        //Metodo Get para cargar la pagina
        public ActionResult CrearTienda()
        {
            ViewBag.rolcliente = 1;
            return View();
        }

        [HttpPost]

        public ActionResult CrearTienda([Bind(Include = "IdTienda,Nombre,Direccion,Comuna,Ciudad,Activo")] Tienda tienda)
        {

            if (ModelState.IsValid)
            {
                conexion.Tienda.Add(tienda);
                conexion.SaveChanges();
                return RedirectToAction("ListaTienda");
            }

            return View(tienda);
        }

        //Metodo Editar

        public ActionResult EditarTienda(int? id)
        {
            ViewBag.rolcliente = 1;
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Tienda tienda = conexion.Tienda.Find(id);

            if (tienda == null)
            {
                return HttpNotFound();
            }
            return View(tienda);
        }
        [HttpPost]

        public ActionResult EditarTienda([Bind(Include = "IdTienda,Nombre,Direccion,Comuna,Ciudad,Activo")] Tienda tienda)
        {
            if (ModelState.IsValid)
            {
                conexion.Entry(tienda).State = System.Data.Entity.EntityState.Modified;
                conexion.SaveChanges();
                return RedirectToAction("ListaTienda");
            }
            return View(tienda);
        }
        //Metodo Listar
        public ActionResult DetalleTienda(int? id)
        {
            ViewBag.rolcliente = 1;
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Tienda tienda = conexion.Tienda.Find(id);

            if (tienda == null)
            {
                return HttpNotFound();
            }
            return View(tienda);
        }

        //Metodo Borrar
        public ActionResult BorrarTienda(int? id)
        {
            ViewBag.rolusuario = 1;           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }           
            Tienda tienda = conexion.Tienda.Find(id);            
            if (tienda == null)
            {
                return HttpNotFound();
            }
            
            return View(tienda);
        }


        //Metodo POST 
        [HttpPost, ActionName("BorrarTienda")]
        public ActionResult BorrarTienda(int id)
        {
            Tienda tienda = conexion.Tienda.Find(id);   
            conexion.Tienda.Remove(tienda);
            conexion.SaveChanges();
            return RedirectToAction("ListaTienda");
        }
    }
}