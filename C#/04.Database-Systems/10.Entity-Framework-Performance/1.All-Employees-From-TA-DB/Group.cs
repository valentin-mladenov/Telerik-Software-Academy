namespace _1.All_Employees_From_TA_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Group
    {
        public Group()
        {
            Users = new HashSet<User>();
        }

        public int GroupID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
