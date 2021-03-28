using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models
{
    public class Procedure : IProcedure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Action")]
        public string Action { get; set; }
        [Display(Name = "Actions")]
        public IEnumerable<ToDo> ActionList { get; set; }
        public string Notes { get; set; }
    }

    public class ToDo
    {
        public int Id { get; set; }
        [Display(Name = "Task")]
        public string NewTask { get; set; }
        [Display(Name = "Procedure Notes")]
        public string Notes { get; set; }
    }
}
