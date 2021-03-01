using CodingEventsDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.ViewModels
{
    public class EditTaskViewModel
    {
        [Required(ErrorMessage = "Task Detail is required!")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Task Detail must be between 1 and 500 characters long")]
        public string Details { get; set; }

        public int TaskId { get; set; }
        public int ProjectId { get; set; }

        public string ProjectDescription { get; set; }


        public EditTaskViewModel(Models.Task task)
        {
            this.TaskId = task.Id;
            this.Details = task.Details;
            this.ProjectId = task.ProjectId;
            this.ProjectDescription = task.Project.Description;
        }

        public EditTaskViewModel()
        {
        }

    } // class
} // namespace
