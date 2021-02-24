using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
/*
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
*/

namespace CodingEventsDemo.ViewModels
{
    public class AddTasksViewModel
    {
        [Required(ErrorMessage = "Detail is required!")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Detail must be between 1 and 500 characters long")]
        public string Details { get; set; }

        public int ProjectId { get; set; }

        //public List<SelectListItem> Clients { get; set; }

        public AddTasksViewModel(int projectId)
        {
            this.ProjectId = projectId;
        }

        public AddTasksViewModel()
        {
        }

    } // class

} // namespace
