using ITSearch.Models.IFixit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.ViewModels
{
    public class iFixitViewModel
    {
        public IFixitSearchResult IFixitSearchResult { get; set; }
        public IFixitJsonResult IFixitJsonResult { get; set; }
        public JsonImage JsonImage { get; set; }
        public Search NewSearch { get; set; }
    }
}
