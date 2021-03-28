using ITSearch.Models.ProductInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models
{
    public class Computer : IComputer
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        [DataType(DataType.Date)]
        public DateTime Year { get; set; }

        [Display(Name = "Year")]
        public string StringYear { get; set; }

        [Display(Name = "Model Identifier")]
        public string ModelIdentifier { get; set; }

        [Display(Name = "Model Number")]
        public IList<ModelNumber> ModelNumbers { get; set; }

        [Display(Name = "Configurations")]
        public IList<DeviceConfiguration> Configurations { get; set; }

        public int Size { get; set; }

        [Display(Name = "Additional Info")]
        public string AdditionalInfo { get; set; }

    }
}
