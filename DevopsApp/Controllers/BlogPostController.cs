using DevopsApp.Data;
using DevopsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevopsApp.Controllers
{
    public class BlogPostController : Controller
    {
        //made changes  ........................

        private readonly BlogDbContext _dbContext;
        public BlogPostController(BlogDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet]
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
