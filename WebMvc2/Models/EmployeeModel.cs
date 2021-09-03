using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMvc2.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Emp_ID { get; set; }
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        public DateTime EMP_DOB { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        [Display(Name = "RoleID")]
        public int RoleID { get; set; }
    }
}