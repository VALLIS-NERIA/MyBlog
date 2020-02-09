using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using BlogBusinessLogic;
using My_Blog.Models;

namespace My_Blog.Controllers {
    public class PostController : Controller {
        // GET: Post
        //获取文章列表
        private BlogManager manager = new BlogManager();
        public ActionResult Index() {
            var posts = this.manager.GetAllPosts().Select(PostViewModel.Create).ToList();
            
            var postListViewModel = new PostListViewModel()
            {
                Count = posts.Count,
                PageCount = 1,
                Pages = 1,
                Posts = posts
            };
            return View(postListViewModel);
        }

        public ActionResult Get(int id) {
            var post = this.manager.GetPostById(id);
            if (post == null) return this.HttpNotFound();
            this.ViewBag.Post = post;

            return View();
        }
    }
}