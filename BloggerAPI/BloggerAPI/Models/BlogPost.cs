using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Subject { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Post { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdatedTime { get; set; }

        [Column(TypeName = "bit")]
        public bool IsPublished { get; set; }

        [ForeignKey("userId")]
        public int UserId { get; set; }
    }
}
