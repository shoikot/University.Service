using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace University.Service.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.Attendence> Attendences { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.CourseScedule> CourseScedules { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.TimeTable> TimeTables { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.FileStorage> FileStorages { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.DepartmentCourse> DepartmentCourses { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.UserRole> UserRoles { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.Grade> Grades { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.News> News { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.Result> Results { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.StudentCourse> StudentCourses { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.StudentGrade> StudentGrades { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.Task> Tasks { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.Teacher> Teachers { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.TeacherCourse> TeacherCourses { get; set; }

        public System.Data.Entity.DbSet<University.Service.Areas.HelpPage.Models.User> Users { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            //configure primary keys first
            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Attendence>().HasKey(p=>p.AttendenceId);
            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Attendence>()
                .HasRequired(p => p.Student).WithMany(p => p.Attendences).HasForeignKey(p => p.StudentId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Attendence>()
                .HasRequired(p => p.Course).WithMany(p => p.Attendences).HasForeignKey(p=>p.CourseId);


            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Attendence>()
                .HasRequired(p => p.TimeTable).WithMany().HasForeignKey(p=>p.TimeTableId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Course>().HasKey(p=>p.CourseId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.CourseScedule>().HasKey(p=>p.CourseSceduleId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.CourseScedule>().HasRequired(p => p.TimeTable).WithMany().HasForeignKey(p=>p.TimeTableId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Department>().HasKey(p => p.DepartmentId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Department>().HasRequired(p => p.FileStorage).WithMany().HasForeignKey(p=>p.FileStorageId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.DepartmentCourse>().HasKey(p=>p.DepartmentCourseId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.DepartmentCourse>().HasRequired(p => p.Department).WithMany().HasForeignKey(p=>p.DepartmentId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.DepartmentCourse>().HasRequired(p => p.Course).WithMany().HasForeignKey(p=>p.CourseId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Employee>().HasKey(p=>p.EmployeeId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Employee>().HasRequired(p => p.UserRole).WithMany(p => p.Employees).HasForeignKey(p=>p.UserRoleId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Event>().HasKey(p=>p.EventId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Event>().HasRequired(p => p.EventTime).WithMany().HasForeignKey(p=>p.EventTimeTableId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.FileStorage>().HasKey(p=>p.FileStorageId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Grade>().HasKey(p=>p.GradeId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.News>().HasKey(p=>p.NewsId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Result>().HasKey(p=>p.ResultId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Result>().HasRequired(p => p.Student).WithMany().HasForeignKey(p=>p.StudentId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Result>().HasRequired(p => p.Course).WithMany().HasForeignKey(p=>p.CourseId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Result>().HasRequired(p => p.TimeTable).WithMany().HasForeignKey(p=>p.TimeTableId);

            modelBuilder.Entity<University.Service.Areas.HelpPage.Models.Student>().HasKey(p => p.StudentId);
        }
    }
}