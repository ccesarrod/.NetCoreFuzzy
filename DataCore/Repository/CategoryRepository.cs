using fuzzy.core.DataCore.Contracts;
using fuzzy.core.Entities;

namespace fuzzy.core.DataCore.Repository
{
    public class CategoryRepository: Repository<Category>, IRepository<Category>
    {
        public CategoryRepository(CustomerOrderContext context) : base(context)
        {

        }
    }
}
