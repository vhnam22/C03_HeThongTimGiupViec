using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace C03_HeThongTimGiupViec.Repositories
{
    public class ComplaintRepository : IComplaintRepository
    {
        C03_HeThongTimGiupViecContext _context;

        public ComplaintRepository(C03_HeThongTimGiupViecContext context)
        {
            _context = context;
        }

        //Get all complaint
        public List<Complaint> GetAllComplaints()
        {
            try
            {
                List<Complaint> lst = _context.Complaints
                    .Include(x => x.ComplaintByNavigation)
                    .Include(x => x.ComplaintAgainstNavigation)
                    .OrderByDescending(x => x.ComplaintDate)
                    .ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get complaint by account SENT
        public List<Complaint> GetComplaintByAccountSent(string id)
        {
            try
            {
                Guid accId = Guid.Parse(id);
                List<Complaint> lst = _context.Complaints
                    .Include(x => x.ComplaintByNavigation)
                    .Include(x => x.ComplaintAgainstNavigation)
                    .Where(x => x.ComplaintByNavigation.AccountId == accId)
                    .OrderByDescending(x => x.ComplaintDate)
                    .ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get complaint by account RECEIVED
        public List<Complaint> GetComplaintByAccountReceived(string id)
        {
            try
            {
                Guid accId = Guid.Parse(id);
                List<Complaint> lst = _context.Complaints
                    .Include(x => x.ComplaintByNavigation)
                    .Include(x => x.ComplaintAgainstNavigation)
                    .Where(x => x.ComplaintAgainstNavigation.AccountId == accId)
                    .OrderByDescending(x => x.ComplaintDate)
                    .ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Create new complaint 
        public bool CreateComplaint(Complaint complaint)
        {
            try
            {
                if (complaint != null)
                {
                    _context.Complaints.Add(complaint);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Update complaint
        public bool UpdateComplaint(Complaint complaint)
        {
            try
            {
                if (complaint != null)
                {
                    Complaint _complaint = _context.Complaints.FirstOrDefault(x => x.ComplaintId == complaint.ComplaintId);
                    if (_complaint != null)
                    {
                        _complaint.Description = complaint.Description;
                        _complaint.Attachments = complaint.Attachments;
                        _complaint.IsCorect = complaint.IsCorect;
                        _complaint.Status = complaint.Status;
                        _complaint.ResponseComplaintId = complaint.ResponseComplaintId != null ? complaint.ResponseComplaintId: null ;

                        _context.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Delete complaints 
        public bool DeleteComplaint(int id)
        {
            try
            {
                Complaint complaint = _context.Complaints.FirstOrDefault(x => x.ComplaintId == id);
                if (complaint != null)
                {
                    _context.Complaints.Remove(complaint);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
