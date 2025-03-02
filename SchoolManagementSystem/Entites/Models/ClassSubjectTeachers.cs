using SchoolManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.MVC.Entities.Models
{
    public class ClassSubjectTeacher
    {
        [Key]
        public int ClassSubjectTeacherId { get; set; }

        [ForeignKey ( "Employee" )]
        public int? EmployeeID { get; set; }
        public Employee? Employee { get; set; }

        [ForeignKey ( "Subject" )]
        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }

        [ForeignKey ( "Class" )]
        public int? ClassId { get; set; }
        public Class? Class { get; set; }
    }
}
