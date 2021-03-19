using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.ViewModels
{
    public class ServiceViewModel
    {

        public IEnumerable<Service> Services { get; set; }
        public Service Service { get; set; }
        public Search NewSearch { get; set; }
    }
}
