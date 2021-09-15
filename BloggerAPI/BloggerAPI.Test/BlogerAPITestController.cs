using BloggerAPI.Controllers;
using BloggerAPI.Dtos;
using BloggerAPI.Models;
using BloggerAPI.Repository.BlogPost;
using BloggerAPI.Repository.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BloggerAPI.Test
{
    public class BlogerAPITestController
    {
        private IUserRepository userService;
        private IBlogPostRepository blogPostService;
        private  BloggerDbContext context;
        public static DbContextOptions<BloggerDbContext> dbContextOptions { get; }

        public static string connectionString = "Data Source=.;Initial Catalog=BloggerDB; Integrated Security=true";

        static BlogerAPITestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<BloggerDbContext>().UseSqlServer(connectionString).Options;
        }

        public BlogerAPITestController()
        {
            context = new BloggerDbContext(dbContextOptions);
            DummyBloggerDBInitializer db = new DummyBloggerDBInitializer();
            db.Seed(context);

            userService = new UserRepository(context);
            blogPostService = new BlogPostRepository(context);
        }

        #region User Unit Test

        [Fact]
        public async void Task_GetUserById_Return_OkResult()
        {
            //controller
            var controller = new UsersController(context, userService);
            //test id
            var id = 1;
            //call method
            var data = await controller.GetUser(id);
            //Assert
           Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetUserById_Return_BadRequest()
        {
            //controller
            var controller = new UsersController(context, userService);
            //test id
            int? id = null;
            //call method
            var data = await controller.GetUser(id);
            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetUserById_Return_NotFound()
        {
            //controller
            var controller = new UsersController(context, userService);
            //test id
            int? id = 99999;
            //call method
            var data = await controller.GetUser(id);
            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        #endregion

        #region BlogPost Unit Test
        [Fact]
        public async void Task_GetBloPostById_Return_OkResult()
        {
            //controller
            var controller = new BlogPostsController(context, blogPostService);
            //test id
            var id = 1;
            //call method
            var data = await controller.GetBlogPost(id);
            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetBloPostById_Return_BadRequest()
        {
            //controller
            var controller = new BlogPostsController(context, blogPostService);
            //test id
            int? id = null;
            //call method
            var data = await controller.GetBlogPost(id);
            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetBlogPostttById_Return_NotFound()
        {
            //controller
            var controller = new BlogPostsController(context, blogPostService);
            //test id
            int? id = 99999;
            //call method
            var data = await controller.GetBlogPost(id);
            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_GetBlogPosts_Returns_OKResult() 
        {
            //controller
            var controller = new BlogPostsController(context, blogPostService);
            //call method
            var data = await controller.GetBlogPosts();
            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetBlogPostsByUserId_Returns_OKResult()
        {
            //controller
            var controller = new BlogPostsController(context, blogPostService);
            //test id
            var id = 4;
            //call method
            var data = await controller.GetBlogPosts(4);
            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        #endregion
    }
}
