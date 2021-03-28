using System.Collections.Generic;

namespace ITSearch.Models
{
    public interface IProcedure
    {
        string Action { get; set; }
        IEnumerable<ToDo> ActionList { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string Notes { get; set; }
    }
}