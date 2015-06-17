using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KempsTuroTuro.Domain
{
    public class RawMaterialComponentItem
    {
        [Key, Column(Order = 0)]
        public int RawMaterialComponentId { get; set; }
        [ForeignKey("RawMaterialComponentId")]
        public virtual RawMaterialComponent Component { get; set; }

        [Key, Column(Order = 1)]
        public string ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
    }
}