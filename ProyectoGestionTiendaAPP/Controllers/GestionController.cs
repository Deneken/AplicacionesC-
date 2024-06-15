using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoGestionTiendaAPP.Controllers
{
    public class GestionController : Controller
    { 



    //Metodo GET para cargar la pagina GestionAdministrador
    public ActionResult GestionVendedor()
    {
        ViewBag.rolcliente = 1;
        return View();
    }
    //Metodo GET para GestionUsuario
    public ActionResult GestionCliente()
    {    
        ViewBag.rolcliente = 2;
        return View();
    }
    //Metodo para CerrarSesion
    public ActionResult CerrarSesion()
    {
        //Cierra la sesión del usuario y me redirecciona al inicio de la aplicación
        FormsAuthentication.SignOut();
        return RedirectToAction("Index", "Home");
    }
        }
    }