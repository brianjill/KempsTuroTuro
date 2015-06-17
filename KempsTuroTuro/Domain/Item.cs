using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KempsTuroTuro.Domain
{
    public enum ItemType
    {
        Stock,        //stock
        Service,        //service
        Combined,        //combined
        Prepared,       //prepared
        SelectedGroup,       //selected group
    }

    /*
     * The lowest level of merchandise for which inventory and sales records are retained within the retail store. 
     * It is analogous to the SKU ( Stock Keeping Unit).
     */
    public class Item
    {
        [StringLength(32)]
        [Key]
        public string Id { get; set; }

        public bool AuthorizedForSaleFlag { get; set; }
        public bool DiscountFlag { get; set; }
        public bool PriceAuditFlag { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string LongDescription { get; set; }

        public ItemType TypeCode { get; set; }

        public bool SubstituteIdentifiedFlag { get; set; }


    }
}