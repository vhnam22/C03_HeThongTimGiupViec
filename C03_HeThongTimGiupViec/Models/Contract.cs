using System;
using System.Collections.Generic;

namespace C03_HeThongTimGiupViec.Models
{
    public partial class Contract
    {
        public Contract()
        {
            Payments = new HashSet<Payment>();
        }

        public int ContractId { get; set; }
        public int? PostId { get; set; }
        public string HandymanId { get; set; }
        public double Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Status { get; set; } 

        public virtual Account? Handyman { get; set; }
        public virtual Post? Post { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
