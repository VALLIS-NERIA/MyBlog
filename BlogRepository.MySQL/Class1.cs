using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogModel;
using MySql.Data.MySqlClient;

namespace BlogRepository.MySQL
{
    public class BlogRepositoryMySql {
        private static class ColumnName {
            public const string Id = "ID";
            public const string Title = "Title";
            public const string Content = "Content";
            public const string Author = "Author";
            public const string CreateDate = "CreateDate";
            public const string ModifyDate = "ModifyDate";

            public static readonly string AllColumns = String.Join(",", Id, Title, Content, Author, CreateDate, ModifyDate);
        }

        private string connectionString = "server=localhost;user=dbadmin;database=my_blog;port=3306;password=mercury;";
        private string postTableName = "posts";

        public List<Post> GetAllPosts() {
            //string queryString = $"select {ColumnName.AllColumns} from {this.postTableName}";

            //var result = new List<Post>();
            //using (var connection = new MySqlConnection(this.connectionString)) {
            //    var command = new MySqlCommand(queryString, connection);

            //    connection.Open();
            //    var reader = command.ExecuteReader();
            //    while (reader.Read()) {
            //        result.Add(CreatePost(reader));
            //    }

            //    reader.Close();
            //}

            //return result;

            using (var dbcontext = new BlogContext()) {
                return dbcontext.Posts.ToList();
            }
        }

        public Post GetPostById(int id) {
            //string queryString = $"select {ColumnName.AllColumns} from {this.postTableName} where {ColumnName.Id}=@id";

            //var result = new Post();
            //using (var connection = new MySqlConnection(this.connectionString)) {
            //    var command = new MySqlCommand(queryString, connection);
            //    command.Parameters.AddWithValue("@id", id);

            //    connection.Open();
            //    var reader = command.ExecuteReader();
            //    while (reader.Read()) {
            //        result = CreatePost(reader);
            //    }

            //    reader.Close();
            //}

            //return result;
            using (var dbcontext = new BlogContext()) {
                return dbcontext.Posts.Find(id);
            }
        }

        public void Update(Post post) {
            using (var dbcontext = new BlogContext()) {
                dbcontext.Entry(post).State = EntityState.Modified;
                dbcontext.SaveChanges();
            }
        }

        public void Insert(Post post) {
            using (var dbcontext = new BlogContext()) {
                dbcontext.Posts.Add(post);
                dbcontext.SaveChanges();
            }
        }

        public void Delete(Post post) {
            using (var dbcontext = new BlogContext()) {
                dbcontext.Posts.Remove(post);
                dbcontext.SaveChanges();
            }
        }

        public static Post CreatePost(MySqlDataReader reader) {
            return new Post
            {
                Id = Int32.Parse(reader[ColumnName.Id].ToString()),
                Title = reader[ColumnName.Title].ToString(),
                Content = reader[ColumnName.Content].ToString(),
                Author = reader[ColumnName.Author].ToString(),
                CreateDate = DateTime.Parse(reader[ColumnName.CreateDate].ToString()),
                ModifyDate = DateTime.Parse(reader[ColumnName.ModifyDate].ToString()),
            };
        }
    }
}
