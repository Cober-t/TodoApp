using TodoApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        //[ForeignKey("Project Owner")]
        //public int ProjectID { get; set; }
        //public Project? Project { get; set; }

        [ForeignKey("SubProject Owner")]
        public int SubProjectID { get; set; }
        public SubProject? SubProject { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.Pending;

        public void CompleteTask()
        {
            Status = Status.Complete;
        }
    }
}
