using Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Interface
{
    public interface IOrderService 
    {
        List<Orders> GetOrders();
        Task<Orders> GetOrderById(int id);
        Task<bool> DeleteOrderById(int id);
        Task<bool> UpdateOrder(Orders orders);
        Task<bool> CreateOrder(Orders orders);
    }
}
