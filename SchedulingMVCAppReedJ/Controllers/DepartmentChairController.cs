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
    public class DepartmentChairController : Controller
    {

        private ApplicationDbContext database;

        public DepartmentChairController(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }
        //DepartmentChair Full Name, Email, Department Name
        public IActionResult GetDepartmentChairs()
        {
            //List<Department> listOfDepartments = database.Departments.ToList<Department>();

            List<DepartmentChair> listOfChairs
              = database.DepartmentChairs.Include(dc => dc.Department).ToList<DepartmentChair>();

            //ViewData and ViewBag

            return View(listOfChairs);
        }


    }// end of class
}// end of namespace