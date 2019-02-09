using System.Collections.Generic;
using System.Linq;
using fuzzy.core.DataCore.Contracts;
using fuzzy.core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace fuzzy_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _repository;
        private readonly IProductRepository _productRepository;

        public CategoryController(IRepository<Category> repository, IProductRepository productRepository)
        {
            this._repository = repository;
            this._productRepository = productRepository;
        }

        // GET: api/Category
        [HttpGet("[action]")]
        public IEnumerable<Category> GetCategories()
        {
           
            var list = _repository.GetAll();

            return list;
        }

        // GET: api/Category/5
        [HttpGet("[action]/{id}")]
        public IEnumerable<Product> GetProductsByCategoryId(int id)
        {
            var mockProduct = new Product { ProductName = "Chai", CategoryID = 1, QuantityPerUnit = "10 boxes", UnitPrice = 18, UnitsInStock = 10, UnitsOnOrder = 1, ReorderLevel = 10, Discontinued = false, ProductID = 1 };
            var category = _repository.Find(x => x.CategoryID == id).SingleOrDefault();
            return _productRepository.Find(p => p.CategoryID == category.CategoryID);
            //4265852142
            //{
            //    mockProduct
            //};
            
        }
    }
}