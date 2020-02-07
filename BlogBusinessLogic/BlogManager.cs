using System;
using BlogRepository;
using BlogModel;
using System.Collections.Generic;
using System.Linq;
using BlogRepository.MySQL;

namespace BlogBusinessLogic {
    public class BlogManager {

        private BlogRepository.BlogRepository repository = new BlogRepository.BlogRepository();
        private BlogRepository.MySQL.BlogRepositoryMySql mysql = new BlogRepositoryMySql();

        public List<Post> GetAllPosts() { return this.mysql.GetAllPosts(); }

        public Post GetPostById(int id) { return this.mysql.GetPostById(id); }

        public void UpdatePost(Post post) { this.mysql.Update(post); }

        public void Insert(Post post) { this.mysql.Insert(post); }

        public void Delete(Post post) { this.mysql.Delete(post); }
    }
}
