using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchedulingMVCAppReedJ.Data;
using SchedulingMVCAppReedJ.Models;

namespace SchedulingMVCAppReedJ.Controllers
{
    public class ManualCourseController : Controller
    {

        private ApplicationDbContext database;

        public ManualCourseController(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        public IActionResult GetAllCourses()
        {

            // the "c => c.Department" is called a lambda expression. 
            List<Course> courseList = database.Courses.Include(c => c.Department).ToList<Course>();
            //^ the include statement tells the program to also allow the Department info. 

           

            return View(courseList);
        }// end of GetAllCourses Method

        // this makes it so only departmentChairs can access this page
        [Authorize(Roles = "Chair")]
        public IActionResult SearchForCoursesByDepartment()
        {
            //Design choice: For Project, when to use hard coded list values instead of database
            //When values are non-Changing/ smaller number of values.
            //List<String> semesterList = new List<string>();
            //semesterList.Add("Fall");
            //semesterList.Add("Spring");
            //semesterList.Add("Summer");

            ViewData["Departments"] = new SelectList (database.Departments, "DepartmentID","DepartmentName");

            return View("SearchForCourses");
        }

        public IActionResult FindCoursesByDepartment(int? departmentID)
        {
            List<Course> courseList 
                = database.Courses.Include(c => c.Department).ToList<Course>();

            //List<Course> queriedList = new List<Course>();

            

            //sql in c#
            // LINQ: Language INtergrated Query
            // is the same as IsNull in sql
            if (departmentID != null)
            {

                courseList = 
                courseList.Where(c => c.DepartmentID == departmentID).ToList<Course>();
            //^ this is saying to set courseList set to a list of courses from the database 
            // where the DepartmentIDs match
             

                //    foreach (Course course in courseList)
                //{
                //    if (course.DepartmentID == departmentID)
                //    queriedList.Add(course);
                //    // this is saying that if the IDs match to add the course to the new list
                    
                //}// end of a foreach
                
                //return View("SearchResult", queriedList);
            }// end of the if statement that selects a certain department





            return View("SearchResult", courseList);
            // this return the name of the view you are going to need.

        }
    }// end of class
}// end of Namespace