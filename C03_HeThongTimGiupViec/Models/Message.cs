using System;
using System.Collections.Generic;

namespace C03_HeThongTimGiupViec.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public string SentByAccountId { get; set; }
        public string ReceiveByAccountId { get; set; }
        public string? MessageText { get; set; }
        public DateTime? SentOn { get; set; }
        public DateTime? ReadOn { get; set; }

        public virtual Account? ReceiveByAccount { get; set; }
        public virtual Account? SentByAccount { get; set; }
    }
}
