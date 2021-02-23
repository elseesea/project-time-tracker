using System;
using System.ComponentModel.DataAnnotations;
/*
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
*/

namespace CodingEventsDemo.ViewModels
{
    public class AddProjectViewModel
    {
        [Required(ErrorMessage = "Description is required!")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 100 characters long")]
        public string Description { get; set; }
    } // class

} // namespace
