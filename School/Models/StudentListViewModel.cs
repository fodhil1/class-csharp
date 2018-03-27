using System.Collections.Generic;

namespace School.Models
{
    public class StudentListViewModel
    {
        public List<StudentViewModel> Students { get; set; }
        public int TotalStudents { get; set; }
    }
}
