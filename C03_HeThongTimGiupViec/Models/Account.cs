using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace C03_HeThongTimGiupViec.Models
{
    public partial class Account :IdentityUser
    {
        public Account()
        {
            ComplaintComplaintAgainstNavigations = new HashSet<Complaint>();
            ComplaintComplaintByNavigations = new HashSet<Complaint>();
            Contracts = new HashSet<Contract>();
            MessageReceiveByAccounts = new HashSet<Message>();
            MessageSentByAccounts = new HashSet<Message>();
            Posts = new HashSet<Post>();
            ReviewRevieweds = new HashSet<Review>();
            ReviewReviewers = new HashSet<Review>();
            Services = new HashSet<Service>();
        }

        public Guid AccountId { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? ProfilePicture { get; set; }
        public string Status { get; set; } = null!;
        public virtual ICollection<Complaint> ComplaintComplaintAgainstNavigations { get; set; }
        public virtual ICollection<Complaint> ComplaintComplaintByNavigations { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Message> MessageReceiveByAccounts { get; set; }
        public virtual ICollection<Message> MessageSentByAccounts { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Review> ReviewRevieweds { get; set; }
        public virtual ICollection<Review> ReviewReviewers { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
