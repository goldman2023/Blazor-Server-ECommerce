using QuickTie.Cloud.Repository;
using QuickTie.Data.Models;
using QuickTie.Portal.Data.Repository.Interface;
using QuickTie.Portal.Models;

namespace QuickTie.Portal.Data.Repository.Services
{
    public class OrderService : IOrder
    {
        private readonly IMongoRepository<Order> _orderRepository;

        public OrderService(IMongoRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(int skip, int take)
        {
            var orderQuery = _orderRepository.GetQueryable();
            return await _orderRepository.FindByFilterAsync(orderQuery, skip, take);
        }
    }
}