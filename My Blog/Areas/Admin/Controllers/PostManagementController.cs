using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogBusinessLogic;
using BlogModel;
using My_Blog.Areas.Admin.Models;

namespace My_Blog.Areas.Admin.Controllers
{
    public class PostManagementController : Controller
    {
        private BlogManager manager = new BlogManager();

        // GET: Admin/PostManagement
        public ActionResult Index() {
            var posts = this.manager.GetAllPosts().Select(post => new PostMaintainViewModel
            {
                Content = post.Content,
                Id = post.Id,
                Title = post.Title
            }).ToList();

            var postListViewModel = new PostMaintainListViewModel
            {
                Count = posts.Count,
                PageCount = 1,
                Pages = 1,
                Posts = posts
            };

            return View(postListViewModel);
        }

        public ActionResult Update(int id) {
            var post = this.manager.GetPostById(id);
            if (post == null) {
                return this.HttpNotFound();
            }

            var postViewModel = new PostMaintainViewModel
            {
                Content = post.Content,
                Id = post.Id,
                Title = post.Title
            };

            return this.View(postViewModel);
        }

        [HttpPost]
        public ActionResult Update(PostMaintainViewModel postViewModel) {
            var post = this.manager.GetPostById(postViewModel.Id);
            post.Content = postViewModel.Content;
            post.Title = postViewModel.Title;
            post.ModifyDate = DateTime.Now;
            this.manager.UpdatePost(post);
            return RedirectToAction("Index");
        }

        public ActionResult Insert() {
            return View(new PostMaintainViewModel());
        }

        [HttpPost]
        public ActionResult Insert(PostMaintainViewModel postViewModel) {
            var post = new Post
            {
                Title = postViewModel.Title,
                Content = postViewModel.Content,
                Author = "M",
                ClickCount = 0,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                IsPublish = true
            };
            this.manager.Insert(post);
            return RedirectToAction("Index");
        }
    }
}