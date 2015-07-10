using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KempsTuroTuro.Data.Domain
{
    /*
     A single ingredient in a Recipe
     */
    public class RecipeLineItem
    {
        [Key, Column(Order = 0)]
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }

        [Key, Column(Order = 1)]
        public int RawMaterialComponentId { get; set; }
        [ForeignKey("RawMaterialComponentId")]
        public virtual RawMaterialComponent Component{ get; set; }

        public decimal ServingsCount { get; set; }

        public bool CostInclusiveFlag { get; set; }
        public bool WasteFlag { get; set; }
        public bool KeyIngredientFlag { get; set; }
    }
}