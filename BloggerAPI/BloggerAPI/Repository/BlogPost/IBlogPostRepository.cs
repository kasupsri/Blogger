using BloggerAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Repository.BlogPost
{
    public interface IBlogPostRepository
    {
        public Task<List<BlogPostDto>> GetBlogPostsAsync();

        public Task<List<BlogPostDto>> GetBlogPostsAsync(int? userId);

        public Task<BlogPostDto> GetBlogPostAsync(int? id);

        public Task<BlogPostDto> AddBlogPostAsync(NewBlogPostDto blogPostDto);

        public Task<int> DeleteBlogPostAsync(int? id);

        public Task UpdateBlogPostAsync(BlogPostDto blogPostDto);

        public bool BlogPostExists(int? id);
    }
}
