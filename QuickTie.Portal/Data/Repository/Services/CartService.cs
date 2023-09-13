using QuickTie.Data.Models;
using QuickTie.Portal.Data.Repository.Interface;
using QuickTie.Portal.Models;

namespace QuickTie.Portal.Data.Repository.Services
{
    public class CartService : ICartService
    {
        private const string CartKey = "cart";
        private readonly ILocalStorageRepository _localStorageService;

        public CartService(ILocalStorageRepository localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task AddItemAsync(CartItem item)
        {
            var cart = await GetCartAsync();
            var foundItem = cart.Items.FirstOrDefault(i => i.ItemId == item.ItemId);
            if (foundItem != null)
            {
                foundItem.Quantity += item.Quantity;
            }
            else
            {
                cart.Items.Add(item);
            }
            await _localStorageService.SetItemAsync(CartKey, cart);
        }
        public async Task UpdateItemAsync(CartItem updatedItem)
        {
            var cart = await GetCartAsync();
            var item = cart.Items.FirstOrDefault(i => i.ItemId == updatedItem.ItemId);
            if (item != null)
            {
                item.Quantity = updatedItem.Quantity;
                await _localStorageService.SetItemAsync(CartKey, cart);
            }
            else
            {
                throw new Exception("Item not found in the cart");
            }
        }
        public async Task RemoveItemAsync(string itemId)
        {
            var cart = await GetCartAsync();
            var item = cart.Items.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null)
            {
                cart.Items.Remove(item);
                await _localStorageService.SetItemAsync(CartKey, cart);
            }
            else
            {
                throw new Exception("Item not found in the cart");
            }
        }

        public async Task<Cart> GetCartAsync()
        {
            return await _localStorageService.GetItemAsync<Cart>(CartKey) ?? new Cart();
        }
    }
}
