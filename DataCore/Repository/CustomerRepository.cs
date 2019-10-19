using System.Collections.Generic;
using System.Linq;
using fuzzy.core.DataCore.Contracts;
using fuzzy.core.Entities;
using fuzzy.core.Models;

namespace fuzzy.core.DataCore.Repository
{
    public class CustomerRepository: Repository<Customer> ,ICustomerRepository
    {
        private readonly IProductRepository _productRepository;

        public CustomerRepository(CustomerOrderContext context, IProductRepository product): base (context)
        {
            
           _productRepository = product;
          
        }

       
    }

   
}
