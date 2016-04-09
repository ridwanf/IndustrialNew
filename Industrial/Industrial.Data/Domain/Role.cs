namespace Industrial.Data.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class Role:BaseClass<Guid>
    {
        public Role()
        {
            Users = new HashSet<User>();
        }


        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
