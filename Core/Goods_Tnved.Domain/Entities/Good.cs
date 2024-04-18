using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods_Tnved.Domain.Entities
{
    public sealed class Good
    {
        public int ID { get; set; }
        public string? CODE { get; set; }

        public string? DEFIS { get; set; }

        public string? NAME { get; set; }
        
        public int? PARENT_ID { get; set; }

        public List<Good>? Children { get; set; }

    }
}
