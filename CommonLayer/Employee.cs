using System;
using System.ComponentModel.DataAnnotations;

namespace CommonLayer
{
    public class Employee
    {

        public int EmployeeID { get; set; }
        
        [Required]
        public string EmployeeName { get; set; }
        
        public string ProfileImg { get; set; }
        
        [Required]
        public char Gender { get; set; }
        
        [Required]
        public string Department { get; set; }
        
        [Required]
        public decimal Salary { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Notes cannot be blank.")]
        public string Notes { get; set; }

        public Department EmployeeDepartment { get; set; }



        /*        public int EmployeeID { get; set; }
                [Required]
        *//*        public string EmployeeName { get; set; }
                public string ProfileImg { get; set; }
        */
        /*        [Required]
                public string Gender { get; set; }

                [Required]
                public string Department { get; set; }

                [Required]
                public long Salary { get; set; }

                [Required]
                public DateTime StartDate { get; set; }
                public string Note { get; set; }
        */
    }

    /*public enum Department
    {
        Sales,
        Marketing,
        Engineering,
        Finance,
        HumanResources,
        IT,
        ProductManagement,
        CustomerSupport,
        Operations,
        Legal
    }*/

    public enum Department
    {
        Sales, 
        Marketing, 
        Engineering, 
        Finance, 
        Human_Resources,
        IT, 
        Product_Management,
        Customer_Support,
        Operations, 
        Legal,
        Other

        //new SelectListItem { Text = "Sales", Value = "Sales" },
        //new SelectListItem { Text = "Marketing", Value = "Marketing" },
        //new SelectListItem { Text = "Engineering", Value = "Engineering" },
        //new SelectListItem { Text = "Finance", Value = "Finance" },
        //new SelectListItem { Text = "Human Resources", Value = "Human Resources" },
        //new SelectListItem { Text = "IT", Value = "IT" },
        //new SelectListItem { Text = "Product Management", Value = "Product Management" },
        //new SelectListItem { Text = "Customer Support", Value = "Customer Support" },
        //new SelectListItem { Text = "Operations", Value = "Operations" },
        //new SelectListItem { Text = "Legal", Value = "Legal" }
    }

}
