using TodoApp.Models;
using System.Threading.Tasks;
using TodoApp.Data;

namespace TodoApp.Interfaces
{
    public interface IProjectRepository
    {
        ApplicationDbContext Context { get; }
        bool Save();

        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int? id);
        Task<Project> GetProjectByIdAsyncNoTracking(int? id);
        int GetProjectsCount();
        bool AddProject(Project project);
        bool UpdateProject(Project project);
        bool DeleteProject(Project project);

        Task<IEnumerable<SubProject>> GetAllSubProjectAsync();
        Task<SubProject> GetSubProjectByIdAsync(int id);
        Task<SubProject> GetSubProjectByIdAsyncNoTracking(int id);
        bool AddSubProject(SubProject subProject);
        bool UpdateSubProject(SubProject subProject);
        bool DeleteSubProject(SubProject subProject);

        Task<IEnumerable<ToDo>> GetAllTasksAsync();
        Task<ToDo> GetTaskByIdAsync(int id);
        Task<ToDo> GetTaskByIdAsyncNoTracking(int id);
        bool AddTask(ToDo task);
        bool UpdateTask(ToDo task);
        bool DeleteTask(ToDo task);
    }
}
