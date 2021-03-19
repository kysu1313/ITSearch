using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.ProductInfo
{
    public class ModelNumber
    {
        [Key]
        public int ModelId { get; set; }
        public string Model { get; set; }
    }
}
