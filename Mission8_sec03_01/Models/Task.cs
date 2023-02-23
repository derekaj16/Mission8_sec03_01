using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_sec03_01.Models
{
    public class TaskModel
    {
        [Key]
        [Required]
        public int TaskID { get; set; }
        [Required]
        public string Task { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public bool Completed { get; set; }
    }
}
