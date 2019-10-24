using fuzzy.core.Models;
using System;

namespace fuzzy.core.Services
{
    public interface IOrderService
    {
        Order ProcessOrder(Order order);
        Order Create(OrderDetails details);
    }

    public class OrderService : IOrderService
    {
        private readonly IInventoryService _inventoryService;

        public OrderService(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        public Order Create(OrderDetails details)
        {
            //check inventory product
            var stock = _inventoryService.CheckProductQuantity(details.ProductId);

            if (stock < details.Quantity)
            {
                throw new ApplicationException("Item out stock");
            }

            _inventoryService.UpdateInventory(details.Quantity);

            return new Order { CustomerID = details.CustomerID, OrderID = 2, OrderItem = details };
        }

        public Order ProcessOrder(Order order)
        {
            var stock = _inventoryService.CheckProductQuantity(order.OrderItem.ProductId);
            if (stock < order.OrderItem.Quantity)
            {
                throw new ApplicationException("failed to create order");
            }
            return order;
        }
    }
}
