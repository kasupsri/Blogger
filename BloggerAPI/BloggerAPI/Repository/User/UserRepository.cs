using BloggerAPI.Dtos;
using BloggerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly BloggerDbContext dbContext;
        public UserRepository(BloggerDbContext context)
        {
            dbContext = context;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            if (dbContext != null)
            {
                var users = await dbContext.Users.ToListAsync();
                return users.Select(x => x.AsDto()).ToList();
            }
            return null;
        }

        public async Task<UserDto> GetUserAsync(int? id)
        {
            if (dbContext != null)
            {
                var user = await dbContext.Users.FindAsync(id);
                return user.AsDto();
            }
            return null;
        }

        public async Task<List<UserDto>> GetLoginUsersAsync(UserLoginDto userLogin)
        {
            if (dbContext != null)
            {
                var users = await (from u in dbContext.Users
                                   where u.Email == userLogin.Email && u.Password == userLogin.Password
                                   select u).ToListAsync();
                return users.Select(x => x.AsDto()).ToList();
            }
            return null;
        }

        public async Task<UserDto> AddUserAsync(UserRegisterDto user)
        {
            if (dbContext != null)
            {
                BloggerAPI.Models.User newUser = new()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,
                    Password = user.Password,
                    IsAdmin = false,
                };
                await dbContext.Users.AddAsync(newUser);
                await dbContext.SaveChangesAsync();

                return newUser.AsDto();
            }
            return null;
        }

        public async Task<int> DeleteUserAsync(int? id)
        {
            int result = 0;
            if (dbContext != null)
            {
                var user = await dbContext.Users.FindAsync(id);
                if (user != null)
                {
                    dbContext.Users.Remove(user);

                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }

        public async Task UpdateUserAsync(UserRegisterDto user)
        {
            if (dbContext != null)
            {
                BloggerAPI.Models.User newUser = new()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,
                    Password = user.Password,
                    IsAdmin = false,
                };

                dbContext.Users.Update(newUser);
                await dbContext.SaveChangesAsync();
            }
        }

        public bool UserExists(int? id)
        {
            bool result = false;
            if (dbContext != null)
            {
                result =  dbContext.Users.Any(e => e.Id == id);
            }
            return result;
        }
    }
}
