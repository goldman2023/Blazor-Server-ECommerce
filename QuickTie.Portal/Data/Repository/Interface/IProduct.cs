using QuickTie.Data.Models;
using QuickTie.Portal.Models;

namespace QuickTie.Portal.Data.Repository.Interface
{
    public interface IProduct
    {
        Task<(IEnumerable<Product>, long)> GetProductsAsync(int skip, int take, string searchValue, FilterParameter filterParameter);
        Task<IEnumerable<KeyValuePair<ProductType, long>>> GetCategoriesAsync(string searchValue, FilterParameter filterParameter);
        Dictionary<ProductType, ProductTypeInfo> GetCategoryWithCount(IEnumerable<KeyValuePair<ProductType, long>> documents); IEnumerable<ProductType> GetCategoryList();
        Task<Product> GetProductByIdAsync(string Id);
    }
}