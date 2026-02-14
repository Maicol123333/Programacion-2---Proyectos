using Microsoft.EntityFrameworkCore;

namespace TaskManagerApi
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options) { }
        
        public DbSet <TaskItem> TaskItems { get; set; }

    }
}
