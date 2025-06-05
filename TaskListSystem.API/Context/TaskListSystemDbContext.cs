using Microsoft.EntityFrameworkCore;
using Task_List_System.Entities;

namespace Task_List_System.Context
{
    public class TaskListSystemDbContext : DbContext
    {
        public TaskListSystemDbContext(DbContextOptions<TaskListSystemDbContext> options) : base(options){}

        public DbSet<TaskEntity> Tasks { get; set; } = default!;
    }
}
