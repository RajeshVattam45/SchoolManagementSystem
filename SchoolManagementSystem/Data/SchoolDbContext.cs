using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Entites.Models;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.MVC.Entites.Models;
using SchoolManagementSystem.MVC.Entities.Models;

namespace SchoolManagementSystem.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext ( DbContextOptions<SchoolDbContext> options ) : base ( options )
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamSchedule> ExamSchedules { get; set; }
        public DbSet<ExamSubject> ExamSubjects { get; set; }
        public DbSet<StudentFees> StudentFees { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }
        public DbSet<FeePayment> FeePayments { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<Holidays> Holidays { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<LibraryBooks> LibraryBooks { get; set; }
        public DbSet<LibraryTransactions> LibraryTransactions { get; set; }

        protected override void OnModelCreating ( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Class> ()
              .Property ( c => c.TotalFee )
              .HasPrecision ( 18, 2 );

            modelBuilder.Entity<Employee> ()
                .Property ( e => e.EmployeeSalary )
                .HasPrecision ( 18, 2 );
            base.OnModelCreating ( modelBuilder );
        }
    }
}
