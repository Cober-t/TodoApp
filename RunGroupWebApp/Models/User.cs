using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int ProjectsComplete { get; set; } = 0;
        public int Money { get; set; } = 0;

        public ICollection<Project>? Projects { get; set; }
    }
}
