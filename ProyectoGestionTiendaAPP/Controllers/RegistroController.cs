using ProyectoGestionTiendaAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Roles = ProyectoGestionTiendaAPP.Models.Roles;

namespace ProyectoGestionTiendaAPP.Controllers
{
    public class RegistroController : Controller
    {

    GestionHDEFactoryEntities conexion = new GestionHDEFactoryEntities();
   
       
    //Metodo GET para la vista registro
    public ActionResult Registro()
    {
       
        if (!conexion.Roles.Any())
        {
           
            var roles = new List<Roles>
                {
                    new Roles {NombreRol = "Vendedor"}, 
                    new Roles {NombreRol = "Cliente" } 
                };
          
            conexion.Roles.AddRange(roles);
            conexion.SaveChanges();
        }
        
        var rolesList = conexion.Roles.ToList();
       
        ViewBag.Roles = new SelectList(rolesList, "IdRol", "NombreRol");
        return View();
    }

   
    [HttpPost]
    
    public ActionResult Registro(Clientes clientes, int idRol) 
    {      
        if (ModelState.IsValid)
        {
            clientes.IdRol = idRol;
            clientes.Activo = true;           
            conexion.Clientes.Add(clientes);
            conexion.SaveChanges();           
            FormsAuthentication.SetAuthCookie(clientes.CorreoElectronico, false);
            
            return RedirectToAction( "AccesoCliente", "Acceso");
        }
       
        return View(clientes);
        }
    }
}
