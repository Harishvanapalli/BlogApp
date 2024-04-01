using DevopsApp.Controllers;
using DevopsApp.Data;
using DevopsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Devops.Tests
{
    [TestClass]
    public class BlogPostControllerTests
    {
        private BlogDbContext _dbContext;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _dbContext = new BlogDbContext(options);
        }

        [TestMethod]
        public void AddPost_Get_ReturnsViewResult()
        {
            // Arrange
            var controller = new BlogPostController(_dbContext);

            // Act
            var result = controller.AddPost() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreatePost_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var controller = new BlogPostController(_dbContext);
            var blogModel = new ReferenceModel
            {
                Title = "Test Title",
                Category = "Test Category",
                Content = "Test Content",
                Description = "Test Description",
                Author = "Test Author",
                ImageUrl = "Test ImageUrl"
            };

            // Act
            var result = controller.CreatePost(blogModel) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);
        }

        [TestMethod]
        public void CreatePost_ValidModel_SavesToDatabase()
        {
            // Arrange
            var controller = new BlogPostController(_dbContext);
            var initialCount = _dbContext.BlogTable.Count();
            var blogModel = new ReferenceModel
            {
                Title = "Test Title",
                Category = "Test Category",
                Content = "Test Content",
                Description = "Test Description",
                Author = "Test Author",
                ImageUrl = "Test ImageUrl"
            };

            // Act
            controller.CreatePost(blogModel);
            var finalCount = _dbContext.BlogTable.Count();

            // Assert
            Assert.AreEqual(initialCount + 1, finalCount);
        }
    }
}
