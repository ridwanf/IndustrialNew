using System.Collections.Generic;
using System.Collections.Specialized;

namespace Industrial.Data.Domain
{
    public class Branch:BaseClass<int>
    {
        public string Name { get; set; }
        public int? ParentBranchId { get; set; }
        public virtual Branch ParentBranch { get; set; }
        public virtual ICollection<Branch> Children { get; set; }
    }
}