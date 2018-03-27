using School.Models;
using System.Data.Entity.Migrations;

namespace School.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolContext context)
        {
            context.Students.AddOrUpdate(
                p => p.StudentId,
                new Student { StudentId = 1, LastName = "Halpert", FirstName = "Jim" },
                new Student { StudentId = 2, LastName = "Beesly", FirstName = "Pam" },
                new Student { StudentId = 3, LastName = "Scott", FirstName = "Michael" },
                new Student { StudentId = 4, LastName = "Schrute", FirstName = "Dwight" },
                new Student { StudentId = 5, LastName = "Martin", FirstName = "Angela" },
                new Student { StudentId = 6, LastName = "Bernard", FirstName = "Andy" },
                new Student { StudentId = 7, LastName = "Malone", FirstName = "Kevin" },
                new Student { StudentId = 8, LastName = "Kapoor", FirstName = "Kelly" },
                new Student { StudentId = 9, LastName = "Palmer", FirstName = "Meredith" },
                new Student { StudentId = 10, LastName = "Flenderson", FirstName = "Toby" },
                new Student { StudentId = 11, LastName = "Hudson", FirstName = "Stanley" },
                new Student { StudentId = 12, LastName = "Bratton", FirstName = "Creed" },
                new Student { StudentId = 13, LastName = "Vance", FirstName = "Phyllis" },
                new Student { StudentId = 14, LastName = "Howard", FirstName = "Ryan" },
                new Student { StudentId = 15, LastName = "Philbin", FirstName = "Darryl" }
            );
        }
    }
}
