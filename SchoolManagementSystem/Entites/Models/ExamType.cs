using SchoolManagementSystem.MVC.Entites.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class ExamType
    {
        [Key]
        public int Id { get; set; }
        public int? ExamTypeId { get; set; }
        public string ExamTypeName { get; set; }
        public int MaxMarks { get; set; }
        public ICollection<Exam>? Exams { get; set; }
    }
}
