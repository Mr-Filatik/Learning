namespace MainAPI.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductPart
    {
        public int NumberPage { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<Product> Products { get; set;}
    }
}
