using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppWASM.Shared
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [Range(10, 20)]
        public decimal Price { get; set; }
    }

    public class ProductPart
    {
        public int NumberPage { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
