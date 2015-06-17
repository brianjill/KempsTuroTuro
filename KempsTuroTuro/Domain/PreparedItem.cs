using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KempsTuroTuro.Domain
{
    public class PreparedItem
    {
        [StringLength(32)]
        [Key]
        public string ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        public decimal FoodItemHoldingTime { get; set; }
    }
}