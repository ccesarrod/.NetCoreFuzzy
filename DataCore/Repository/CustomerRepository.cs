using fuzzy.core.DataCore.Contracts;
using fuzzy.core.Entities;

namespace fuzzy.core.DataCore.Repository
{
    public class CustomerRepository : Repository<Customer>, IRepository<Customer>
    {
        public CustomerRepository(CustomerOrderContext context) : base(context)
        {
        }

    
    }
}
