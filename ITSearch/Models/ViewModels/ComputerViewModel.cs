using ITSearch.Models.ProductInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.ViewModels
{
    public class ComputerViewModel
    {
        public IEnumerable<Computer> Computers{ get; set; }
        public Computer Computer { get; set; }
        public IEnumerable<ModelNumber> ModelNumbers { get; set; }
        public ModelNumber ModelNumber { get; set; }


    }
}
