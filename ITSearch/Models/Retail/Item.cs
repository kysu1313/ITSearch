using ITSearch.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models
{
    public class Item : IItem
    {

        // Products

        public int Id { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Price")]
        public int ItemValue { get; set; }

    }
}
