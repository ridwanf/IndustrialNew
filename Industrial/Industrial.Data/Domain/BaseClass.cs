using System;
using Core;
using Core;

namespace Industrial.Data.Domain
{
    public abstract class BaseClass<T> : BaseEntity<T>
    {
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}