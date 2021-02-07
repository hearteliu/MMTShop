using System;

namespace MMTShop.Consumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing MMTShop API");

            var apiBaseUrl = Constants.Url.BaseUrl;
            var getFeaturedProductsUrl = string.Format(Constants.Url.GetFeaturedProductsUrl, apiBaseUrl);
            var getCategoriesUrl = string.Format(Constants.Url.GetCategoriesUrl, apiBaseUrl);

            Console.WriteLine();
            Console.WriteLine($"Calling { getFeaturedProductsUrl }...");

            var result = Consumer.Consume(getFeaturedProductsUrl);

            Console.WriteLine();
            Console.WriteLine("Result:");
            Console.WriteLine($"{ result }");

            Console.WriteLine();
            Console.WriteLine($"Calling { getCategoriesUrl }...");

            result = Consumer.Consume(getCategoriesUrl);

            Console.WriteLine();
            Console.WriteLine("Result:");
            Console.WriteLine($"{ result }");

            Console.WriteLine();
            Console.WriteLine("In order to get products by category, please insert category name: ");

            var categoryName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(categoryName))
            {
                Console.WriteLine("Please insert category name: ");
                categoryName = Console.ReadLine();
            }

            categoryName = categoryName.Trim();

            var getProductsByCategoryNameUrl = string.Format(Constants.Url.GetProductsByCategoryNameUrl, apiBaseUrl, categoryName);

            Console.WriteLine();
            Console.WriteLine($"Calling { getProductsByCategoryNameUrl }...");

            result = Consumer.Consume(getProductsByCategoryNameUrl);

            Console.WriteLine();
            Console.WriteLine("Result:");
            Console.WriteLine($"{ result }");

            Console.ReadLine();
        }
    }
}
