using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Interfaces;
using TodoApp.Models;
using System.Collections;
using ToDo = TodoApp.Models.ToDo;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoApp.Repository;
using System.Threading.Tasks;

namespace TodoApp.Controllers
{
    public class ProjectController : Controller
    {

        private readonly IProjectRepository _projectRepository;
        private CreateEditProjectViewModel projectVM = new CreateEditProjectViewModel();

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

        public IActionResult AddProject()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditProject(int id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project == null) return View("Error");
            projectVM = new CreateEditProjectViewModel
            {
                ProjectID = id,
                Title = project.Title,
                Value = project.Value,
                State = project.State
            };

            var allProjects = await _projectRepository.GetAllProjectsAsync();
            var allSubProjects = await _projectRepository.GetAllSubProjectAsync();
            var alllTasks = await _projectRepository.GetAllTasksAsync();
            foreach (Project p in allProjects)
            {
                foreach (SubProject sP in allSubProjects)
                {
                    if (p.Id == sP.ProjectID)
                    {
                        projectVM.SubProjects.Add(sP);

                        foreach (ToDo t in alllTasks)
                        {
                            if (t.SubProjectID == sP.Id)
                                projectVM.Tasks.Add(t);
                        }
                    }
                }
            }

            //_projectRepository.UpdateProject(project);
            return View(projectVM);
        }

        [HttpPost]
        public IActionResult AddProject(Project project)
        {
            if (ModelState.IsValid == false)
            {
                return View(project);
            }

            _projectRepository.AddProject(project);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditProject(int id, CreateEditProjectViewModel projectEdited)
        {
            if (ModelState.IsValid == false)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("EditProject", projectEdited);
            }
            var project = await _projectRepository.GetProjectByIdAsyncNoTracking(id);
            if (project == null)
            {
                return View("error");
            }
            var newProject = new Project
            {
                Id = id,
                Title = projectEdited.Title,
                Value = projectEdited.Value,
                State = projectEdited.State,
            };

            _projectRepository.UpdateProject(newProject);

            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public async Task<IActionResult> AddSubProject(int id)
        //{
        //    SubProject subProject = new SubProject { ProjectID = id };
        //    return View(subProject);
        //}

        [HttpPost]
        //[Route("Project/EditProject/{Id}")]
        public async Task<IActionResult> AddSubProject(int ProjectID, string SubProjectTitle)
        {
            SubProject newSubProject = new SubProject
            {
                ProjectID = ProjectID,
                Title = SubProjectTitle,
            };
            _projectRepository.AddSubProject(newSubProject);

            return RedirectToAction("EditProject", new {id = ProjectID });
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(int SubProjectID, string TaskTitle)
        {
            ToDo task = new ToDo
            {
                Title = TaskTitle,
                SubProjectID = SubProjectID,
            };
            _projectRepository.AddTask(task);

            var subProject = await _projectRepository.GetSubProjectByIdAsync(SubProjectID);
            return RedirectToAction("EditProject", new { id = subProject.ProjectID });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProject(int ProjectID)
        {
            var project = await _projectRepository.GetProjectByIdAsync(ProjectID);
            var projectID = ProjectID;

            _projectRepository.DeleteProject(project);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteSubProject(int SubProjectID)
        {
            var subProject = await _projectRepository.GetSubProjectByIdAsync(SubProjectID);
            var projectID = subProject.ProjectID;

            _projectRepository.DeleteSubProject(subProject);

            return RedirectToAction("EditProject", new { id = projectID });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTask(int TaskID)
        {
            var task = await _projectRepository.GetTaskByIdAsync(TaskID);
            var subProject = await _projectRepository.GetSubProjectByIdAsync(task.SubProjectID);

            _projectRepository.DeleteTask(task);

            return RedirectToAction("EditProject", new { id = subProject.ProjectID });
        }
    }
}
