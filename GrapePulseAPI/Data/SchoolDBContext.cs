
using GrapePulseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GrapePulseAPI.Data
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
    
}
