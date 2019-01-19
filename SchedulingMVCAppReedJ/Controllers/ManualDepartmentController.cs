using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulingMVCAppReedJ.Data;
using SchedulingMVCAppReedJ.Models;

namespace SchedulingMVCAppReedJ.Controllers
{
    // Below shows inhertance (Child : Parent)
    public class ManualDepartmentController : Controller
    {
        //attribute of this class
        private ApplicationDbContext database;

        //Constructor Biggest hint is that it has the same name as the class
        //
        public ManualDepartmentController(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        [Authorize]
        public IActionResult GetAllDepartments()
        {

           List<Department> departmentList = 
                database.Departments.Include(d => d.DepartmentChair).ToList<Department>();

            return View(departmentList);
        }
    }// end of class
}// end of method