using Microsoft.EntityFrameworkCore;
using TodoApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace TodoApp.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public int Value { get; set; } = 0;

        //public Color Color { get; set; }
        [NotMapped]
        public bool IsActive{ get; set; } = false;
        public Status State { get; set; } = Status.Pending;
        //public ICollection<SubProject>? SubProjects { get; set; } = null!;
        //public ICollection<ToDo>? Tasks { get; set; } = null!;

        //public ICollection<SubProject>? GetSubProjects()
        //{
        //    return SubProjects != null ? SubProjects.ToList() : null;
        //}

        //public void AddSubProject(SubProject subProject)
        //{
        //    if  (SubProjects == null)
        //    {
        //        SubProjects = new List<SubProject>();
        //    }
        //    SubProjects.Add(subProject);
        //}

        //public ICollection<ToDo>? GetTasks()
        //{
        //    return Tasks != null ? Tasks.ToList() : null;
        //}

        //public void AddTask(ToDo newTask)
        //{
        //    if (Tasks == null)
        //    {
        //        Tasks = new List<ToDo>();
        //    }
        //    Tasks.Add(newTask);
        //}

        public void ChangeTitle(string newTitle)
        {
            Title = newTitle; 
        }

        public void ChangeColor(Color newColor)
        {
            //Color = newColor;
        }

        public void RedeemProject()
        {
            IsActive = true;
        }

        public void CompleteProject()
        {
            //State = Status.Complete;
        }
    }
}
