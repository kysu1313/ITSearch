namespace ITSearch.Models.IFixit
{
    public class Author
    {
        public int userid { get; set; }
        public string username { get; set; }
        public object unique_username { get; set; }

        public int join_date { get; set; }
        public JsonImage image { get; set; }
        public int reputation { get; set; }
        public string url { get; set; }
        public int[] teams { get; set; }
        public string[] privileges { get; set; }
    }

}
