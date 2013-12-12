using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JotAThought.Model;

namespace JotAThought.Domain.Contracts
{
    public interface IPostService
    {
        List<Post> GetRecentPosts();
        Post GetPost(int id);
        void CreatePost(Post post);
        void EditPost(Post post);
        void DeletePost(int id);
    }
}
