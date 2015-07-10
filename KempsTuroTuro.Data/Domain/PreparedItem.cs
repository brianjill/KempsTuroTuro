using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KempsTuroTuro.Data.Domain
{
    /*
     * A sub-type of Item that is manufactured (or prepared) for sale from a set of BulkItem via a Recipe. The distinction from StockItem 
     * being that PreparedItem is not booked into inventory when the item is manufactured; nor is it removed from inventory when it is sold; 
     * rather the inventory for the BulkItem constituent parts as defined by the recipe is reduced when the PreparedItem is sold.
     */

    /*
     PreparedItem "Farmhouse Breakfast", is made up of 2 eggs, 1 tomato, 3 rashers of bacon & two slices of toast. 
     * As part of the 'end of day' process, total number of farmhouse breakfasts sold is combined with the relevant 
     * recipe to get the total number of eggs, tomatos, packets of bacon & loaves of bread sold. PreparedItem "Deluxe Carwash" 
     * is made up of 100ml detergent & 500ml wax (along with hot & cold water). Again, individual car-washes are totaled across the day,
     * and inventory for detergent & wax are decremented as part of the 'end-of-day' process.
     */
    public class PreparedItem
    {
        [StringLength(32)]
        [Key]
        public string ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        //The number of minutes that a prepared food item may be held ready for sale. At the end of this time, the item must not be sold to a customer.
        public decimal FoodItemHoldingTime { get; set; }
    }
}