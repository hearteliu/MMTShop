using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MMTShop.Interfaces;
using MMTShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ILogger<ShopController> logger;
        private readonly IShopService shopService;

        public ShopController(ILogger<ShopController> logger, IShopService shopService)
        {
            this.logger = logger;
            this.shopService = shopService;
        }

        /// <summary>
        /// This endpoint gets the featured products
        /// </summary>
        /// <returns>A list of ProductModel</returns>
        [HttpGet("featuredproducts")]
        public async Task<List<ProductModel>> GetFeaturedProducts()
        {
            var results = new List<ProductModel>();

            try
            {
                results = await shopService.GetFeaturedProducts();
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);

                return results;
            }

            return results;
        }

        /// <summary>
        /// This endpoint gets the categories
        /// </summary>
        /// <returns>List of CategoryModel</returns>
        [HttpGet("categories")]
        public async Task<List<CategoryModel>> GetCategories()
        {
            var results = new List<CategoryModel>();

            try
            {
                results = await shopService.GetCategories();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return results;
            }

            return results;
        }

        /// <summary>
        /// This endpoint gets products by category name
        /// </summary>
        /// <param name="categoryName">The category name</param>
        /// <returns>List of ProductModel</returns>
        [HttpGet("productsbycategoryname/{categoryName}")]
        public async Task<List<ProductModel>> GetProductsByCategoryName(string categoryName)
        {
            var results = new List<ProductModel>();

            if (string.IsNullOrWhiteSpace(categoryName))
                return results;

            try
            {
                results = await shopService.GetProductsByCategoryName(categoryName);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return results;
            }

            return results;
        }
    }
}
