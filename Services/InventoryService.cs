using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fuzzy.core.Services
{
   public  interface IInventoryService
    {
        int CheckProductQuantity(int ProductID);
        bool isLowStock(int ProductId);

        string Restock(int Proudct);
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

        public string Restock(int Proudct)
        {
            throw new NotImplementedException();
        }
    }
}
