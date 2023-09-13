namespace QuickTie.Portal.Data.Repository.Interface
{
    public interface ILocalStorageRepository
    {
        Task SetItemAsync<T>(string key, T item);
        Task<T> GetItemAsync<T>(string key);
        Task RemoveItemAsync(string key);

    }
}