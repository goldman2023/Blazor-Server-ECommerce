using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using QuickTie.Portal.Data.Repository.Interface;

namespace QuickTie.Portal.Data.Repository.Services
{
    public class LocalStorageRepository : ILocalStorageRepository
    {
        private readonly ProtectedLocalStorage _localStorage;

        public LocalStorageRepository(ProtectedLocalStorage protectedLocalStorage)
        {
            this._localStorage = protectedLocalStorage;
        }

        public async Task SetItemAsync<T>(string key, T item)
        {
            await _localStorage.SetAsync(key, item);
        }

        public async Task<T?> GetItemAsync<T>(string key)
        {
            var result = await _localStorage.GetAsync<T>(key);
            return result.Success ? result.Value : default;
        }

        public async Task RemoveItemAsync(string key)
        {
            await _localStorage.DeleteAsync(key);
        }
    }
}
