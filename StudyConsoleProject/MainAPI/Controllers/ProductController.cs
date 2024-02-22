using MainAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace MainAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Product 1", Description = "...", Price = 10M },
            new Product { Id = 2, Name = "Product 2", Description = "...", Price = 20M },
            new Product { Id = 3, Name = "Product 3", Description = "...", Price = 30M },
            new Product { Id = 4, Name = "Product 3", Description = "...", Price = 30M },
            new Product { Id = 5, Name = "Product 3", Description = "...", Price = 30M },
            new Product { Id = 6, Name = "Product 3", Description = "...", Price = 30M },
            new Product { Id = 7, Name = "Product 3", Description = "...", Price = 30M },
            new Product { Id = 8, Name = "Product 3", Description = "...", Price = 30M },
        };

        [HttpGet("{page}")]
        public ActionResult<ProductPart> GetWithPage(int page)
        {
            int size = 3;
            var output = new ProductPart()
            {
                CurrentPage = page,
                NumberPage = (products.Count() / 3) + 1,
                Products = products.Skip((page - 1) * size).Take(size).ToArray()
            };
            return Ok(output);
        }

        [HttpGet("id/{id}")]
        public ActionResult<Product> Get(int id) 
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound($"Not found product with id = {id}.");
        }

        /// <summary>
        /// Method for get product info by name
        /// </summary>
        /// <param name="name">Product name</param>
        /// <returns>One product</returns>
        /// <response code="201">If created is ok</response>
        [HttpGet("name/{name}")]
        public ActionResult<Product> Get(string name)
        {
            var product = products.FirstOrDefault(x => x.Name == name);
            if (product != null)
            {
                return product;
            }
            return NotFound($"Not found product with name = {name}.");
        }

        [HttpGet("price/{start}/{end}")]
        public ActionResult<IEnumerable<Product>> Get(decimal start, decimal end)
        {
            if (start > end)
            {
                return BadRequest($"Uncorrect data {start} > {end}.");
            }
            var product = products.Where(x => x.Price >= start && x.Price <= end);
            if (product.Any())
            {
                return Ok(product);
            }
            return NotFound($"Not found product with price between {start} and {end}.");
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product) 
        {
            var last = products.LastOrDefault();
            product.Id = last.Id + 1;
            products.Add(product);
            return Ok(product);
        }

        [HttpPut]
        public ActionResult<Product> Put([FromBody] Product newProduct)
        {
            var product = products.FirstOrDefault(x => x.Id == newProduct.Id);
            if (product != null)
            {
                product.Name = newProduct.Name;
                product.Description = newProduct.Description;
                product.Price = newProduct.Price;
                return Ok(product);
            }
            return NotFound($"Not found product with id = {newProduct.Id}.");
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                products.Remove(product);
            }
            return Ok(product);
        }
    }
}
