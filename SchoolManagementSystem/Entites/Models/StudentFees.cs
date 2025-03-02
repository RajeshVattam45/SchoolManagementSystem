using SchoolManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Entites.Models
{
    public class StudentFees
    {
        [Key]
        public int FeeId { get; set; }

        [ForeignKey( "Student" )]
        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        [ForeignKey("Class")]
        public int? ClassId { get; set; }
        public Class? Class { get; set; }

        public string TotalPaidAmount { get; set; }

        public string LastPaymentAmount { get; set; }

        public DateOnly DueDate {  get; set; }
    }
}
