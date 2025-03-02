using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.MVC.Repository.Implementation;
using SchoolManagementSystem.MVC.Repository.Repositories;
using SchoolManagementSystem.MVC.Service.Implementation;
using SchoolManagementSystem.MVC.Service.ServiceInterface;
using SchoolManagementSystem.Repository.Implementation;
using SchoolManagementSystem.Repository.Repositories;
using SchoolManagementSystem.Service.Implementation;
using SchoolManagementSystem.Service.ServiceInterface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString ( "DefaultConnection" );

builder.Services.AddDbContext<SchoolDbContext> ( options => options.UseSqlServer ( connectionString ) );

//builder.Services.AddScoped<IStudentRepository, StudentRepository> ();
//builder.Services.AddScoped<IStudentService, StudentService> ();

builder.Services.AddScoped<IStudentRepository, StudentRepository> ();
builder.Services.AddScoped<IStudentService, StudentService> ();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository> ();
builder.Services.AddScoped<IEmployeeService, EmployeeService> ();

builder.Services.AddScoped<IClassRepository, ClassRepository> ();
builder.Services.AddScoped<IClassService, ClassService> ();

builder.Services.AddScoped<ISubjectRepository, SubjectRepository> ();
builder.Services.AddScoped<ISubjectService, SubjectService> ();

builder.Services.AddScoped<IExamRepository, ExamRepository> ();
builder.Services.AddScoped<IExamService, ExamService> ();

builder.Services.AddScoped<IExamTypeRepository, ExamTypeRepository> ();
builder.Services.AddScoped<IExamTypeService, ExamTypeService> ();

builder.Services.AddScoped<IExamSubjectRepository, ExamSubjectRepository> ();
builder.Services.AddScoped<IExamSubjectService, ExamSubjectService> ();
// Register repository and service
builder.Services.AddScoped<IExamScheduleRepository, ExamScheduleRepository> ();
builder.Services.AddScoped<IExamScheduleService, ExamScheduleService> ();

builder.Services.AddScoped<IClassSubjectTeacherRepository, ClassSubjectTeacherRepository> ();
builder.Services.AddScoped<IClassSubjectTeachersService, ClassSubjectTeachersService> ();


builder.Services.AddSession ();
builder.Services.AddHttpContextAccessor ();


// Add session support
builder.Services.AddSession ( options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes ( 30 );
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
} );

// Configure authentication using cookies
builder.Services.AddAuthentication ( CookieAuthenticationDefaults.AuthenticationScheme )
    .AddCookie ( options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
    } );

builder.Services.AddAuthorization ();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession ();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
