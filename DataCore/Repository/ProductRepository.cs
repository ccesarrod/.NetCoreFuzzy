using fuzzy.core.DataCore.Contracts;
using fuzzy.core.Entities;

namespace fuzzy.core.DataCore.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        public ProductRepository(CustomerOrderContext context) : base(context)
        {
        }


    }
}
