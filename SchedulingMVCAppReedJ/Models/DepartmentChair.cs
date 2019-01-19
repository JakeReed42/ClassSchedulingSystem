using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingMVCAppReedJ.Models
{
    public class DepartmentChair : ApplicationUser
    {
        public string DepartmentChairID { get; set; }


        //Link to Department
        public int DepartmentID { get; set; }

        // Object Oriented Connection to user
        [ForeignKey("DepartmentChairID")]
        ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set;}
    
        public DepartmentChair() { }

        public DepartmentChair (string firstName,string lastName, 
                string email, string phone, string password, int departementID) :
            
            // "base" refers to all info taken from the parent class. 
            base(firstName, lastName, email, phone, password)
        {
            this.DepartmentID = departementID;
            this.DepartmentChairID = this.Id;// this auto generates the departmentchairID
        }// end of constructor

        public static List<DepartmentChair> PopulateDepartmentChair()
        {
            List<DepartmentChair> listOfChairs =
                new List<DepartmentChair>();

            DepartmentChair chair =
                new DepartmentChair("test", "MISChair1", "TestMISChair@wvu.edu",
                "304-988-2300", "TestMISChair1", 1);
                listOfChairs.Add(chair);

            chair = new DepartmentChair("Tim", "Muffins", "SMuffins@wvu.edu", "304-230-9941",
                "SwaggyMuffins1", 2);
                listOfChairs.Add(chair);

            chair = new DepartmentChair("Jim", "Collins", "JCollins@wvu.edu", "304-867-5309",
                "JimCollins1", 3);
            listOfChairs.Add(chair);

            return listOfChairs;
        }

    }// end of class
}// end of namespace
