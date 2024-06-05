using C03_HeThongTimGiupViec.Models;

namespace C03_HeThongTimGiupViec.Repositories.Interface
{
    public interface IReviewRepository
    {
        //Get all review
        public List<Review> GetAllReviews();

        //Get review of reviewer
        public List<Review> GetReviewsOfReviewer(string id);

        //Get review of reviewed
        public List<Review> GetReviewsOfReviewed(string id);

        //Create new review
        public bool CreateReview(Review review);

        //Update a review
        public bool UpdateReview(Review review);

        //Delete a review
        public bool DeleteReview(int id);
    }
}
