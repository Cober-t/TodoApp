using Microsoft.EntityFrameworkCore;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class SeedData
    {

        public static void Seed(IProjectRepository context)
        {
            //foreach (Project project in context.Projects.ToList())
            //{
            //    foreach (SubProject subProject in context.SubProjects.ToList())
            //    {
            //        if (project.Id == subProject.ProjectID)
            //        {
            //            project.AddSubProject(subProject);

            //            foreach (ToDo task in context.Tasks.ToList())
            //            {
            //                if (subProject.Id == task.SubProjectID)
            //                {
            //                    project.AddTask(task);
            //                }
            //            }
            //        }
            //    }
            //}
        }
    }
}
