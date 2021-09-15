using BloggerAPI.Dtos;
using BloggerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Repository.User
{
    public interface IUserRepository
    {

        public Task<List<UserDto>> GetUsersAsync();

        public Task<UserDto> GetUserAsync(int? id);

        public Task<List<UserDto>> GetLoginUsersAsync(UserLoginDto userLogin);

        public Task<UserDto> AddUserAsync(UserRegisterDto user);

        public Task<int> DeleteUserAsync(int? id);

        public Task UpdateUserAsync(UserRegisterDto user);

        public bool UserExists(int? id);

    }
}
