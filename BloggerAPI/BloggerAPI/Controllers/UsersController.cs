using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloggerAPI.Models;
using BloggerAPI.Dtos;
using BloggerAPI.Repository.User;

namespace BloggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BloggerDbContext _context;
        private readonly IUserRepository _userService;

        public UsersController(BloggerDbContext context, IUserRepository userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var user = await _userService.GetUserAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int? id, UserRegisterDto user)
        {
            try
            {
                if (id == null || id != user.Id)
                {
                    return BadRequest();
                }

                await _userService.UpdateUserAsync(user);

                return Ok();

            }
            catch (Exception)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }

                return BadRequest();
            }        
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostUser(UserRegisterDto user)
        {
            try
            {
                UserDto newUser = await _userService.AddUserAsync(user);
                if (newUser != null)
                {
                    return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
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


        // POST: api/Users/login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("login")]
        public async Task<IActionResult> PostUser(UserLoginDto userLogin)
        {

            var users = await _userService.GetLoginUsersAsync(userLogin);
            if (users == null || users.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(users[0]);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _userService.DeleteUserAsync(id);
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

        private bool UserExists(int? id)
        {
            if (id != null)
                return _userService.UserExists(id);
            else
                return false;
        }
    }
}
