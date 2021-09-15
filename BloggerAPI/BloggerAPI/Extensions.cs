using BloggerAPI.Dtos;
using BloggerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI
{
    public static class Extensions
    {
        public static UserDto AsDto(this User user)
        {
            if (user != null)
            {
                return new UserDto(user.Id, user.Name, user.Email, user.Phone, user.Password, user.IsAdmin);
            }
            else
            {
                return null;
            }
        }

        public static BlogPostDto AsDto(this BlogPost blogPost)
        {
            if (blogPost != null)
            {
                return new BlogPostDto(blogPost.Id, blogPost.Subject, blogPost.Post, blogPost.CreatedTime, blogPost.UpdatedTime, blogPost.IsPublished, blogPost.UserId);
            }
            else
            {
                return null;
            }
        }
    }
}
