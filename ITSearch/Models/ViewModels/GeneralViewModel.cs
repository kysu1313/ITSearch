using ITSearch.Models.ProductInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.ViewModels
{
    public class GeneralViewModel
    {

        public IEnumerable<Procedure> Procedures { get; set; }
        public Procedure Procedure { get; set; }
        public IEnumerable<Computer> Computers { get; set; }
        public Computer Computer { get; set; }
        public IEnumerable<IOSDevice> IOSDevices { get; set; }
        public IOSDevice IOSDevice { get; set; }
        public IEnumerable<ModelNumber> ModelNumbers { get; set; }
        public ModelNumber ModelNumber { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public Service Service { get; set; }

        public Search NewSearch { get; set; }

    }

}
