using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Purposes.Models
{
    public class CustomList
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [StringLength(30, ErrorMessage = "Name too long")]
        public string Name { get; set; }
        public List<Purpose> SelectedPurposes { get; set; } = new List<Purpose>();
    }
}
