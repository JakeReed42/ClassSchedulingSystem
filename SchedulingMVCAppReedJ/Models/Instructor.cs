using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingMVCAppReedJ.Models
{
    public class Instructor
    {
        [Key]
        [Required]
        public int InstructorID { get; set; }

        [Required]
        public string InstructorFirstName { get; set; }

        [Required]
        public string InstructorLastName { get; set; }

        [Required]
        public string InstructorEmail { get; set; }

        
        public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        public Instructor(string instructorFirstName, string instructorLastName, string instructorEmail, int departmentID)
        {
            this.InstructorFirstName = instructorFirstName;
            this.InstructorLastName = instructorLastName;
            this.InstructorEmail = instructorEmail;
            this.DepartmentID = departmentID;
        }

        public Instructor()
        { }


        public static List<Instructor> PopulateInstructors()
        {
            List<Instructor> instructorList = new List<Instructor>();

            Instructor instructor = new Instructor("Nanda", "Surendra", "NaSurendra@Mix",1);
            instructorList.Add(instructor);

            instructor = new Instructor("Virginia", "Kliest", "VKliest@Mix", 1);
            instructorList.Add(instructor);

            instructor = new Instructor("Ludwig", "Schuapp", "LudSchuapp@Mix", 2);
            instructorList.Add(instructor);

            instructor = new Instructor("Leeroy", "Jenkins", "TimesUp@Mix", 3);
            instructorList.Add(instructor);

            return instructorList;
        }
    }// end of class

}// end of namespace


// ADD CourseOffering.