using C03_HeThongTimGiupViec.ViewModels;
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
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? ProfilePicture { get; set; }
        public int Status { get; set; }
        public string Email { get; set; }
        public int TotalStar { get; set; }
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
