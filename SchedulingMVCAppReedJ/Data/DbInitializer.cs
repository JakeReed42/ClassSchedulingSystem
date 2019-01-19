using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchedulingMVCAppReedJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingMVCAppReedJ.Data
{
    public class DbInitializer
    {
        public async static Task Initialize(IServiceProvider services)
        {
            //change from accessing just the database service
            //add user and role services. 
            //var refers to generic variable... can hold any datatype
            var database = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            //List<DepartmentChair> departmentChairList = DepartmentChair.PopulateDepartmentChair();


            //Step 1: Avoid "Re-populating" tables with the same data

            if (!database.Departments.Any())
            {

                //List<DepartmentChair> departmentChairs = database.DepartmentChairs.ToList<DepartmentChair>();


                //Department department = new Department("Management Information Systems", departmentChairs[0].DepartmentChairID);
                //List<Department> departmentsList = new List<Department>();
                //departmentsList.Add(department);


                //department = new Department("Accounting", departmentChairs[1].DepartmentChairID);
                //departmentsList.Add(department);
                //Step 2: Get data for Departments table
                // Class method. Call using Class Department6


                //  department.PopulateDepartments(); this is an error because we made the static

                //List<DepartmentChair> departments = database.Departments.ToList<DepartmentChair>();

                List<Department> departmentList = Department.PopulateDepartments();
                 database.Departments.AddRange(departmentList);
                 database.SaveChanges();
            }



            // This is the data population for Course
            if (!database.Courses.Any())
            {
                List<Course> courseList = Course.PopulateCourses();

                database.Courses.AddRange(courseList);
                database.SaveChanges();
            }

            string roleCoordinator = "Coordinator";
            String roleDepartmentChair = "Chair";

            List<ApplicationUser> appUserList =
                ApplicationUser.PopulateUsers();

            if (!database.Roles.Any())
            {

                IdentityRole role = new IdentityRole(roleCoordinator);
                await roleManager.CreateAsync(role);


                role = new IdentityRole(roleDepartmentChair);
                await roleManager.CreateAsync(role);
            }

            


            if (!database.Users.Any())
            {
                //DBConn 1 (Synchronus - Method 1)
                //DBConn 1 (Sych - Method 2)
                // this means method 2 only goes after method 1 is done
                // Async means that both can go go at the same time 

                foreach (ApplicationUser eachCoordinator in appUserList)
                {
                    //userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    await userManager.CreateAsync(eachCoordinator);

                    //userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    await userManager.AddToRoleAsync(eachCoordinator, roleCoordinator);

                }
            }


            // Need to finish added department chairs to the list. 



            List<DepartmentChair> chairList =
                DepartmentChair.PopulateDepartmentChair();

            if (!database.DepartmentChairs.Any())
            {

                foreach (DepartmentChair eachChair in chairList)
                {
                    await userManager.CreateAsync(eachChair);

                    await userManager.AddToRoleAsync(eachChair, roleDepartmentChair);

                }
            }
            if (!database.ConflictCourses.Any())
            {
                List<ConflictCourse> conflictCourseList = ConflictCourse.PopulateConflictCourses();

                database.ConflictCourses.AddRange(conflictCourseList);
                database.SaveChanges();
            }



            if (!database.Instructors.Any())
            {
                List<Instructor> instructorList = Instructor.PopulateInstructors();
                database.Instructors.AddRange(instructorList);
                database.SaveChanges();
            }

            if (!database.CourseOfferings.Any())
            {
                List<CourseOffering> offeringList = CourseOffering.PopulateCourseOffering();
                database.CourseOfferings.AddRange(offeringList);
                database.SaveChanges();

            }


           
            List<Department> departments =
                database.Departments.ToList<Department>();

            if (departments[0].DepartmentChairID == null)
            {
                List<DepartmentChair> departmentChairs =
                    database.DepartmentChairs.ToList<DepartmentChair>();

                departments[0].DepartmentChairID = departmentChairs[0].DepartmentChairID;
                database.Departments.Update(departments[0]);

                departments[1].DepartmentChairID = departmentChairs[1].DepartmentChairID;
                database.Departments.Update(departments[1]);
            }
            //departments[2].DepartmentChairID = departmentChairs[2].DepartmentChairID;
            //database.Departments.Update(departments[2]);

            database.SaveChanges();

        }// end of task

}// End of Class

}// End of Namespace
