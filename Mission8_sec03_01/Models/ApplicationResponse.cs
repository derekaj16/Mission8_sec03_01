using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_sec03_01.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int TaskID { get; set; }
        public string Task { get; set; }
        public DateTime DueDate { get; set; }
        public string Quadrant { get; set; } 
        public bool Completed { get; set; } 

        // Build Foreign Key Relationship
        public int CategoryID { get; set; } //dropdown
        public Category Category { get; set; }
    }
}
