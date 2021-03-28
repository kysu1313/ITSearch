using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.IFixit
{

    public class IFixitWiki
    {
        public string dataType { get; set; }
        public int wikiid { get; set; }
        public string title { get; set; }
        public string display_title { get; set; }
        public string _namespace { get; set; }
        public string summary { get; set; }
        public string url { get; set; }
        public string text { get; set; }
        public JsonImage image { get; set; }
        public int modified_date { get; set; }
    }

}
