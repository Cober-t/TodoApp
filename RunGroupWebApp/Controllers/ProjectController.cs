using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Interfaces;
using TodoApp.Models;
using System.Collections;
using ToDo = TodoApp.Models.ToDo;

namespace TodoApp.Controllers
{
    public class ProjectController : Controller
    {

        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
            //SeedData.Seed(_projectRepository);
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Project> projects = await _projectRepository.GetAllProjectsAsync();
            return View(projects);
        }

        public IActionResult AddEditProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEditProject(Project project)
        {
            if (ModelState.IsValid == false)
            {
                return View(project);
            }

            if (project.Id != 0)
            {
                _projectRepository.UpdateProject(project);
            }
            else
            {
                _projectRepository.AddProject(project);
            }
            return RedirectToAction("Index");
        }
    }
}
