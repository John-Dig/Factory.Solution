using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
  public class ToDoListContext : DbContext
  {
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<MachineTag> MachineTags { get; set; }

    public ToDoListContext(DbContextOptions options) : base(options) { }
  }
}