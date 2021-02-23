using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEventsDemo.ViewModels
{
    public class AddProjectCategoryViewModel
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters long")]
        public string Name { get; set; }
    }
}
