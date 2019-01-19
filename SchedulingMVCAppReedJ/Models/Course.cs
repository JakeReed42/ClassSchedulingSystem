using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace SchedulingMVCAppReedJ.Models
{
    public  class Course
    {
        [Key]
        [Required]
        public int CourseID { get; set; } // the get set allows for assigning value
        [Required]
        public string CourseNumber { get; set; }
        [Required]
        public string CourseName { get; set; }

        //Connect in 2 ways. Connect for the relational database
        [Required]
        public int DepartmentID { get; set; }

        //Connect for Object-Orientation 
        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        //Constructors

        public Course()
        {

        }

        public Course(string courseNumber, string courseName, int departmentID)
        {
            this.CourseNumber = courseNumber;
            this.CourseName = courseName;
            this.DepartmentID = departmentID;
        }// end of constructor

        public static List<Course> PopulateCourses()
        {
           List < Course > courseList =
                new List<Course>();

            Course course = new Course("MIST 450", "System Analysis", 1);
            courseList.Add(course);

            course = new Course("MIST 353", "Advanced IT", 1);
            courseList.Add(course);

           course = new Course("ACCT 331", "Managerial Accounting", 2);
            courseList.Add(course);

            course = new Course("ACCT 202", "That Other Accounting Class", 2);
            courseList.Add(course);

            course = new Course("MKTG 201", "Selling Things", 3);
            courseList.Add(course);

            course = new Course("MKTG 450", "MadMen the marketing experience", 3);
            courseList.Add(course);
           
            return courseList;
        }

       
    }// end of class


}// end of Namespace

//to address your question about the 3 months in advanced thing.
//We could maybe make it a month long thing with auto updating dates
