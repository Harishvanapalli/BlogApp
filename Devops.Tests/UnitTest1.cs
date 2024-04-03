using Devops.App.Controllers;
using Devops.App.Data;
using Devops.App.Models.BlogModels;
using Microsoft.AspNetCore.Mvc;

namespace Devops.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private BlogDbContext _dbContext;

        [TestInitialize]
        public void Setup()
        {
            _dbContext = new BlogDbContext();

            _dbContext.Blogs.AddRange(new[]
            {
                new BlogModel
                {
                    Title = "Wow Car",
                    Category = "Vehicles",
                    Content = "Lamborghini Launched it's new car",
                    Description = "Lamborghini launched another stylish car named 'Lamborghini Urus' this day, the car comes with many features and company claims it is the best car in SUV segment",
                    Author = "Harish",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7TBTTzWM5ndcMhEDRDCo1LCToGrGOzfmPhUz2jmWHoA&s"
                },
                new BlogModel
                {
                    Title = "Ferrari",
                    Category = "Vehicles",
                    Content = "Ferrari Launched it's new car named 'Ferrari Purosangue'",
                    Description = "Ferrari launched an SUV named 'Purosangue' and it costs around 8.00 crore in India, this car can be the best competitor of Lamborghini Urus",
                    Author = "Ramesh",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQkMna14MswKF6wNIxAq5mbp2qUlf-Yk1ZL7A&s"
                }
            });
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
            var initialCount = _dbContext.GetBlogs().Count();
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
            var finalCount = _dbContext.GetBlogs().Count();

            // Assert
            Assert.AreEqual(initialCount + 1, finalCount);
        }
    }
}