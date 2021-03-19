using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models
{
    public class Service : IService
    {
        [Key]
        public int ServiceId { get; set; }
        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }
        [Display(Name = "Service Price")]
        public double ServicePrice { get; set; }
        [Display(Name = "Additional Info")]
        public string AdditionalInfo { get; set; }
        [Display(Name = "Related Services")]
        public IEnumerable<Service> RelatedServices { get; set; }
        public IEnumerable<Product> RelatedProducts { get; set; }
        public IEnumerable<Item> RelatedItems { get; set; }
    }
}
