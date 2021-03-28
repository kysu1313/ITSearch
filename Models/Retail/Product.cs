using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models
{

    /**
     * GOAL: link this with RepairShopr for updated prices / inventory
     */

    public class Product : IProduct
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name = ("SKU"))]
        public string sku { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }
        [Display(Name = "Inventoried")]
        public bool Inventoried { get; set; }
        [Display(Name = "Inventory")]
        public int Inventory { get; set; }
    }
}
