using MMTShop.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTShop.Interfaces
{
    public interface IDatabaseService
    {
        /// <summary>
        /// Gets the featured products as list of DTO objects
        /// </summary>
        /// <returns>A list of ProductDTO objects</returns>
        Task<List<ProductDTO>> GetFeaturedProducts();

        /// <summary>
        /// Gets the categories as list of DTO objects
        /// </summary>
        /// <returns>An list of CategoryDTO objects</returns>
        Task<List<CategoryDTO>> GetCategories();

        /// <summary>
        /// Gets the products by category name as list of DTO objects
        /// </summary>
        /// <param name="categoryName">The category name</param>
        /// <returns>An of ProductDTO objects representing all products under the category name</returns>
        Task<List<ProductDTO>> GetProductsByCategoryName(string categoryName);
    }
}
