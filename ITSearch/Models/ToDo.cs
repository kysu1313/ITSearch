using System.ComponentModel.DataAnnotations;

namespace ITSearch.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        [Display(Name = "Task")]
        public string NewTask { get; set; }
        [Display(Name = "Procedure Notes")]
        public string Notes { get; set; }
    }
}