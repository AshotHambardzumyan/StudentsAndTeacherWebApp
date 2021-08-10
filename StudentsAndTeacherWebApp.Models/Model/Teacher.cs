using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentsAndTeacherWebApp.Models.Model
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public List<Student> Students { get; set; }
    }
}