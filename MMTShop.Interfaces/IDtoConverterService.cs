using MMTShop.DTO;
using MMTShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MMTShop.Interfaces
{
    public interface IDtoConverterService
    {
        /// <summary>
        /// Converts the specified DTO to ProductModel
        /// </summary>
        /// <param name="productDto">The DTO</param>
        /// <returns>An object of type ProductModel</returns>
        ProductModel ConvertDtoToProductModel(ProductDTO productDto);

        /// <summary>
        /// Converts the specified DTO to CategoryModel
        /// </summary>
        /// <param name="categoryDto">The DTO</param>
        /// <returns>An object of type CategoryModel</returns>
        CategoryModel ConvertDtoToCategoryModel(CategoryDTO categoryDto);

        /// <summary>
        /// Converts the data row to ProductDTO
        /// </summary>
        /// <param name="dataRow">The data row</param>
        /// <returns>A ProductDTO object</returns>
        ProductDTO ConvertDataRowToProductDTO(DataRow dataRow);

        /// <summary>
        /// Converts the data row to CategoryDTO
        /// </summary>
        /// <param name="dataRow">The data row</param>
        /// <returns>A CategoryDTO object</returns>
        CategoryDTO ConvertDataRowToCategoryDTO(DataRow dataRow);
    }
}
