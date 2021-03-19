using ITSearch.Models.ProductInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models
{
    public class Computer
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        [Display(Name = "Model ID")]
        public string ModelIdentifier { get; set; }
        [Display(Name = "Model Numbers")]
        public IEnumerable<ModelNumber> ModelNumbers { get; set; }
        [Display(Name = "Configurations")]
        public IEnumerable<DeviceConfiguration> Configurations { get; set; }
        public int Size { get; set; }

    }
}
