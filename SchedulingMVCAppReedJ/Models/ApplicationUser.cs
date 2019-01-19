using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SchedulingMVCAppReedJ.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public ApplicationUser() { }

        public ApplicationUser(string firstName, string lastName, string email, string phone, string password) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phone;


            //hashing a password
            PasswordHasher<ApplicationUser> passwordHasher
                = new PasswordHasher<ApplicationUser>();

            this.PasswordHash = passwordHasher.HashPassword(this, password);
            this.SecurityStamp = Guid.NewGuid().ToString();
            this.UserName = email;
        }

        public static List<ApplicationUser> PopulateUsers()
        {
            List<ApplicationUser> listUsers =
                new List<ApplicationUser>();

            ApplicationUser applicationUser =
                  new ApplicationUser("Test", "Coordinator1",
                  "TestCoordinator1@wvu.edu", "304-867-5309", "TestCoordinator1");
            listUsers.Add(applicationUser);

            // add another user.

            applicationUser = new ApplicationUser("Test", "Coordinator2",
                "TestCoordinator2@wvu.edu", "304-228-9154", "TestCoordinator2");
            listUsers.Add(applicationUser);

            return listUsers;
        }
    }// end of class
}// end of namespace
