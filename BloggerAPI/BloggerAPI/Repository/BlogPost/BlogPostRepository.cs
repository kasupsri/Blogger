using BloggerAPI.Dtos;
using BloggerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Repository.BlogPost
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BloggerDbContext dbContext;

        public BlogPostRepository(BloggerDbContext context)
        {
            this.dbContext = context;
        }

        public async Task<List<BlogPostDto>> GetBlogPostsAsync()
        {
            if (dbContext != null)
            {
                var blogs = await dbContext.BlogPosts.Where(post=>post.IsPublished).ToListAsync();
                return blogs.Select(x => x.AsDto()).ToList();
            }
            return null;
        }

        public async Task<List<BlogPostDto>> GetBlogPostsAsync(int? userId)
        {
            if (dbContext != null)
            {
                var blogs = await dbContext.BlogPosts.Where(x => x.UserId == userId).ToListAsync();
                return blogs.Select(x => x.AsDto()).ToList();
            }
            return null;
        }

        public async Task<BlogPostDto> GetBlogPostAsync(int? id)
        {
            if (dbContext != null)
            {
                var blog = await dbContext.BlogPosts.FindAsync(id);
                return blog.AsDto();
            }
            return null;
        }

        public async Task<BlogPostDto> AddBlogPostAsync(NewBlogPostDto blogPost)
        {
            if (dbContext != null)
            {
                BloggerAPI.Models.BlogPost newBlogPost = new()
                {
                    Id = blogPost.Id,
                    Subject = blogPost.Subject,
                    Post = blogPost.Post,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    IsPublished = blogPost.IsPublished,
                    UserId = blogPost.UserId
                };

                await dbContext.BlogPosts.AddAsync(newBlogPost);
                await dbContext.SaveChangesAsync();

                return newBlogPost.AsDto();
            }
            return null;
        }

        public async Task<int> DeleteBlogPostAsync(int? id)
        {
            int result = 0;
            if (dbContext != null)
            {
                var blog = await dbContext.BlogPosts.FindAsync(id);
                if (blog != null)
                {
                    dbContext.BlogPosts.Remove(blog);

                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }

        public async Task UpdateBlogPostAsync(BlogPostDto blogPost)
        {
            BloggerAPI.Models.BlogPost newBlogPost = new()
            {
                Id = blogPost.Id,
                Subject = blogPost.Subject,
                Post = blogPost.Post,
                CreatedTime = blogPost.CreatedTime,
                UpdatedTime = blogPost.UpdatedTime,
                IsPublished = blogPost.IsPublished,
                UserId = blogPost.UserId
            };
            dbContext.BlogPosts.Update(newBlogPost);
            await dbContext.SaveChangesAsync();
        }

        public bool BlogPostExists(int? id)
        {
            bool result = false;
            if (dbContext != null)
            {
                result = dbContext.BlogPosts.Any(e => e.Id == id);
            }
            return result;
        }
    }
}
