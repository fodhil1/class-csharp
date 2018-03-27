
using School.Models;
using System.Data.Entity;

namespace School
{
    public class SchoolContext : DbContext   // Here the SchoolContext class inherits from DbContext. 
    {
        public SchoolContext() : base("name=SchoolContext") { }

        public virtual DbSet<Student> Students { get; set; }
    }
}

