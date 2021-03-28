using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.ProductInfo
{
    public class ModelNumber : IModelNumber
    {
        public ModelNumber() { }

        public ModelNumber(string v)
        {
            this.Model = v;
        }

        [Key]
        public int ModelId { get; set; }
        public string Model { get; set; }
    }
}
