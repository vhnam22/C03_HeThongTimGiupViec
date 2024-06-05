using System;
using System.Collections.Generic;

namespace C03_HeThongTimGiupViec.Models
{
    public partial class Service
    {
        public Service()
        {
            Posts = new HashSet<Post>();
            Accounts = new HashSet<Account>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public string? Description { get; set; }
        public string Logo { get; set; }
        public int ViewCount { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
