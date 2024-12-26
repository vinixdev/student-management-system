using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext : DbContext
{

    public RepositoryContext(DbContextOptions options) : base(options) { }


    public DbSet<Student>? Students { set; get; }
    public DbSet<Course>? Courses { set; get; }
    public DbSet<Enrollment>? Enrollments { set; get; }


}
