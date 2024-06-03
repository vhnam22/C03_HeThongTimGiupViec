using System;
using System.Collections.Generic;

namespace C03_HeThongTimGiupViec.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? ContractId { get; set; }
        public decimal? Amount { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime? PaymentDate { get; set; }

        public virtual Contract? Contract { get; set; }
    }
}
