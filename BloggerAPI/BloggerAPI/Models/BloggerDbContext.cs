using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Models
{
    public class BloggerDbContext:DbContext
    {
        public BloggerDbContext(DbContextOptions<BloggerDbContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

    }
}
