using Microsoft.Extensions.Logging;
using MMTShop.Interfaces;
using MMTShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTShop.Services
{
    public class ShopService : IShopService
    {
        private readonly IDatabaseService databaseService;
        private readonly IDtoConverterService dtoConverterService;
        private readonly ILogger<ShopService> logger;

        public ShopService(IDatabaseService databaseService,
                           IDtoConverterService dtoConverterService,
                           ILogger<ShopService> logger)
        {
            this.databaseService = databaseService;
            this.dtoConverterService = dtoConverterService;
            this.logger = logger;
        }

        /// <summary>
        /// Gets the featured products
        /// </summary>
        /// <returns>List of product model</returns>
        public async Task<List<ProductModel>> GetFeaturedProducts() 
        {
            var results = new List<ProductModel>();

            try
            {
                // Get products as List of DTO
                var dtoResults = await databaseService.GetFeaturedProducts();

                if (dtoResults == null || dtoResults.Count == 0)
                    return results;

                // Convert to List of ProductModel
                foreach (var dto in dtoResults)
                {
                    var productModel = dtoConverterService.ConvertDtoToProductModel(dto);

                    results.Add(productModel);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return results;
        }

        /// <summary>
        /// Gets the categories
        /// </summary>
        /// <returns>List of category model</returns>
        public async Task<List<CategoryModel>> GetCategories() 
        {
            var results = new List<CategoryModel>();

            try
            {
                // Get categories as list of Category DTO
                var dtoResults = await databaseService.GetCategories();

                if (dtoResults == null || dtoResults.Count == 0)
                    return results;

                // Convert to list of CategoryModel
                foreach (var dto in dtoResults)
                {
                    var categoryModel = dtoConverterService.ConvertDtoToCategoryModel(dto);

                    results.Add(categoryModel);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return results;
        }

        /// <summary>
        /// Gets the products by category name
        /// </summary>
        /// <param name="ctaegoryName">The category name</param>
        /// <returns>List of product model</returns>
        public async Task<List<ProductModel>> GetProductsByCategoryName(string ctaegoryName)
        {
            var results = new List<ProductModel>();

            try
            {
                // Get products as List of DTO
                var dtoResults = await databaseService.GetProductsByCategoryName(ctaegoryName);

                if (dtoResults == null || dtoResults.Count == 0)
                    return results;

                // Convert to List of ProductModel
                foreach (var dto in dtoResults)
                {
                    var productModel = dtoConverterService.ConvertDtoToProductModel(dto);

                    results.Add(productModel);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return results;
        }
    }
}
