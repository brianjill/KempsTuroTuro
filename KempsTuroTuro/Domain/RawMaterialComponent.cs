using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KempsTuroTuro.Domain
{
    /*
     * Definition: An abstract standardized Recipe ingredient that is re-used in many recipes. Used to define a common quantity & UnitOfMeasure 
     * for the Ingredient. Eg: "5oz Tomato Ketchup " which may be used once in a small hamburger and twice or three times in a large hamburger, 
     * and BBQ sauce is an acceptable substitute.
     */
    public class RawMaterialComponent
    {
        public int Id { get; set; }

        public string ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        public string UnitOfMeasureCode { get; set; }
        [ForeignKey("UnitOfMeasureCode")]
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }

        public decimal UnitAmount { get; set; }

        //A short description denoting what the ingredient is. Eg: 5oz Ketchup/BBQ
        [StringLength(255)]
        public string Description { get; set; }
        
    }
}