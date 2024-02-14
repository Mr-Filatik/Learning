using Microsoft.AspNetCore.Mvc;

namespace MVCSite.Controllers
{
    public class ShopController : Controller
    {
        public List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Monitor", Price = 15_000M },
                new Product() { Id = 2, Name = "System Block", Price = 50_000M},
                new Product() { Id = 3, Name = "Keyboard", Price = 1_000M}
            };

        public IActionResult Products()
        {
            ViewData["Year"] = 2024;
            ViewBag.Company = new Company()
            {
                Name = "SSTU",
                Description = "Saratov Technical University",
                Phone = "+7 (8452) 111-45-66",
                Address = "ul. Poli"
            };

            return View("Product", products);
        }

        public IActionResult Product(int id)
        {
            Product product = products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return View("Product", product);
            }
            return Products();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
