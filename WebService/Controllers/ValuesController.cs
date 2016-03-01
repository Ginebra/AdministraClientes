using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers.API
{
    public class ValuesController : ApiController
    {

        private ClienteManager clienteManager = new ClienteManager();

         //GET api/values
        public List<Cliente> Get()
        {
            List<Cliente> lista = new List<Cliente>();

            lista = clienteManager.ObtenerClientes();

            return lista;
        }

        // GET api/values/5
        public LoginModel Get(int id, string nombre)
        {
            LoginModel client = new LoginModel();

            client = clienteManager.ObtenerCliente(id, nombre);

            return client;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
