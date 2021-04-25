using ITSearch.Models.ProductInfo;
using ITSearch.Models.IFixit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.ViewModels
{
    public class GeneralViewModel
    {

        public string DeviceName { get; set; }

        public virtual IEnumerable<Procedure> Procedures { get; set; }
        public virtual Procedure Procedure { get; set; }
        public virtual IEnumerable<Computer> Computers { get; set; }
        public virtual Computer Computer { get; set; }
        public virtual IEnumerable<IOSDevice> IOSDevices { get; set; }
        public virtual IOSDevice IOSDevice { get; set; }
        public virtual IEnumerable<ModelNumber> ModelNumbers { get; set; }
        public virtual ModelNumber ModelNumber { get; set; }
        public virtual IEnumerable<Service> Services { get; set; }
        public virtual Service Service { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
        public virtual Product Product { get; set; }


        public virtual IFixitSearchResult IFixitSearchResult { get; set; }
        public virtual IFixitJsonResult IFixitJsonResult { get; set; }
        public virtual IFixitGuide IFixitGuide { get; set; }
        public virtual IFixitWiki IFixitWiki { get; set; }
        public virtual IEnumerable<IFixitJsonResult> IFixitGuides { get; set; }
        public virtual IEnumerable<IFixitJsonResult> IFixitWikis { get; set; }
        public virtual JsonImage JsonImage { get; set; }

        public virtual Search NewSearch { get; set; }

    }

}
