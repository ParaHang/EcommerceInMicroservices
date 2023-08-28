using Microsoft.EntityFrameworkCore;
using Order.Application.Repository;
using Order.Domain;
using Order.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public OrderRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public List<Orders> GetOrders()
        {
            return _applicationDbContext.Orders.ToList();
        }
        public async Task<Orders> GetOrdersById(int id)
        {
            var order = await _applicationDbContext.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (order != null)
            {
                return order;
            }
            return new Orders();
        }
        public async Task<bool> UpdateOrder(Orders orders)
        {
            var order = await _applicationDbContext.Orders.Where(x => x.Id == orders.Id).FirstOrDefaultAsync();
            if (order != null)
            {
                _applicationDbContext.Orders.Update(orders);
                _applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task<bool> CreateOrder(Orders products)
        {
            await _applicationDbContext.Orders.AddAsync(products);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteOrdersById(int id)
        {
            var order = await _applicationDbContext.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (order != null)
            {
                _applicationDbContext.Orders.Remove(order);
                _applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
