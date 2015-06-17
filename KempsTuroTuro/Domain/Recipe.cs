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
    public class Recipe
    {
        public int Id { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public int RecipeVariationOf { get; set; }

        public DateTime LastChangeDate { get; set; }

        public DateTime CreateDate { get; set; }

        public RecipeStatus StatusCode { get; set; }

        public string Description { get; set; }
    }
}