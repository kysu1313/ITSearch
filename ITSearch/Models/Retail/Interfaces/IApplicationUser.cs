namespace ITSearch.Models
{
    public interface IApplicationUser
    {
        int UserId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}