using SchoolManagementSystem.Entites.Models;
using SchoolManagementSystem.MVC.Entites.Models;
using SchoolManagementSystem.MVC.Entities.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        [StringLength ( 50, ErrorMessage = "First name cannot exceed 50 characters." )]
        public string FirstName { get; set; }

        [Required]
        [StringLength ( 50, ErrorMessage = "Last name cannot exceed 50 characters." )]
        public string LastName { get; set; }

        [Required]
        [Phone ( ErrorMessage = "Invalid phone number format." )]
        public string PhoneNumber { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        [StringLength ( 100, ErrorMessage = "Permanent address cannot exceed 100 characters." )]
        public string PermanentAddress { get; set; }

        [StringLength ( 100, ErrorMessage = "Current address cannot exceed 100 characters." )]
        public string CurrentAddress { get; set; }

        [Required]
        [RegularExpression ( @"^\d{6}$", ErrorMessage = "Pincode must be a 6-digit number." )]
        public string Pincode { get; set; }

        [Required]
        [Range ( 1, 120, ErrorMessage = "Age must be between 1 and 120." )]
        public int Age { get; set; }

        [Required]
        [DataType ( DataType.Date )]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength ( 50, ErrorMessage = "Father's name cannot exceed 50 characters." )]
        public string FatherName { get; set; }

        [Phone ( ErrorMessage = "Invalid phone number format." )]
        public string FatherPhoneNumber { get; set; }

        [StringLength ( 100, ErrorMessage = "Previous school name cannot exceed 100 characters." )]
        public string PreviousSchool { get; set; }

        [Range ( 0, 100, ErrorMessage = "Percentage must be between 0 and 100." )]
        public float PreviousSchoolPercentage { get; set; }

        [EmailAddress ( ErrorMessage = "Invalid email address format." )]
        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        [ForeignKey ( "Class" )]
        public int? ClassId { get; set; }

        public Class? Class { get; set; }

        public ICollection<StudentFees>? StudentFees { get; set; }
        public ICollection<Marks>? Marks { get; set; }
        public ICollection<StudentAttendance>? StudentAttendance { get; set; }

    }
}
