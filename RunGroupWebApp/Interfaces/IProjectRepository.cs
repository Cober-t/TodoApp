using TodoApp.Models;
using System.Threading.Tasks;

namespace TodoApp.Interfaces
{
    public interface IProjectRepository
    {
        bool Save();

        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int? id);
        int GetProjectsCount();
        bool AddProject(Project project);
        bool UpdateProject(Project project);
        bool DeleteProject(Project project);

        Task<IEnumerable<SubProject>> GetAllSubProjectAsync();
        Task<SubProject> GetSubProjectByIdAsync(int id);
        bool AddSubProject(SubProject subProject);
        bool UpdateSubProject(SubProject subProject);
        bool DeleteSubProject(SubProject subProject);

        Task<IEnumerable<ToDo>> GetAllTasksAsync();
        Task<ToDo> GetTaskById(int id);
        bool AddTask(ToDo task);
        bool UpdateTask(ToDo task);
        bool DeleteTask(ToDo task);
    }
}
