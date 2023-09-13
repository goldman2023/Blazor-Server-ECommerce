using QuickTie.Cloud.Repository;
using QuickTie.Data.Models;
using QuickTie.Portal.Data.Repository.Interface;
using QuickTie.Portal.Extensions;
using QuickTie.Portal.Models;
using MongoDB.Driver.Linq;

namespace QuickTie.Portal.Data.Repository.Services
{
    public class ProductService : IProduct
    {
        private readonly IMongoRepository<Product> _productsRepository;

        public ProductService(IMongoRepository<Product> productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<(IEnumerable<Product>, long)> GetProductsAsync(int skip = 0, int take = 0, string searchValue = "", FilterParameter? filterParameter = null)
        {
            var productQuery = _productsRepository.GetQueryable();

            // Filter by search value
            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                productQuery = productQuery.Where(p =>
                    p.Name.ToLower().Contains(searchValue.ToLower()) ||
                    p.ReferenceNumbers.Any(rn => rn.Name.ToLower().Contains(searchValue.ToLower()))
                );
            }

            // Filter by price range and category
            if (filterParameter != null)
            {
                productQuery = productQuery.Where(p => p.UnitCost >= filterParameter.Start && p.UnitCost <= filterParameter.End);

                if (filterParameter.SelectedCategory?.Any() ?? false)
                {
                    productQuery = productQuery.Where(p => filterParameter.SelectedCategory.Contains(p.ProductType));
                }
            }

            var products = await _productsRepository.FindByFilterAsync(productQuery, skip, take);
            var count = await _productsRepository.GetCountByFilterAsync(productQuery);

            return (products, count);
        }
        public async Task<IEnumerable<KeyValuePair<ProductType, long>>> GetCategoriesAsync(string searchValue, FilterParameter? filterParameter = null)
        {
            var categoryQuery = _productsRepository.GetQueryable();

            // Filter by search value
            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                categoryQuery = categoryQuery.Where(p =>
                    p.Name.ToLower().Contains(searchValue.ToLower()) ||
                    p.ReferenceNumbers.Any(rn => rn.Name.ToLower().Contains(searchValue.ToLower())));
            }

            // Filter by price range
            if (filterParameter != null)
            {
                categoryQuery = categoryQuery.Where(p => p.UnitCost >= filterParameter.Start && p.UnitCost <= filterParameter.End);
            }

            var products = await _productsRepository.FindByFilterAsync(categoryQuery);
            var categories = products.GroupBy(p => p.ProductType)
                                     .Select(g => new KeyValuePair<ProductType, long>(g.Key, g.Count()))
                                     .ToList();

            return categories;
        }

        public IEnumerable<ProductType> GetCategoryList()
        {
            return Enum.GetValues(typeof(ProductType)).Cast<ProductType>();
        }
        public Dictionary<ProductType, ProductTypeInfo> GetCategoryWithCount(IEnumerable<KeyValuePair<ProductType, long>> documents)
        {
            var productTypeAndCounts = GetCategoryList()
                                       .ToDictionary(productType => productType,
                                                     productType => new ProductTypeInfo
                                                     {
                                                         Type = productType,
                                                         DisplayName = productType.GetEnumDisplayName(),
                                                         Count = 0
                                                     });

            foreach (var document in documents)
            {
                productTypeAndCounts[document.Key].Count = document.Value;
            }

            return productTypeAndCounts;
        }

        public async Task<Product> GetProductByIdAsync(string Id)
        {
            return await _productsRepository.FindByIdAsync(Id);
        }
    }
}
