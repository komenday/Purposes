using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Purpose.Models
{
    public class Purpose
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [StringLength(30, ErrorMessage = "Name too long")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Due { get; set; }
        public Importance? Importance { get; set; }
    }
}
