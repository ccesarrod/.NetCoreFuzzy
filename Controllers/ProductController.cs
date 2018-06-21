using System.Collections.Generic;
using fuzzy.core.DataCore;
using fuzzy.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using fuzzy.core.DataCore.Repository;
using fuzzy.core.DataCore.Contracts;

namespace fuzzy_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository context)
        {
            _repository = context;
        }
        // GET: api/Product
        [HttpGet("[action]")]
        public IEnumerable<Product> GetProducts()
        {
            var mockProduct = new Product { ProductName = "Chai", CategoryID = 1, QuantityPerUnit = "10 boxes", UnitPrice = 18, UnitsInStock = 10, UnitsOnOrder = 1, ReorderLevel = 10, Discontinued = false, ProductID = 1 };
            var  list = _repository.GetAll();

            return list;
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
