using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KempsTuroTuro.Service.Model
{
    public class RecipeDetailsVm : EntityVm
    {
        public string Description { get; set; }
        public string Status { get; set; }
    }
}