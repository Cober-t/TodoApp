using Microsoft.EntityFrameworkCore;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class SeedData
    {
        public static void Seed(IProjectRepository context)
        {
            //foreach (Project project in context.GetAllProjectsAsync())
            //{
            //    foreach (SubProject subProject in context.GetSubProjectByIdAsync())
            //    {
            //        if (project.Id == subProject.ProjectID)
            //        {
            //            context.AddSubProject(subProject);

            //            foreach (ToDo task in context.GetAllTasksAsync())
            //            {
            //                if (subProject.Id == task.SubProjectID)
            //                {
            //                    context.AddTask(task);
            //                }
            //            }
            //        }
            //    }
            //}
        }
    }
}
