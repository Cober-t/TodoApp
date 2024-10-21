using Microsoft.AspNetCore.Mvc;
using TodoApp.Data;
using TodoApp.Interfaces;
using TodoApp.Models;
using System.Diagnostics;
using ToDo = TodoApp.Models.ToDo;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public HomeController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
            //SeedData.Seed(_context);
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Project> projects = await _projectRepository.GetAllProjectsAsync();
            return View(projects);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
