namespace MMTShop.Models
{
    public class ProductModel
    {
        /// <summary>
        /// The product SKU
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// The product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The product Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The product Price
        /// </summary>
        public int Price { get; set; }
    }
}
