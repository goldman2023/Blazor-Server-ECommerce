using QuickTie.Portal.Models;

namespace QuickTie.Portal.Data.Repository.Interface
{
    public interface ICartService
    {
        Task AddItemAsync(CartItem item);
        Task UpdateItemAsync(CartItem item);
        Task RemoveItemAsync(string itemId);
        Task<Cart> GetCartAsync();
    }
}
