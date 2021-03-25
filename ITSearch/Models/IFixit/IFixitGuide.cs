using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.IFixit
{


    public class IFixitGuide
    {
        public string conclusion_raw { get; set; }
        public string conclusion_rendered { get; set; }
        public string difficulty { get; set; }
        public object[] documents { get; set; }
        public object[] flags { get; set; }
        public int guideid { get; set; }
        public JsonImage image { get; set; }
        public string introduction_raw { get; set; }
        public string introduction_rendered { get; set; }
        public string featured_document_embed_url { get; set; }
        public string featured_document_thumbnail_url { get; set; }
        public string locale { get; set; }
        public object[] parts { get; set; }
        public Prerequisite[] prerequisites { get; set; }
        public Step[] steps { get; set; }
        public string subject { get; set; }
        public string summary { get; set; }
        public string time_required { get; set; }
        public int time_required_min { get; set; }
        public int time_required_max { get; set; }
        public string title { get; set; }
        public Tool[] tools { get; set; }
        public string type { get; set; }
        public int revisionid { get; set; }
        public int created_date { get; set; }
        public int published_date { get; set; }
        public int modified_date { get; set; }
        public int prereq_modified_date { get; set; }
        public bool _public { get; set; }
        public object[] comments { get; set; }
        public string category { get; set; }
        public string url { get; set; }
        public int patrol_threshold { get; set; }
        public bool can_edit { get; set; }
        public bool favorited { get; set; }
        public Author author { get; set; }
        public string langid { get; set; }
        public object featured_documentid { get; set; }
        public object intro_video_url { get; set; }
        public object intro_video { get; set; }
        public bool completed { get; set; }
    }

    public class Prerequisite
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
        public object[] flags { get; set; }
        public JsonImage image { get; set; }
    }

    public class Step
    {
        public string title { get; set; }
        public Line[] lines { get; set; }
        public int guideid { get; set; }
        public int stepid { get; set; }
        public int orderby { get; set; }
        public int revisionid { get; set; }
        public Media media { get; set; }
        public Comment[] comments { get; set; }
    }

    public class Media
    {
        public string type { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
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

    public class Line
    {
        public string text_raw { get; set; }
        public string bullet { get; set; }
        public int level { get; set; }
        public object lineid { get; set; }
        public string text_rendered { get; set; }
    }

}
