namespace ITSearch.Models
{
    public interface IItem
    {
        int Id { get; set; }
        string ItemName { get; set; }
        int ItemValue { get; set; }
    }
}