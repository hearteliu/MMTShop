using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTShop.Resources
{
    /// <summary>
    /// Class that defines the constant strings
    /// </summary>
    public static class Constants
    {
        public static partial class ConnectionStringNames
        {
            /// <summary>
            /// MMTShopConnection
            /// </summary>
            public const string MMTShopConnection = "MMTShopConnection";
        }

        public static partial class StoredProcedureNames
        {
            /// <summary>
            /// The GetFeaturedProducts stored procedure name
            /// </summary>
            public const string GetFeaturedProductsStoredProcedure = "GetFeaturedProducts";

            /// <summary>
            /// The GetCategoryNames stored procedure name
            /// </summary>
            public const string GetCategoryNamesStoredProcedure = "GetCategoryNames";

            /// <summary>
            /// The GetProductsByCategoryName stored procedure name
            /// </summary>
            public const string GetProductsByCategoryNameStoredProcedure = "GetProductsByCategoryName";
        }

        public static partial class ParameterNames
        {
            /// <summary>
            /// The CategoryName parameter string
            /// </summary>
            public const string CategoryNameParameter = "@categoryName";
        }

        public static partial class ColumnNames
        {
            /// <summary>
            /// The SKU column name
            /// </summary>
            public const string SkuColumn = "SKU";

            /// <summary>
            /// The Name column name
            /// </summary>
            public const string NameColumn = "Name";

            /// <summary>
            /// The Description column name
            /// </summary>
            public const string DescriptionColumn = "Description";

            /// <summary>
            /// The Price column name
            /// </summary>
            public const string PriceColumn = "Price";
        }
    }
}
