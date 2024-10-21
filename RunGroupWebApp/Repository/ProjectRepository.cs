using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Data.Enum;
using TodoApp.Interfaces;
using TodoApp.Models;
using System.Drawing;

namespace TodoApp.Repository
{
    public class ProjectRepository : IProjectRepository
    {

        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        // ************ PROJECTS ************ //
        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects
                .ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int? id)
        {
            // To send query types: _context.Projects.Include(p => p.State)... 
            return await (_context.Projects)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public int GetProjectsCount()
        {
            return _context.Projects.Count();
        }
        public bool AddProject(Project project)
        {
            // Add only generate the sql commands
            _context.Projects.Add(project);
            return Save();
        }

        public bool UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            return Save();
        }

        public bool DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
            return Save();
        }

        // ************ SUBPROJECT ************ //
        public async Task<IEnumerable<SubProject>> GetAllSubProjectAsync()
        {
            return await _context.SubProjects.ToListAsync();
        }

        public async Task<SubProject> GetSubProjectByIdAsync(int id)
        {
            return await _context.SubProjects
                .Include(p => p.Project)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool AddSubProject(SubProject subProject)
        {
            _context.SubProjects.Add(subProject);
            return Save();
        }
        public bool UpdateSubProject(SubProject subProject)
        {
            _context.SubProjects.Add(subProject);
            return Save();
        }

        public bool DeleteSubProject(SubProject subProject)
        {
            _context.SubProjects.Remove(subProject);
            return Save();
        }

        // ************ TASKS ************ //

        public async Task<IEnumerable<ToDo>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<ToDo> GetTaskById(int id)
        {
            return await _context.Tasks
                .Include(p => p.SubProject)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool AddTask(ToDo task)
        {
            _context.Tasks.Add(task);
            return Save();
        }
        public bool UpdateTask(ToDo task)
        {
            _context.Tasks.Update(task);
            return Save();
        }
        public bool DeleteTask(ToDo task)
        {
            _context.Tasks.Remove(task);
            return Save();
        }
    }
}
