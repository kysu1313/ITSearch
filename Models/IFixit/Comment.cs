namespace ITSearch.Models.IFixit
{
    public class Comment
    {
        public int commentid { get; set; }
        public string locale { get; set; }
        public string context { get; set; }
        public int contextid { get; set; }
        public object parentid { get; set; }
        public Author author { get; set; }
        public string title { get; set; }
        public string text_raw { get; set; }
        public string text_rendered { get; set; }
        public int rating { get; set; }
        public int date { get; set; }
        public int modified_date { get; set; }
        public string status { get; set; }
        public object[] replies { get; set; }
    }

}
