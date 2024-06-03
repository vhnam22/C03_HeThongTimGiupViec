using System;
using System.Collections.Generic;

namespace C03_HeThongTimGiupViec.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public string ReviewerId { get; set; }
        public string ReviewedId { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime? ReviewDate { get; set; }

        public virtual Account? Reviewed { get; set; }
        public virtual Account? Reviewer { get; set; }
    }
}
