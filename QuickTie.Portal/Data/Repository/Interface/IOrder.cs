using QuickTie.Data.Models;

namespace QuickTie.Portal.Data.Repository.Interface
{
    public interface IOrder
    {
        Task<IEnumerable<Order>> GetOrdersAsync(int skip, int take);
    }
}
