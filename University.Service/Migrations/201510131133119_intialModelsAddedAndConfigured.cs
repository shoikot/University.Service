namespace University.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialModelsAddedAndConfigured : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        AttendenceId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        TimeTableId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttendenceId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.TimeTables", t => t.TimeTableId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.TimeTableId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CourseCode = c.String(),
                        CourseType = c.Int(nullable: false),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CurrentAddress = c.String(),
                        ParmanentAddress = c.String(),
                        NickName = c.String(),
                        UserGender = c.Int(nullable: false),
                        StudentId = c.Int(),
                        RollNo = c.Int(),
                        DepartmentId = c.Int(),
                        EmployeeId = c.Int(),
                        UserRoleId = c.Int(),
                        TeacherId = c.Int(),
                        YearOfExperience = c.Int(),
                        DepartmentId1 = c.Int(),
                        UserRoleId1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Department_DepartmentId = c.Int(),
                        Course_CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId1, cascadeDelete: true)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleId1, cascadeDelete: true)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId)
                .Index(t => t.DepartmentId)
                .Index(t => t.UserRoleId)
                .Index(t => t.DepartmentId1)
                .Index(t => t.UserRoleId1)
                .Index(t => t.Department_DepartmentId)
                .Index(t => t.Course_CourseId);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        StudentCourseId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Student_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentCourseId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Student_UserId)
                .Index(t => t.CourseId)
                .Index(t => t.Student_UserId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FileStorageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.FileStorages", t => t.FileStorageId, cascadeDelete: true)
                .Index(t => t.FileStorageId);
            
            CreateTable(
                "dbo.CourseScedules",
                c => new
                    {
                        CourseSceduleId = c.Int(nullable: false, identity: true),
                        TimeTableId = c.Int(nullable: false),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseSceduleId)
                .ForeignKey("dbo.TimeTables", t => t.TimeTableId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.TimeTableId)
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        TimeTableId = c.Int(nullable: false, identity: true),
                        AssigningDate = c.DateTime(nullable: false),
                        SubmissionDate = c.DateTime(nullable: false),
                        Duration = c.DateTime(nullable: false),
                        Year = c.DateTime(nullable: false),
                        Date = c.DateTime(nullable: false),
                        DayOfWeek = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TimeTableId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        EventLocation = c.String(),
                        EventDetail = c.String(),
                        EventTimeTableId = c.Int(nullable: false),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.TimeTables", t => t.EventTimeTableId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.EventTimeTableId)
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.FileStorages",
                c => new
                    {
                        FileStorageId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Path = c.String(),
                        FileType = c.Int(nullable: false),
                        isSharedWithOthers = c.Boolean(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.FileStorageId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        TimeTableId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.TimeTables", t => t.TimeTableId, cascadeDelete: true)
                .Index(t => t.TimeTableId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
            CreateTable(
                "dbo.DepartmentCourses",
                c => new
                    {
                        DepartmentCourseId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentCourseId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GradePoint = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GradeSymbol = c.String(),
                    })
                .PrimaryKey(t => t.GradeId);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        TimeTableId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.TimeTables", t => t.TimeTableId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.TimeTableId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Details = c.String(),
                        NewsSource = c.String(),
                    })
                .PrimaryKey(t => t.NewsId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.StudentGrades",
                c => new
                    {
                        StudentGradeId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        TimeTableId = c.Int(nullable: false),
                        Grade_GradeId = c.Int(),
                        Student_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentGradeId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.Grade_GradeId)
                .ForeignKey("dbo.Users", t => t.Student_UserId)
                .ForeignKey("dbo.TimeTables", t => t.TimeTableId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TimeTableId)
                .Index(t => t.Grade_GradeId)
                .Index(t => t.Student_UserId);
            
            CreateTable(
                "dbo.TeacherCourses",
                c => new
                    {
                        TeacherCourseId = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        TimeTableId = c.Int(nullable: false),
                        Teacher_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.TeacherCourseId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Teacher_UserId)
                .ForeignKey("dbo.TimeTables", t => t.TimeTableId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TimeTableId)
                .Index(t => t.Teacher_UserId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.EventEmployees",
                c => new
                    {
                        Event_EventId = c.Int(nullable: false),
                        Employee_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_EventId, t.Employee_UserId })
                .ForeignKey("dbo.Events", t => t.Event_EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Employee_UserId, cascadeDelete: true)
                .Index(t => t.Event_EventId)
                .Index(t => t.Employee_UserId);
            
            CreateTable(
                "dbo.TaskEmployees",
                c => new
                    {
                        Task_TaskId = c.Int(nullable: false),
                        Employee_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Task_TaskId, t.Employee_UserId })
                .ForeignKey("dbo.Tasks", t => t.Task_TaskId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Employee_UserId, cascadeDelete: true)
                .Index(t => t.Task_TaskId)
                .Index(t => t.Employee_UserId);
            
            CreateTable(
                "dbo.TeacherCourse1",
                c => new
                    {
                        Teacher_UserId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_UserId, t.Course_CourseId })
                .ForeignKey("dbo.Users", t => t.Teacher_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.Teacher_UserId)
                .Index(t => t.Course_CourseId);
            
            CreateTable(
                "dbo.ResultGrades",
                c => new
                    {
                        Result_ResultId = c.Int(nullable: false),
                        Grade_GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Result_ResultId, t.Grade_GradeId })
                .ForeignKey("dbo.Results", t => t.Result_ResultId, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.Grade_GradeId, cascadeDelete: true)
                .Index(t => t.Result_ResultId)
                .Index(t => t.Grade_GradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.FileStorages", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.TeacherCourses", "TimeTableId", "dbo.TimeTables");
            DropForeignKey("dbo.TeacherCourses", "Teacher_UserId", "dbo.Users");
            DropForeignKey("dbo.TeacherCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.StudentGrades", "TimeTableId", "dbo.TimeTables");
            DropForeignKey("dbo.StudentGrades", "Student_UserId", "dbo.Users");
            DropForeignKey("dbo.StudentGrades", "Grade_GradeId", "dbo.Grades");
            DropForeignKey("dbo.StudentGrades", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Results", "TimeTableId", "dbo.TimeTables");
            DropForeignKey("dbo.Results", "StudentId", "dbo.Users");
            DropForeignKey("dbo.ResultGrades", "Grade_GradeId", "dbo.Grades");
            DropForeignKey("dbo.ResultGrades", "Result_ResultId", "dbo.Results");
            DropForeignKey("dbo.Results", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.DepartmentCourses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.DepartmentCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendences", "TimeTableId", "dbo.TimeTables");
            DropForeignKey("dbo.Attendences", "StudentId", "dbo.Users");
            DropForeignKey("dbo.Attendences", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Users", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "FileStorageId", "dbo.FileStorages");
            DropForeignKey("dbo.Events", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Users", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles");
            DropForeignKey("dbo.Users", "UserRoleId1", "dbo.UserRoles");
            DropForeignKey("dbo.Users", "DepartmentId1", "dbo.Departments");
            DropForeignKey("dbo.TeacherCourse1", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.TeacherCourse1", "Teacher_UserId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "TimeTableId", "dbo.TimeTables");
            DropForeignKey("dbo.TaskEmployees", "Employee_UserId", "dbo.Users");
            DropForeignKey("dbo.TaskEmployees", "Task_TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Events", "EventTimeTableId", "dbo.TimeTables");
            DropForeignKey("dbo.EventEmployees", "Employee_UserId", "dbo.Users");
            DropForeignKey("dbo.EventEmployees", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.CourseScedules", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.CourseScedules", "TimeTableId", "dbo.TimeTables");
            DropForeignKey("dbo.Courses", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.StudentCourses", "Student_UserId", "dbo.Users");
            DropForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.ResultGrades", new[] { "Grade_GradeId" });
            DropIndex("dbo.ResultGrades", new[] { "Result_ResultId" });
            DropIndex("dbo.TeacherCourse1", new[] { "Course_CourseId" });
            DropIndex("dbo.TeacherCourse1", new[] { "Teacher_UserId" });
            DropIndex("dbo.TaskEmployees", new[] { "Employee_UserId" });
            DropIndex("dbo.TaskEmployees", new[] { "Task_TaskId" });
            DropIndex("dbo.EventEmployees", new[] { "Employee_UserId" });
            DropIndex("dbo.EventEmployees", new[] { "Event_EventId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TeacherCourses", new[] { "Teacher_UserId" });
            DropIndex("dbo.TeacherCourses", new[] { "TimeTableId" });
            DropIndex("dbo.TeacherCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentGrades", new[] { "Student_UserId" });
            DropIndex("dbo.StudentGrades", new[] { "Grade_GradeId" });
            DropIndex("dbo.StudentGrades", new[] { "TimeTableId" });
            DropIndex("dbo.StudentGrades", new[] { "CourseId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Results", new[] { "TimeTableId" });
            DropIndex("dbo.Results", new[] { "CourseId" });
            DropIndex("dbo.Results", new[] { "StudentId" });
            DropIndex("dbo.DepartmentCourses", new[] { "CourseId" });
            DropIndex("dbo.DepartmentCourses", new[] { "DepartmentId" });
            DropIndex("dbo.Tasks", new[] { "TimeTableId" });
            DropIndex("dbo.FileStorages", new[] { "User_UserId" });
            DropIndex("dbo.Events", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Events", new[] { "EventTimeTableId" });
            DropIndex("dbo.CourseScedules", new[] { "Department_DepartmentId" });
            DropIndex("dbo.CourseScedules", new[] { "TimeTableId" });
            DropIndex("dbo.Departments", new[] { "FileStorageId" });
            DropIndex("dbo.StudentCourses", new[] { "Student_UserId" });
            DropIndex("dbo.StudentCourses", new[] { "CourseId" });
            DropIndex("dbo.Users", new[] { "Course_CourseId" });
            DropIndex("dbo.Users", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Users", new[] { "UserRoleId1" });
            DropIndex("dbo.Users", new[] { "DepartmentId1" });
            DropIndex("dbo.Users", new[] { "UserRoleId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropIndex("dbo.Courses", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Attendences", new[] { "TimeTableId" });
            DropIndex("dbo.Attendences", new[] { "CourseId" });
            DropIndex("dbo.Attendences", new[] { "StudentId" });
            DropTable("dbo.ResultGrades");
            DropTable("dbo.TeacherCourse1");
            DropTable("dbo.TaskEmployees");
            DropTable("dbo.EventEmployees");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.TeacherCourses");
            DropTable("dbo.StudentGrades");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.News");
            DropTable("dbo.Results");
            DropTable("dbo.Grades");
            DropTable("dbo.DepartmentCourses");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Tasks");
            DropTable("dbo.FileStorages");
            DropTable("dbo.Events");
            DropTable("dbo.TimeTables");
            DropTable("dbo.CourseScedules");
            DropTable("dbo.Departments");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Users");
            DropTable("dbo.Courses");
            DropTable("dbo.Attendences");
        }
    }
}
