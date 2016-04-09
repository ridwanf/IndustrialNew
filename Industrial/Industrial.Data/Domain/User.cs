namespace Industrial.Data.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class User:BaseClass<Guid>
    {
      
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
