using Devops.App.Data;
using Devops.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Devops.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, BlogDbContext _dbContext)
        {
            _logger = logger;
            this._dbContext = _dbContext;
        }

        public IActionResult Index()
        {
            var posts = _dbContext.GetBlogs();
            return View(posts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
