using SchoolManagementSystem.Entites.Models;
using SchoolManagementSystem.MVC.Entites.Models;
using SchoolManagementSystem.MVC.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public decimal TotalFee { get; set; }

        // Relationship: One Class -> Many Students
        public ICollection<Student>? Students { get; set; }
        public ICollection<ClassSubjectTeacher>? ClassSubjectTeachers { get; set; }
        public ICollection<ExamSchedule>? ExamSchedules { get; set; }
        public ICollection<StudentFees>? StudentFees { get; set; }
        public ICollection<Marks>? Marks { get; set; }
        public ICollection<StudentAttendance>? StudentAttendances { get; set; }
        public ICollection<FeePayment>? FeePayments { get; set; }
        public ICollection<Timetable>? Timetables { get; set; }
    }
}
