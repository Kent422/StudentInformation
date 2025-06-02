using Microsoft.EntityFrameworkCore;

namespace StudentInformation.Models
{
    public class StudentDB :DbContext
    {
        public StudentDB(DbContextOptions<StudentDB> options) : base(options) { }

        public DbSet<Student> Student { get; set; }
    }
}
