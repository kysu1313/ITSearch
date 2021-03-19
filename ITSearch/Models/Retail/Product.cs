using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models
{
    public class Product : IProduct
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name = ("SKU"))]
        public string sku { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }
    }
}
