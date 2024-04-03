using Devops.App.Data;
using Devops.App.Models.BlogModels;
using Microsoft.AspNetCore.Mvc;

namespace Devops.App.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly BlogDbContext _dbContext;
        public BlogPostController(BlogDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        [ActionName("AddPost")]

        public IActionResult CreatePost(ReferenceModel blogModel)
        {
            var post = new BlogModel
            {
                Title = blogModel.Title,
                Category = blogModel.Category,
                Content = blogModel.Content,
                Description = blogModel.Description,
                Author = blogModel.Author,
                ImageUrl = blogModel.ImageUrl
            };

            _dbContext.AddBlog(post);

            return RedirectToAction("Index", "Home");
        }
    }
}
