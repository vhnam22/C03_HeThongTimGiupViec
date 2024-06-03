using C03_HeThongTimGiupViec.Models;

namespace C03_HeThongTimGiupViec.Repositories.Interface
{
    public interface IComplaintRepository
    {
        //Get all complaint
        public List<Complaint> GetAllComplaints();

        //Get complaint by account SENT
        public List<Complaint> GetComplaintByAccountSent(string id);

        //Get complaint by account RECEIVED
        public List<Complaint> GetComplaintByAccountReceived(string id);

        //Create new complaint 
        public bool CreateComplaint(Complaint complaint);

        //Update complaint
        public bool UpdateComplaint(Complaint complaint);

        //Delete complaints 
        public bool DeleteComplaint(int id);


    }
}
