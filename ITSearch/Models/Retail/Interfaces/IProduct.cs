namespace ITSearch.Models
{
    public interface IProduct
    {
        int ProductId { get; set; }
        string ProductName { get; set; }
        double ProductPrice { get; set; }
    }
}