using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.IFixit
{

    public class IFixitSearchResult
    {
        public string search { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public int totalResults { get; set; }
        public bool moreResults { get; set; }
        public IFixitJsonResult[] results { get; set; }
    }

}
