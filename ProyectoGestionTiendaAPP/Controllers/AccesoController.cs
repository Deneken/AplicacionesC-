using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoGestionTiendaAPP.Models;

namespace ProyectoGestionTiendaAPP.Controllers
{
    public class AccesoController : Controller
    {
        GestionHDEFactoryEntities conexion = new GestionHDEFactoryEntities();   
        // GET: Acceso
        public ActionResult AccesoCliente()
        {
            return View();
        }

        //Metodo POST
        [HttpPost]
        public ActionResult AccesoCliente(Clientes datos)
        {
            //Verifico las credenciales de Usuario
            if (ModelState.IsValid)
            {
                
                var cliente = conexion.Clientes.FirstOrDefault(u => u.CorreoElectronico == datos.CorreoElectronico && u.Clave == datos.Clave);
                
                if (cliente != null)
                {
                   
                    if (cliente.IdRol == 1)
                    {                       
                        return RedirectToAction("GestionVendedor", "Gestion");
                    }
                    else if (cliente.IdRol == 2)
                    {                     
                        return RedirectToAction("GestionCliente", "Gestion");
                    }
                    else
                    {                
                        return RedirectToAction("Error", "Gestion");
                    }
                }
            }          
            return View();
        }
    }
}

