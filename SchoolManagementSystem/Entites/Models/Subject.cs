using SchoolManagementSystem.Entites.Models;
using SchoolManagementSystem.MVC.Entites.Models;
using SchoolManagementSystem.MVC.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated ( DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }

        public int? SubjectId { get; set; }

        [Required]
        public string SubjectName { get; set; }

        [ForeignKey ( "Employee" )]
        public int? EmployeeId { get; set; }

        public Employee? Employee { get; set; }

        public ICollection<ClassSubjectTeacher>? ClassSubjectTeachers { get; set; }
        public ICollection<ExamSchedule>? ExamSchedules { get; set; }
        public ICollection<Marks>? Marks { get; set; }
        public ICollection<Timetable>? Timetables { get; set; }

    }
}
