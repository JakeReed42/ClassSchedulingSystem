using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingMVCAppReedJ.Models
{
    public class Department
    {
        //MVC recommends properties for classes
        // not attributes

        [Key]
        [Required]
        public int DepartmentID { get; set; } // three types, private, public, protected

        [Required]
        public string DepartmentName { get; set; }

        
        public string DepartmentChairID { get; set; }
        [ForeignKey("DepartmentChairID")]

        public DepartmentChair DepartmentChair { get; set; }

        // construct objects (using constructor)
        // special methods
        // In MVC when you create own Constructor,
        // We need to add an empty Constructor, whenever you create a constructor of your own. 

        public Department(string departmentName ) // Need to pass this value into DepartmentName
        {
            this.DepartmentName = departmentName;
            //this.DepartmentChairID = chairID;

        }

        public Department()
        {

        }

        //accessType returnType MethodName(ParamType, ParamName)
        // static
        //Class Method (static)
        //Object / Instance Method
        public static List<Department> PopulateDepartments()
        {
            List<Department> departmentList = new List<Department>();
            Department department = new Department("Management Information Systems");
            departmentList.Add(department);

            department = new Department("Accounting");
            departmentList.Add(department);

            department = new Department("Marketing");
            departmentList.Add(department);

            return departmentList;

        }
        

    }// End Class

}// end of NameSpace
