using SchoolManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Entites.Models
{
    public class EmployeeAttendance
    {
        [Key]
        public int AttendanceId { get; set; }

        [ForeignKey( "Employee" )]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public DateOnly Date {  get; set; }

        public string Status { get; set; }
    }
}
