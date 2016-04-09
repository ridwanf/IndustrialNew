using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industrial.Data.Domain
{
    public class UnitOfMeasure:BaseClass<int>
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
