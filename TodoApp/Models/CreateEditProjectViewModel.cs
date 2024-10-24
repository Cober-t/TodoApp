using TodoApp.Data.Enum;

namespace TodoApp.Models
{
    public class CreateEditProjectViewModel
    {
        public int ProjectID { get; set; }
        public int SubProjectID { get; set; }
        public string Title { get; set; } = "Default Title";
        public string SubProjectTitle { get; set; } = "Default Title";
        public string TaskTitle { get; set; } = "Default Title";
        public int Value { get; set; } = 0;
        public Status State { get; set; } = Status.Pending;
        public List<SubProject> SubProjects{ get; set; } = new List<SubProject>();
        public List<ToDo> Tasks { get; set; } = new List<ToDo>();
    }
}
