using SchoolManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.MVC.Entites.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Required]
        public string ExamName { get; set; }

        public DateTime ExamDate { get; set; }

        [ForeignKey ( "ExamType" )]
        public int? ExamTypeId { get; set; }
        public ExamType? ExamType { get; set; }

        public ICollection<ExamSubject>? ExamSubjects { get; set; }
        public ICollection<ExamSchedule>? ExamSchedules { get; set; }
        public ICollection<Marks>? Marks { get; set; }
    }
}
