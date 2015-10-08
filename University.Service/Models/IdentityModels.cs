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
    }
}