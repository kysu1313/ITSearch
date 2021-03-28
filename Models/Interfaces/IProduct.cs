namespace ITSearch.Models
{
    public interface IProduct
    {
        string Description { get; set; }
        bool Inventoried { get; set; }
        int Inventory { get; set; }
        int ProductId { get; set; }
        double ProductPrice { get; set; }
        string sku { get; set; }
    }
}