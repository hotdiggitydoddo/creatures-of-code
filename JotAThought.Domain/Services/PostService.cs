using JotAThought.Domain.Contracts;
using JotAThought.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JotAThought.Domain.Services
{
    public class PostService : IPostService
    {
        private IRepository<Post> _repo;

        public PostService(IRepository<Post> repo)
        {
            _repo = repo;
        }

        public List<Post> GetRecentPosts()
        {
            return _repo.GetAll().OrderBy(p => p.CreatedOn).Reverse().Take(10).ToList();
        }

        public void CreatePost(Post post)
        {
            _repo.Add(post);
            _repo.Save();
        }

        public Post GetPost(int id)
        {
            return _repo.GetById(id);
        }

        public void EditPost(Post post)
        {
            var postToEdit = _repo.GetById(post.ID);
            postToEdit.Title = post.Title;
            postToEdit.Content = post.Content;
            postToEdit.CreatedOn = post.CreatedOn;
            _repo.Update(postToEdit);
        }

        public void DeletePost(int id)
        {
            _repo.Remove(_repo.GetById(id));
            _repo.Save();
        }
    }
}
