using SchoolManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Entites.Models
{
    public class StudentAttendance
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        public DateOnly Date {  get; set; }

        public string Status { get; set; }

        [ForeignKey("Class")]
        public int? ClassId { get; set; }
        public Class? Class { get; set; }
    }
}
