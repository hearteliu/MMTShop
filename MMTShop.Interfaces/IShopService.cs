using MMTShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTShop.Interfaces
{
    public interface IShopService
    {
        /// <summary>
        /// Gets the featured products
        /// </summary>
        /// <returns>List of product model</returns>
        Task<List<ProductModel>> GetFeaturedProducts();

        /// <summary>
        /// Gets the categories
        /// </summary>
        /// <returns>List of category model</returns>
        Task<List<CategoryModel>> GetCategories();

        /// <summary>
        /// Gets the products by category name
        /// </summary>
        /// <param name="ctaegoryName">The category name</param>
        /// <returns>List of product model</returns>
        Task<List<ProductModel>> GetProductsByCategoryName(string ctaegoryName);
    }
}
