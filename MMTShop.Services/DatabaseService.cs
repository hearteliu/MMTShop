using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MMTShop.DTO;
using MMTShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MMTShop.Services
{
    public class DatabaseService : IDatabaseService
    {
        private string connectionString;
        private readonly IDtoConverterService dtoConverterService;
        private ILogger<DatabaseService> logger;

        public DatabaseService(IConfiguration config,
                               IDtoConverterService dtoConverterService,
                               ILogger<DatabaseService> logger)
        {
            connectionString = 
                config.GetConnectionString(Resources.Constants.ConnectionStringNames.MMTShopConnection);

            this.dtoConverterService = dtoConverterService;
            this.logger = logger;
        }

        /// <summary>
        /// Gets the featured products as list of DTO objects
        /// </summary>
        /// <returns>A list of ProductDTO objects</returns>
        public async Task<List<ProductDTO>> GetFeaturedProducts()
        {
            var results = new List<ProductDTO>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string storedProcedureName = 
                        Resources.Constants.StoredProcedureNames.GetFeaturedProductsStoredProcedure;

                    // Execute stored procedure using a Sql Command
                    using (var sqlCommand = new SqlCommand(storedProcedureName, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        await sqlConnection.OpenAsync();

                        var dataTable = new DataTable();

                        using (var sqlAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlAdapter.Fill(dataTable);
                        }

                        if (dataTable == null || dataTable.Rows.Count == 0)
                            return results;

                        // Convert rows to DTO
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var result = dtoConverterService.ConvertDataRowToProductDTO(row);

                            results.Add(result);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return results;
        }

        /// <summary>
        /// Gets the categories as list of DTO objects
        /// </summary>
        /// <returns>An list of CategoryDTO objects</returns>
        public async Task<List<CategoryDTO>> GetCategories()
        {
            var results = new List<CategoryDTO>();


            try
            {

                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    string storedProcedureName = 
                        Resources.Constants.StoredProcedureNames.GetCategoryNamesStoredProcedure;

                    // Execute stored procedure using a Sql Command
                    using (var sqlCommand = new SqlCommand(storedProcedureName, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        await sqlConnection.OpenAsync();

                        var dataTable = new DataTable();

                        using (var sqlAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlAdapter.Fill(dataTable);
                        }

                        if (dataTable == null || dataTable.Rows.Count == 0)
                            return results;

                        // Convert rows to DTO
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var result = dtoConverterService.ConvertDataRowToCategoryDTO(row);

                            results.Add(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return results;
        }

        /// <summary>
        /// Gets the products by category name as list of DTO objects
        /// </summary>
        /// <param name="categoryName">The category name</param>
        /// <returns>An of ProductDTO objects representing all products under the category name</returns>
        public async Task<List<ProductDTO>> GetProductsByCategoryName(string categoryName)
        {
            var results = new List<ProductDTO>();

            if (string.IsNullOrWhiteSpace(categoryName))
                return results;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string storedProcedureName = 
                        Resources.Constants.StoredProcedureNames.GetProductsByCategoryNameStoredProcedure;

                    // Execute stored procedure using a Sql Command
                    using (SqlCommand sqlCommand = new SqlCommand(storedProcedureName, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters
                            .AddWithValue(Resources.Constants.ParameterNames.CategoryNameParameter, categoryName);

                        await sqlConnection.OpenAsync();

                        var dataTable = new DataTable();

                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlAdapter.Fill(dataTable);
                        }

                        if (dataTable == null || dataTable.Rows.Count == 0)
                            return results;

                        // Convert rows to DTO
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var result = dtoConverterService.ConvertDataRowToProductDTO(row);

                            results.Add(result);
                        }
                    }
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
