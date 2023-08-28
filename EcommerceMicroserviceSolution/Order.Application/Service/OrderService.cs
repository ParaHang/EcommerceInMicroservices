using Order.Application.Interface;
using Order.Application.Repository;
using Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository) 
        { 
            _orderRepository = orderRepository;
        }
        public List<Orders> GetOrders()
        {
            return _orderRepository.GetOrders();
        }
        public async Task<Orders> GetOrderById(int id)
        {
            return await _orderRepository.GetOrdersById(id);
        }
        public async Task<bool> DeleteOrderById(int id)
        {
            return await _orderRepository.DeleteOrdersById(id);
        }
        public async Task<bool> UpdateOrder(Orders products)
        {
            return await _orderRepository.UpdateOrder(products);
        }
        public async Task<bool> CreateOrder(Orders products)
        {
            return await _orderRepository.CreateOrder(products);
        }
    }
}
