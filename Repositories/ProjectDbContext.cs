using Microsoft.EntityFrameworkCore;
public class ProjectDbContext: DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options): base(options) {}

    public DbSet<Character> Characters { get; set; }
    public DbSet<Item> Items { get; set; }
}