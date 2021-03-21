using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ITSearch.Models.ViewModels
{
    public class ProcedureViewModel
    {
        public IEnumerable<Procedure> Procedures { get; set; }
        public Procedure Procedure { get; set; }
        public Search NewSearch { get; set; }
    }
}
