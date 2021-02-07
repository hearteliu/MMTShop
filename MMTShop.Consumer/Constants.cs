namespace MMTShop.Consumer
{
    public static class Constants
    {
        public static partial class Url
        {
            /// <summary>
            /// The application base url
            /// </summary>
            public const string BaseUrl = "http://localhost:5000";

            /// <summary>
            /// The GetProductsByCategoryName endpoint url
            /// </summary>
            public const string GetProductsByCategoryNameUrl = "{0}/api/shop/productsbycategoryname/{1}";

            /// <summary>
            /// The GetFeaturedProducts endpoint url
            /// </summary>
            public const string GetFeaturedProductsUrl = "{0}/api/shop/featuredproducts";

            /// <summary>
            /// The GetCategories entpoint url
            /// </summary>
            public const string GetCategoriesUrl = "{0}/api/shop/categories";
        }

        public static partial class Headers
        {
            /// <summary>
            /// The content type header
            /// </summary>
            public const string ContentType = "Content-Type:application/json";

            /// <summary>
            /// The accept header
            /// </summary>
            public const string Accept = "Accept:application/json";
        }

    }
}
