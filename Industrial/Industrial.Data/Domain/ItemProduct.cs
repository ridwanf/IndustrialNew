using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industrial.Data.Domain
{
    public class ItemProduct : BaseClass<int>
    {
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

    }
}
