
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace School.Models
{
    public class StudentViewModel
    {
        public int? StudentId { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Name")]
        public string FullName => FirstName + " " + LastName;
    }
}
