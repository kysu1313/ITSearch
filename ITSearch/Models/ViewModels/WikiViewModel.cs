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
        public IFixitWikiPost WikiPost { get; set; }
        public Contents_Json ContentsJson { get; set; }
        public Content Content { get; set; }
        public Mark Mark { get; set; }
        public Attrs Attrs { get; set; }
        public Parts Parts { get; set; }
        public Category Category { get; set; }
        public Ancestor Ancestor { get; set; }
        public Featured_Guides FeaturedGuides { get; set; }
        public Guide Guide { get; set; }
    }
}
