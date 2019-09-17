using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Voorraadsysteem_ToolsForEver.Models
{
    public class ProductFabrikant_regel
    {
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Key, Column(Order = 2)]
        public int FabrikantId { get; set; }

        public virtual Fabrikant Fabrikant { get; set; }
    }
}
