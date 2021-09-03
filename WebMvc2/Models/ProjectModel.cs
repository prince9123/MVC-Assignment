using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMvc2.Models
{
    public class ProjectModel
    {
        public int Proid { get; set; }
        [Required]
        public String Project_name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public String Budget { get; set; }


    }
}