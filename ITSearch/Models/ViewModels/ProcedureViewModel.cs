using DynamicVML;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ITSearch.Models.ViewModels
{
    public class ProcedureViewModel
    {
        public IEnumerable<Procedure> Procedures { get; set; }
        public Procedure Procedure { get; set; }
        public Search NewSearch { get; set; }
        [Display(Name = "Task")]
        public ToDo NewToDo { get; set; }
        [Display(Name = "Task List")]
        public DynamicList<ToDo> ToDos { get; set; } = new DynamicList<ToDo>();
    }
}
