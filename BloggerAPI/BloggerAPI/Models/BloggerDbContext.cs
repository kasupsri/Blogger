using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BloggerAPI.Models
{
    public class BloggerDbContext:IdentityDbContext
    {
        public BloggerDbContext(DbContextOptions<BloggerDbContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

    }
}
