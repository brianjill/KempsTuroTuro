using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KempsTuroTuro.Domain
{
    public enum RecipeStatus
    {
       Active,
       Inactive,
       Testing
    }

    /*
     * The Recipe or Bill of Materials that is used to assemble a PreparedItem from other (usually Bulk) Items. 
     * A recursive relationship "variations produce " allows recipe variations to be recorded.
     */
    public class Recipe
    {
        
        public int Id { get; set; }

        public string ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        public int? RecipeVariationOf { get; set; }

        public DateTime? LastChangeDate { get; set; }

        public DateTime CreateDate { get; set; }

        public RecipeStatus StatusCode { get; set; }

        public string Description { get; set; }

        
    }
}