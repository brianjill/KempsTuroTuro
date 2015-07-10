using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KempsTuroTuro.Data.Domain
{
    public enum UnitOfMeasureType
    {
        Weight,        //weight or mass
        Length,        //Length
        Cube,        //cube (length x width x depth)
        Volume,       //volume
        Each,       //discrete items (each)
    }
    /*
     * Identifies and describes valid units of measure that are used throughout the model.
     */
    public class UnitOfMeasure
    {
        [Key]
        public string Code { get; set; }

        public bool EnglishMetricFlag { get; set; }
        [StringLength(40)]
        public string Name { get; set; }

        public UnitOfMeasureType TypeCode { get; set; }
        
        [StringLength(255)]
        public string Description { get; set; }

    }
}