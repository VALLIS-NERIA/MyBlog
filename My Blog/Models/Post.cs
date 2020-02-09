using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace My_Blog.Models {

    public class PostViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string Author { get; set; }

        public static PostViewModel Create(BlogModel.Post post) {
            return new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreateDate = post.CreateDate,
                ModifyDate = post.ModifyDate,
                Author = post.Author
            };
        }
    }

    public class PostListViewModel {
        public List<PostViewModel> Posts { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
        public int PageCount { get; set; }
    }


}