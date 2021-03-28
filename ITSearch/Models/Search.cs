using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models
{
    public class Search : ISearch
    {
        [Key]
        public int SearchId { get; set; }
        [Display(Name = "Search")]
        public string SearchText { get; set; }
    }
}
