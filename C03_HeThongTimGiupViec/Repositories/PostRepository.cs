using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace C03_HeThongTimGiupViec.Repositories
{
    public class PostRepository: IPostRepository
    {
        private readonly C03_HeThongTimGiupViecContext _context;

        public PostRepository(C03_HeThongTimGiupViecContext context)
        {
            _context = context;
        }

        //Get all posts
        public List<Post> GetAllPosts()
        {
            try
            {
                List<Post> lst = _context.Posts
                    .Include(x => x.Service)
                    .Include(x => x.Account)
                    .OrderByDescending(x => x.PostDate)
                    .ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get post detail
        public Post GetPostById(int id)
        {
            try
            {
                Post post = _context.Posts
                    .Include(x => x.Service)
                    .Include(x => x.Account)
                    .FirstOrDefault(x => x.PostId == id);
                return post;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get post by account 
        public List<Post> GetPostsByAccountId(string accId)
        {
            try
            {
                List<Post> lst = _context.Posts
                    .Include(x => x.Service)
                    .Include(x => x.Account)
                    .Where(x => x.AccountId == accId)
                    .OrderByDescending(x => x.PostDate)
                    .ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Create a new post (status: 1_do not have contract, 0_have contract)
        public bool CreatePost(Post post)
        {
            post.Status = 1;
            try
            {
                _context.Posts.Add(post);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Update posts that do not have a contract
        public bool UpdatePost(Post post)
        {
            try
            {
                Post _post = _context.Posts.FirstOrDefault(x => x.PostId == post.PostId && x.Status == 1);
                if (_post != null)
                {
                    _post.Description = _post.Description;
                    _post.Status = post.Status;
                    _post.ServiceId = post.ServiceId;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        

    }
}
