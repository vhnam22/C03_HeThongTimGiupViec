using System;
using System.Collections.Generic;

namespace C03_HeThongTimGiupViec.Models
{
    public partial class Slide
    {
        public int SlideId { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsActive { get; set; }
        public int? Priority { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
