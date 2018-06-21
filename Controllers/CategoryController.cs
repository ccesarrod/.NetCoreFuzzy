using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fuzzy.core.DataCore.Contracts;
using fuzzy.core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fuzzy_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _repository;

        public CategoryController(IRepository<Category> repository)
        {
            this._repository = repository;
        }

        // GET: api/Category
        [HttpGet("[action]")]
        public IEnumerable<Category> GetCategories()
        {
           
            var list = _repository.GetAll();

            return list;
        }
    }
}