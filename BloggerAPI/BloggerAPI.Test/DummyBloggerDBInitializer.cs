using BloggerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggerAPI.Test
{
    class DummyBloggerDBInitializer
    {
        public DummyBloggerDBInitializer()
        {

        }

        public void Seed(BloggerDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Users.AddRange(
                new User() { Name = "Super Man", Email = "super@super.com", Phone = "1122334455", Password = "1234", IsAdmin = false },
                new User() { Name = "Bat Man", Email = "bat@bat.com", Phone = "5544332211", Password = "1111", IsAdmin = false },
                new User() { Name = "Spider Man", Email = "spider@spider.com", Phone = "666778899", Password = "2222", IsAdmin = false }
                );

            context.BlogPosts.AddRange(
                new BlogPost() { Subject = "Orange", Post = "Orange is good", IsPublished = true, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now, UserId = 4 },
                new BlogPost() { Subject = "Mango", Post = "Mango is good", IsPublished = true, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now, UserId = 4 },
                new BlogPost() { Subject = "Apple", Post = "Apple is good", IsPublished = true, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now, UserId = 4 }
                );

            context.SaveChanges();
        }
    }
}
