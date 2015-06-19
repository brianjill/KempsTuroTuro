using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KempsTuroTuro.Interface;

namespace KempsTuroTuro.Controllers
{
    public class RecipeController : ApiController
    {
        private IUnitOfWork _uow;

        public RecipeController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET api/recipe
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/recipe/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/recipe
        public void Post([FromBody]string value)
        {
        }

        // PUT api/recipe/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/recipe/5
        public void Delete(int id)
        {
        }
    }
}
