using System.ComponentModel.DataAnnotations;

namespace ITSearch.Models.IFixit
{
    public class IFixitJsonResult
    {
        public string dataType { get; set; }
        public int wikiid { get; set; }
        [Display(Name = "Title")]
        public string title { get; set; }
        public string display_title { get; set; }
        public string _namespace { get; set; }
        [Display(Name = "Summary")]
        public string summary { get; set; }
        [Display(Name = "Link")]
        public string url { get; set; }
        public string text { get; set; }
        public JsonImage image { get; set; }
        public int modified_date { get; set; }
        public int guideid { get; set; }
        public string locale { get; set; }
        public int revisionid { get; set; }
        public int prereq_modified_date { get; set; }
        public string type { get; set; }
        [Display(Name = "Category")]
        public string category { get; set; }
        [Display(Name = "Subject")]
        public string subject { get; set; }
        [Display(Name = "Difficulty")]
        public string difficulty { get; set; }
        public int time_required_max { get; set; }
        public bool _public { get; set; }
        public int userid { get; set; }
        public string username { get; set; }
        public string[] flags { get; set; }
    }

}
