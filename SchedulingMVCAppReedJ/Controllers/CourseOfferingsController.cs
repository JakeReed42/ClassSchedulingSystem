using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchedulingMVCAppReedJ.Data;
using SchedulingMVCAppReedJ.Models;

namespace SchedulingMVCAppReedJ.Controllers
{
    public class CourseOfferingsController : Controller
    {
        private ApplicationDbContext database;

        //dependency Inversion (DI)
        public CourseOfferingsController(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }


        public IActionResult SearchCourseOfferings()
        {

            // 1. By Department (Name, ID)
         ViewData["Departments"]  = new SelectList(database.Departments, "DepartmentID", "DepartmentName");


            // 2. By Instructor (Name, ID)
            ViewData["Instructors"] = new SelectList
                (database.Instructors, "InstructorID", "InstructorLastName");


            return View();
        }

        [HttpPost]
        public IActionResult SearchResult(int? DepartmentID, DateTime? StartTime, DateTime? EndTime, int? InstructorID,
            DateTime? StartDate, DateTime? EndDate)
        {
            List<CourseOffering> OfferingList =
                database.CourseOfferings.Include(co => co.Course).Include(co => co.Instructor).Include(co => co.Course.Department).ToList<CourseOffering>();

           if(DepartmentID != null)
            {
                OfferingList =
                    OfferingList.Where(co => co.Course.DepartmentID == DepartmentID).ToList<CourseOffering>();

            }

           if(StartTime != null)
            {
                OfferingList =
                    OfferingList.Where(co => co.StartTime.TimeOfDay >= StartTime.Value.TimeOfDay).ToList<CourseOffering>();
            }

           if(EndTime != null)
            {
                OfferingList =
                    OfferingList.Where(co => co.EndTime.TimeOfDay <= EndTime.Value.TimeOfDay).ToList<CourseOffering>();

            }

           if(InstructorID != null)
            {
                OfferingList =
                    OfferingList.Where(co => co.InstructorID == InstructorID).ToList<CourseOffering>();
            }

           if(StartDate != null)
            {
                OfferingList =
                    OfferingList.Where(co => co.StartDate >= StartDate.Value.Date).ToList<CourseOffering>();
            }

            if (EndDate != null)
            {
                OfferingList =
                    OfferingList.Where(co => co.EndDate <= EndDate.Value.Date).ToList<CourseOffering>();
            }


            return View(OfferingList);
        }

    }
}