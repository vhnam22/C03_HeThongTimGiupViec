using System;
using System.Collections.Generic;

namespace C03_HeThongTimGiupViec.Models
{
    public partial class Post
    {
        public Post()
        {
            Contracts = new HashSet<Contract>();
        }

        public int PostId { get; set; }
        public string AccountId { get; set; }
        public int? ServiceId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Address { get; set; }
        public DateTime? PostDate { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Service? Service { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
