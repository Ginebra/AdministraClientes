using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    public class HomeController : Controller
    {
     
        ClienteManager clienteManager;
        public ActionResult Index()
        {
            LoginModel obj = new LoginModel();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Index(LoginModel objuserlogin)
        {
            clienteManager = new ClienteManager();

            List<Cliente> listaClientes = new List<Cliente>();


            var display = Userloginvalues().Where(m => m.UserName == objuserlogin.UserName && m.UserPassword == objuserlogin.UserPassword).FirstOrDefault();
            if (display != null)
            {
                listaClientes = clienteManager.ObtenerClientes(); 
            }
            else
            {
                ViewBag.Status = "Usuario y/o contraseña incorrectos";

                return View("Index");
            }
            return View("ListaClientes",listaClientes);
        }
        public List<LoginModel> Userloginvalues()
        {
            List<LoginModel> cliente = new List<LoginModel>();
           clienteManager = new ClienteManager();

            cliente = clienteManager.ClienteLogin();
            return cliente;
        }

      
    }
}
