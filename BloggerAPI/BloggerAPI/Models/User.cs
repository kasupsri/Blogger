using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string Name { get; set; }
        
        [Column(TypeName="nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        [Column(TypeName = "bit")]
        public bool IsAdmin { get; set; }

    }
}
