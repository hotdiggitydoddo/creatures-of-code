using JotAThought.Domain.Contracts;
using JotAThought.Model;
using JotAThought.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JotAThought.Web.Controllers
{
    public class PostsController : Controller
    {
        private IPostService _service;

        public PostsController(IPostService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View(_service.GetRecentPosts());
        }

        [Authorize(Roles="none")]
        public ActionResult Create()
        {
            var model = new CreatePostViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreatePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UpdateMe)
                    _service.EditPost(new Post { Author = model.Author, Title = model.Title, Content = model.Content });
                else
                    _service.CreatePost(new Post { Author = model.Author, Title = model.Title, Content = model.Content, CreatedOn = DateTime.UtcNow.AddHours(-8.0f) });
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new CreatePostViewModel();
            var post = _service.GetPost(id);
            model.Author = post.Author;
            model.Content = post.Content;
            model.Title = post.Title;
            model.UpdateMe = true;

            return View("Create", model);
        }

        public ActionResult Delete(int id)
        {
            _service.DeletePost(id);
            return RedirectToAction("Index");
        }


    }
}
