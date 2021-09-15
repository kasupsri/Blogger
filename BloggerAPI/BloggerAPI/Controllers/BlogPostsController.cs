using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloggerAPI.Models;
using BloggerAPI.Dtos;
using BloggerAPI.Repository.BlogPost;

namespace BloggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly BloggerDbContext _context;
        private readonly IBlogPostRepository _blogPostService;

        public BlogPostsController(BloggerDbContext context, IBlogPostRepository service)
        {
            _context = context;
            _blogPostService = service;
        }

        // GET: api/BlogPosts
        [HttpGet]
        public async Task<IActionResult> GetBlogPosts()
        {
            try
            {
                var blogs = await _blogPostService.GetBlogPostsAsync();
                if (blogs == null)
                {
                    return NotFound();
                }
                return Ok(blogs);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/BlogPostsForUser/2
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetBlogPosts(int userId)
        {
            try
            {
                var blogs = await _blogPostService.GetBlogPostsAsync(userId);
                if (blogs == null)
                {
                    return NotFound();
                }
                return Ok(blogs);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/BlogPosts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPost(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var blog = await _blogPostService.GetBlogPostAsync(id);
                if (blog == null)
                {
                    return NotFound();
                }
                return Ok(blog);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/BlogPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPost(int? id, BlogPostDto blogPost)
        {
            try
            {
                if (id == null || id != blogPost.Id)
                {
                    return BadRequest();
                }
                await _blogPostService.UpdateBlogPostAsync(blogPost);
                return Ok();
            }
            catch (Exception)
            {
                if (!BlogPostExists(id))
                {
                    return NotFound();
                }
                return BadRequest();
            }
        }

        // POST: api/BlogPosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostBlogPost(NewBlogPostDto blogPost)
        {
            try
            {
                BlogPostDto newBlog = await _blogPostService.AddBlogPostAsync(blogPost);
                if (newBlog != null)
                {
                    return CreatedAtAction(nameof(GetBlogPost), new { id = newBlog.Id }, newBlog);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/BlogPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _blogPostService.DeleteBlogPostAsync(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private bool BlogPostExists(int? id)
        {
            if (id != null)
                return _blogPostService.BlogPostExists(id);
            else
                return false;
        }
    }
}
