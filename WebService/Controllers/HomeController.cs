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
        ClientesController objClientes;
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
                ViewBag.Status = "CORRECT UserNAme and Password";

                listaClientes = clienteManager.ObtenerClientes(); 
            }
            else
            {
                ViewBag.Status = "INCORRECT UserName or Password";

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
