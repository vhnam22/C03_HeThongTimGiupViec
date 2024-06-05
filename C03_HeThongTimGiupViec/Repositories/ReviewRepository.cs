using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.Repositories.Interface;

namespace C03_HeThongTimGiupViec.Repositories
{
    public class ReviewRepository: IReviewRepository
    {
        C03_HeThongTimGiupViecContext _context;

        public ReviewRepository(C03_HeThongTimGiupViecContext context)
        {
            _context = context;
        }

        //Get all review
        public List<Review> GetAllReviews()
        {
            try
            {
                List<Review> lst = _context.Reviews.OrderByDescending(x => x.ReviewDate).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get review of reviewer
        public List<Review> GetReviewsOfReviewer(string id)
        {
            try
            {
                List<Review> lst = _context.Reviews
                    .Where(x => x.ReviewerId == id)
                    .OrderByDescending(x => x.ReviewDate).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get review of reviewed
        public List<Review> GetReviewsOfReviewed(string id)
        {
            try
            {
                List<Review> lst = _context.Reviews
                    .Where(x => x.ReviewedId == id)
                    .OrderByDescending(x => x.ReviewDate).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Create new review
        public bool CreateReview(Review review)
        {
            try
            {
                if (review != null)
                {
                    _context.Reviews.Add(review);
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

        //Update a review
        public bool UpdateReview(Review review)
        {
            try
            {
                if (review != null)
                {
                    Review r = _context.Reviews.FirstOrDefault(x => x.ReviewId == review.ReviewId);
                    if (r != null)
                    {
                        r.Rating = review.Rating;
                        r.Comment = review.Comment;
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

        //Delete a review
        public bool DeleteReview(int id)
        {
            try
            {
                Review r = _context.Reviews.FirstOrDefault(x => x.ReviewId == id);
                if (r != null)
                {
                    _context.Reviews.Remove(r);
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
