using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fuzzy_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/Test
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Test/5
        [HttpGet]
        public string GetTest(int id)
        {
            return "value";
        }

        // POST: api/Test
        [HttpPost]
        public void PostTest([FromBody] string value)
        {
       }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public void PutTest(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteTest(int id)
        {
        }
    }
}
