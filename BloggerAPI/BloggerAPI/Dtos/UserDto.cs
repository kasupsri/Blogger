using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Dtos
{
    public record UserDto
    {
        public UserDto(int id, string name, string email, string phone, string password, bool isAdmin)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;
            IsAdmin = isAdmin;
        }

        public int Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
        public string Password { get; init; }
        public bool IsAdmin { get; init; }
    }

    public record UserRegisterDto
    {
        public UserRegisterDto(int id, string name, string email, string phone, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;
        }

        public int Id { get; init; }

        [Required]
        public string Name { get; init; }
        [Required]
        public string Email { get; init; }
        [Required]
        public string Phone { get; init; }
        [Required]
        public string Password { get; init; }
    }

    public record UserLoginDto
    {
        public UserLoginDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
        [Required]
        public string Email { get; init; }
        [Required]
        public string Password { get; init; }
    }

}
