using SchoolManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.MVC.Entites.Models
{
    public class ExamSubject
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key - Exam
        [Required]
        [ForeignKey ( "Exam" )]
        public int? ExamId { get; set; }

        public Exam? Exam { get; set; }

        // Foreign Key - Subject
        [Required]
        [ForeignKey ( "Subject" )]
        public int? SubjectId { get; set; }

        public Subject? Subject { get; set; }
    }
}
