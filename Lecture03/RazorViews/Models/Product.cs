namespace RazorViews.Models
{
    public enum Category { Bakery, Beverages, Cereals, Dairy, Vegetables }

    public class Product
    {
        private static int _id = 0;

        public int ID { get; } = ++_id;
        public string Name { get; set; }
        public Category Category { get; set; }
        public decimal? Amount { get; set; }
        public decimal? PricePerUnit { get; set; }
        public bool Discount { get; set; }

        public bool? InStock => Amount > 0;
    }
}
