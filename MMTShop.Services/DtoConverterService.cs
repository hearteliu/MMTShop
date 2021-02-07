using MMTShop.DTO;
using MMTShop.Interfaces;
using MMTShop.Models;
using System;
using System.Data;

namespace MMTShop.Services
{
    public class DtoConverterService : IDtoConverterService
    {
        /// <summary>
        /// Converts the specified DTO to ProductModel
        /// </summary>
        /// <param name="productDto">The DTO</param>
        /// <returns>An object of type ProductModel</returns>
        public ProductModel ConvertDtoToProductModel(ProductDTO productDto)
        {
            var productModel = new ProductModel();

            if (productDto == null)
                return productModel;

            productModel.SKU = productDto.SKU;
            productModel.Name = productDto.Name;
            productModel.Description = productDto.Description;
            productModel.Price = productDto.Price;

            return productModel;
        }

        /// <summary>
        /// Converts the specified DTO to CategoryModel
        /// </summary>
        /// <param name="categoryDto">The DTO</param>
        /// <returns>An object of type CategoryModel</returns>
        public CategoryModel ConvertDtoToCategoryModel(CategoryDTO categoryDto)
        {
            var categoryModel = new CategoryModel();

            if (categoryDto == null)
                return categoryModel;

            categoryModel.Name = categoryDto.Name;

            return categoryModel;
        }

        /// <summary>
        /// Converts the data row to ProductDTO
        /// </summary>
        /// <param name="dataRow">The data row</param>
        /// <returns>A ProductDTO object</returns>
        public ProductDTO ConvertDataRowToProductDTO(DataRow dataRow)
        {
            var productDTO = new ProductDTO();

            var skuValue = dataRow[Resources.Constants.ColumnNames.SkuColumn];

            if (skuValue != null)
                productDTO.SKU = skuValue.ToString();

            var nameValue = dataRow[Resources.Constants.ColumnNames.NameColumn];

            if (nameValue != null)
                productDTO.Name = nameValue.ToString();

            var descriptionValue = dataRow[Resources.Constants.ColumnNames.DescriptionColumn];

            if (descriptionValue != null)
                productDTO.Description = descriptionValue.ToString();

            var priceValue = dataRow[Resources.Constants.ColumnNames.PriceColumn];

            if (priceValue != null)
                productDTO.Price = Int32.Parse(priceValue.ToString());

            return productDTO;
        }

        /// <summary>
        /// Converts the data row to CategoryDTO
        /// </summary>
        /// <param name="dataRow">The data row</param>
        /// <returns>A CategoryDTO object</returns>
        public CategoryDTO ConvertDataRowToCategoryDTO(DataRow dataRow)
        {
            var categoryDto = new CategoryDTO();

            var nameValue = dataRow[Resources.Constants.ColumnNames.NameColumn];

            if (nameValue != null)
                categoryDto.Name = nameValue.ToString();

            return categoryDto;
        }

    }
}
