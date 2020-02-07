using BlogModel;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace BlogRepository {
    public class BlogRepository {
        public static List<Post> posts = new List<Post>()
        {
            new Post() {Id = 1, Author = "mercury", Content = "文章内容", CreateDate = DateTime.Now, ModifyDate = DateTime.Now, Title = "文章一"}
        };

        public List<Post> GetAll() { return posts; }

        public Post GetById(int id) { return posts.Where(p => p.Id == id).FirstOrDefault(); }

    }
}
