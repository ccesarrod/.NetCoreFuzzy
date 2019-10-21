using fuzzy.core.DataCore.Contracts;
using fuzzy.core.Entities;

namespace fuzzy.core.DataCore.Repository
{
    public class CartDetailsRepository : Repository<CartDetails>, ICartDetailsRepository
    {
        public CartDetailsRepository(CustomerOrderContext contextDb) : base(contextDb)
        {
        }
    }
}
