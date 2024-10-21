using Microsoft.AspNetCore.Mvc;
using TodoApp.Data;

namespace TodoApp.Controllers
{
    public class StoreController : Controller
    {

        private readonly ApplicationDbContext _context;

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var projects = _context.Projects.ToList();
            return View(projects);
        }
    }
}
