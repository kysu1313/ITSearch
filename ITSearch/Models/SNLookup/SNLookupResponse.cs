using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.SNLookup
{

    public class SNLookupResponse
    {
        public string anonymised { get; set; }
        public Configurationcode configurationCode { get; set; }
        public string coverageUrl { get; set; }
        public string id { get; set; }
        public Manufacturing manufacturing { get; set; }
        public string serialType { get; set; }
        public Uniqueid uniqueId { get; set; }
    }

    public class Configurationcode
    {
        public Appleinternalnameclass appleInternalNameClass { get; set; }
        public string code { get; set; }
        public object colour { get; set; }
        public Image image { get; set; }
        public object ram { get; set; }
        public string skuHint { get; set; }
        public object storage { get; set; }
    }

    public class Appleinternalnameclass
    {
        public string id { get; set; }
    }

    public class Image
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Manufacturing
    {
        public string city { get; set; }
        public string company { get; set; }
        public string country { get; set; }
        public string date { get; set; }
        public string flag { get; set; }
        public string id { get; set; }
    }

    public class Uniqueid
    {
        public int productionNo { get; set; }
        public string value { get; set; }
    }

}
