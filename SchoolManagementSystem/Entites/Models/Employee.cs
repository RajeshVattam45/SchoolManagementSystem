using SchoolManagementSystem.Entites.Models;
using SchoolManagementSystem.MVC.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Column ( "EmployeeID" )]
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Role { get; set; }
        public string PermanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string? Pincode { get; set; }
        public string? EmployeeType { get; set; }
        public decimal EmployeeSalary { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }

        // Relationship: One Employee -> Many Subjects
        public ICollection<Subject>? Subjects { get; set; }
        public ICollection<ClassSubjectTeacher>? ClassSubjectTeachers { get; set; }
        public ICollection<EmployeeAttendance>? employeeAttendances { get; set; }
        public ICollection<Timetable>? Timetables { get; set; }
    }
}
