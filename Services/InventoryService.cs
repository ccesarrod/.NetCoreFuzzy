using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fuzzy.core.Services
{
    public interface IInventoryService
    {
        int CheckProductQuantity(int ProductID);
        bool isLowStock(int ProductId);

        int UpdateInventory(int quantity);

        void Restock(int Proudct, int quantity);
    }

    public class InventoryService : IInventoryService
    {
        public int CheckProductQuantity(int ProductID)
        {
            throw new NotImplementedException();
        }

        public bool isLowStock(int ProductId)
        {
            throw new NotImplementedException();
        }

        public void Restock(int Proudct, int quantity)
        {
            throw new NotImplementedException();
        }

        public int UpdateInventory(int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
