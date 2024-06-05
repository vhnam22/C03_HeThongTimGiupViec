using C03_HeThongTimGiupViec.Models;

namespace C03_HeThongTimGiupViec.Repositories.Interface
{
    public interface IPostRepository
    {
        //Get all posts
        public List<Post> GetAllPosts();

        //Get post detail
        public Post GetPostById(int id);

        //Get post by account 
        public List<Post> GetPostsByAccountId(string accId);

        //Create a new post (status: 1_do not have contract, 0_have contract)
        public bool CreatePost(Post post);

        //Update posts that do not have a contract
        public bool UpdatePost(Post post);


    }
}
