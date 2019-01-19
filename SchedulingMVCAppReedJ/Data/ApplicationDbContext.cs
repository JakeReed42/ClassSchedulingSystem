using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchedulingMVCAppReedJ.Models;

namespace SchedulingMVCAppReedJ.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        // this makes the connection to the database. 

        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<DepartmentChair> DepartmentChairs { get; set; }

        public DbSet<ConflictCourse> ConflictCourses { get; set; }
        //Child classes reuse methods and properties from parent classes

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<CourseOffering> CourseOfferings { get; set; }

    

    } // end of class 
} // end of name space 
