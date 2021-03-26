using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.IFixit
{

    public class IFixitWikiPost
    {
        public int wikiid { get; set; }
        public string langid { get; set; }
        public string _namespace { get; set; }
        public string title { get; set; }
        public int revisionid { get; set; }
        public string contents_raw { get; set; }
        public Contents_Json contents_json { get; set; }
        public string contents_rendered { get; set; }
        public bool can_edit { get; set; }
        //public object[] flags { get; set; }
        public JsonImage image { get; set; }
        //public object[] documents { get; set; }
        public string display_title { get; set; }
        public Ancestor[] ancestors { get; set; }
        public string description { get; set; }
        //public object[] children { get; set; }
        public Category_Lists category_lists { get; set; }
        public Featured_Guides[] featured_guides { get; set; }
        public Guide[] guides { get; set; }
        //public object[] related_wikis { get; set; }
        public string solutions_url { get; set; }
        public Parts parts { get; set; }
        public Tool[] tools { get; set; }
        public int repairability_score { get; set; }
        //public object[] category_info { get; set; }
        //public object source_revisionid { get; set; }
        //public object[] info { get; set; }
    }

    public class Contents_Json
    {
        public string type { get; set; }
        public Content[] content { get; set; }
    }

    public class Content
    {
        public string type { get; set; }
        public string text { get; set; }
        public object attrs { get; set; }
        public Content[] content { get; set; }
        public Mark[] marks { get; set; }
    }

    public class Mark
    {
        public string type { get; set; }
        public Attrs attrs { get; set; }
    }

    public class Attrs
    {
        public string href { get; set; }
        public bool target { get; set; }
    }

    public class Image
    {
        public int id { get; set; }
        public string guid { get; set; }
        public string mini { get; set; }
        public string thumbnail { get; set; }
        public string _140x105 { get; set; }
        public string _200x150 { get; set; }
        public string standard { get; set; }
        public string _440x330 { get; set; }
        public string medium { get; set; }
        public string large { get; set; }
        public string huge { get; set; }
        public string original { get; set; }
    }

    public class Category_Lists
    {
    }

    public class Parts
    {
        public string url { get; set; }
        public int total { get; set; }
        public Category[] categories { get; set; }
    }

    public class Category
    {
        public string tag { get; set; }
        public int count { get; set; }
        public string url { get; set; }
    }

    public class Ancestor
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

    public class Featured_Guides
    {
        public string dataType { get; set; }
        public int guideid { get; set; }
        public string locale { get; set; }
        public int revisionid { get; set; }
        public int modified_date { get; set; }
        public int prereq_modified_date { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public string subject { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string difficulty { get; set; }
        public int time_required_max { get; set; }
        public bool _public { get; set; }
        public int userid { get; set; }
        public string username { get; set; }
        public string[] flags { get; set; }
        public JsonImage image { get; set; }
    }

    public class Guide
    {
        public string dataType { get; set; }
        public int guideid { get; set; }
        public string locale { get; set; }
        public int revisionid { get; set; }
        public int modified_date { get; set; }
        public int prereq_modified_date { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public string subject { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string difficulty { get; set; }
        public int time_required_max { get; set; }
        public bool _public { get; set; }
        public int userid { get; set; }
        public string username { get; set; }
        public string[] flags { get; set; }
        public JsonImage image { get; set; }
    }

}
