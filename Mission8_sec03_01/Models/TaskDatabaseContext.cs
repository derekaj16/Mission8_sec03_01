using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission8_sec03_01.Models
{
    public class TaskDatabaseContext : DbContext
    {
        public TaskDatabaseContext (DbContextOptions<TaskDatabaseContext> options):base(options)
        {

        }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Home"},
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }
                );
            mb.Entity<TaskModel>().HasData(
                new TaskModel
                {
                    TaskID = 1,
                    Task = "Do Laundry",
                    DueDate = null,
                    Quadrant = 2,
                    CategoryID = 1,
                    Completed = false
                },
                new TaskModel
                {
                    TaskID = 2,
                    Task = "Mission 8",
                    DueDate = DateTime.ParseExact("02/24/2023", "MM/dd/yyyy", null),
                    Quadrant = 1,
                    CategoryID = 2,
                    Completed = false
                },
                new TaskModel
                {
                    TaskID = 3,
                    Task = "Ministering",
                    DueDate = DateTime.ParseExact("02/21/2023", "MM/dd/yyyy", null),
                    Quadrant = 3,
                    CategoryID = 4,
                    Completed = false
                },
                new TaskModel
                {
                    TaskID = 4,
                    Task = "Find Intership",
                    DueDate = null,
                    Quadrant = 4,
                    CategoryID = 3,
                    Completed = false
                });
        }
    }
}
