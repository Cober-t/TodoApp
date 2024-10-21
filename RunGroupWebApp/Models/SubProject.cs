using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Models
{
    public class SubProject
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Project Owner")]
        public int ProjectID { get; set; }
        public Project Project { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
