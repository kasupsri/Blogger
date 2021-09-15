using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Dtos
{
    public record BlogPostDto
    {
        public BlogPostDto(int id, string subject, string post, DateTime createdTime, DateTime updatedTime, bool isPublished, int userId)
        {
            Id = id;
            Subject = subject;
            Post = post;
            CreatedTime = createdTime;
            UpdatedTime = updatedTime;
            IsPublished = isPublished;
            UserId = userId;
        }

        public int Id { get; init; }
        public string Subject { get; init; }
        public string Post { get; init; }
        public DateTime CreatedTime { get; init; }
        public DateTime UpdatedTime { get; init; }
        public bool IsPublished { get; init; }
        public int UserId { get; init; }
    }

    public record NewBlogPostDto {
        public NewBlogPostDto(int id, string subject, string post, bool isPublished, int userId)
        {
            Id = id;
            Subject = subject;
            Post = post;
            IsPublished = isPublished;
            UserId = userId;
        }

        public int Id { get; init; }

        [Required]
        public string Subject { get; init; }

        [Required]
        public string Post { get; init; }

        [Required]
        public bool IsPublished { get; init; }

        [Required]
        public int UserId { get; init; }
    }
}
