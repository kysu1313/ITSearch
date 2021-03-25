using ITSearch.Models.IFixit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.ViewModels
{
    public class WikiViewModel
    {
        public IFixitWiki IFixitWiki { get; set; }
        public JsonImage JsonImage { get; set; }
    }
}
