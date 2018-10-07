using fuzzy.core.DataCore.Contracts;
using fuzzy.core.Entities;
using fuzzy.core.Models;

namespace fuzzy.core.DataCore.Repository
{
    public class CustomerRepository : Repository<Customer>, IRepository<Customer>
    {
        public CustomerRepository(CustomerOrderContext context) : base(context)
        {
        }

    
    }

   
}
