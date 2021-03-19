using System.Collections.Generic;

namespace ITSearch.Models
{
    public interface IService
    {
        int ServiceId { get; set; }
        IEnumerable<Service> RelatedServices { get; set; }
        string ServiceName { get; set; }
        public string AdditionalInfo { get; set; }
        double ServicePrice { get; set; }
    }
}