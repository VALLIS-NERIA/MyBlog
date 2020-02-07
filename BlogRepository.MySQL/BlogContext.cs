using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogModel;
using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;

namespace BlogRepository.MySQL {
    [DbConfigurationType(typeof(BlogEFMySQLConfiguration))]
    public class BlogContext : DbContext {
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Migrations.Configuration>());
        }
    }

    public class BlogEFMySQLConfiguration : DbConfiguration {
        //static BlogEFMySQLConfiguration() {
        //    DbConfiguration.SetConfiguration(new BlogEFMySQLConfiguration());
        //}
        public BlogEFMySQLConfiguration() {
            SetProviderServices("MySql.Data.MySqlClient", new MySqlProviderServices());
            SetMigrationSqlGenerator("MySql.Data.MySqlClient", () => new MySqlMigrationSqlGenerator());
        }
    }
}