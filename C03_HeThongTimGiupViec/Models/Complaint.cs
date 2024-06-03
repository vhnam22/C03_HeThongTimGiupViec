using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace C03_HeThongTimGiupViec.Models
{
    public partial class Complaint
    {
        public int ComplaintId { get; set; }
        public string ComplaintBy { get; set; }
        public string ComplaintAgainst { get; set; }
        public string? Description { get; set; }
        public string? Attachments { get; set; }
        public DateTime? ComplaintDate { get; set; }
        public bool? IsCorect { get; set; }

        [ForeignKey(nameof(ComplaintBy))]
        public virtual Account ComplaintAgainstNavigation { get; set; }
        [ForeignKey(nameof(ComplaintAgainst))]
        public virtual Account ComplaintByNavigation { get; set; }
    }
}
