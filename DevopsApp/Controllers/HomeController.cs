using DevopsApp.Data;
using DevopsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DevopsApp.Controllers
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
            var posts = _dbContext.BlogTable.ToList();
            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
