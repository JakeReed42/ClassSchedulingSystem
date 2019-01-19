using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingMVCAppReedJ.Models
{
    public class ConflictCourse
    {
        [Key]
        [Required]
        public int ConflictCourseID { get; set; }

        //connect for relational 
        [Required]
        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        // connects the second
        [Required]
        public int ConflictedCourseID { get; set; }
        [ForeignKey("ConflictedCourseID")]
        public Course ConflictedCourse { get; set; }

        public ConflictCourse () {}

        public ConflictCourse(int courseID, int conflictingCourseID)
        {
            this.CourseID = courseID;
            this.ConflictedCourseID = conflictingCourseID;
        }
        public static List<ConflictCourse> PopulateConflictCourses()
        {
            List<ConflictCourse> list
                = new List<ConflictCourse>();

            ConflictCourse conflictCourse =
                new ConflictCourse(1, 2);
            list.Add(conflictCourse);

           conflictCourse =
                new ConflictCourse(2, 1);
            list.Add(conflictCourse);

            conflictCourse =
                new ConflictCourse(3, 4);
            list.Add(conflictCourse);

            conflictCourse =
                new ConflictCourse(4, 3);
            list.Add(conflictCourse);

            return list;
        }

    }
}
