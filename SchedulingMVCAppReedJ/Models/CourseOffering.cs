using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingMVCAppReedJ.Models
{
    public class CourseOffering
    {
        [Key]
        [Required]
        public int CourseOfferingID { get; set; }

        [Required]
        public string CRN { get; set; }

        public string Days { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [DataType(DataType.Date)]
        [Required] 
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime EndDate { get; set; }

        public int InstructorID { get; set; }
          
        public int CourseID { get; set; }

        [ForeignKey("InstructorID")]
        public Instructor Instructor { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        public CourseOffering() { }


        // ADD TO DBCONTEXT 

        // FINISH CONSTRUCTOR
        public CourseOffering(string crn, string days, DateTime startTime, DateTime endTime, 
            DateTime startDate, DateTime endDate, int instructorID, int courseID)
        {
            this.CRN = crn;
            this.Days = days;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.StartDate = startDate;
            this.EndDate = endTime;
            this.InstructorID = instructorID;
            this.CourseID = courseID;
        }

        //POPULATE 4 COURSES
        public static List<CourseOffering> PopulateCourseOffering()
        {
            List<CourseOffering> courseOfferingList = new List<CourseOffering>();

            DateTime startDate = new DateTime(2018, 8, 15);
            DateTime endDate = new DateTime(2018, 12, 07);


            string day = "M W F";
            DateTime startTime = DateTime.Parse("8:30 AM");
            DateTime endTime = DateTime.Parse("9:20 AM");

            CourseOffering courseOffering3Days = new CourseOffering("658841", day, startTime, endTime, startDate, endDate, 1, 1);
            courseOfferingList.Add(courseOffering3Days);


            startTime = DateTime.Parse("9:30 AM");
            endTime = DateTime.Parse("10:20 AM");
            courseOffering3Days = new CourseOffering("551843", day, startTime, endTime, startDate, endDate, 1, 2);
            courseOfferingList.Add(courseOffering3Days);

            
            startTime = DateTime.Parse("1:30 PM");
            endTime = DateTime.Parse("2:20 PM");
            courseOffering3Days = new CourseOffering("229814", day, startTime, endTime, startDate, endDate, 3, 3);
            courseOfferingList.Add(courseOffering3Days);

            day = "T TR";
            startTime = DateTime.Parse("8:30 AM");
            endTime = DateTime.Parse("9:45 AM");
            CourseOffering courseOffering2Days = new CourseOffering("799264", day, startTime, endTime, startDate, endDate, 4, 5);
            courseOfferingList.Add(courseOffering2Days);


            return courseOfferingList;
        }
    }// end of class 
}// end of namespace


