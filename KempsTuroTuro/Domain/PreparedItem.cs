using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KempsTuroTuro.Domain
{
    /*
     * A sub-type of Item that is manufactured (or prepared) for sale from a set of BulkItem via a Recipe. The distinction from StockItem 
     * being that PreparedItem is not booked into inventory when the item is manufactured; nor is it removed from inventory when it is sold; 
     * rather the inventory for the BulkItem constituent parts as defined by the recipe is reduced when the PreparedItem is sold.
     */
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