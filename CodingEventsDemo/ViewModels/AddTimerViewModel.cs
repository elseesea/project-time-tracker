using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingEventsDemo.ViewModels
{
    public class AddTimerViewModel
    {
        [Required(ErrorMessage = "Begin Time is required!")]
        public DateTime BeginTime { get; set; }

        [Required(ErrorMessage = "End Time is required!")]
        public DateTime EndTime { get; set; }

        public int TaskId { get; set; }

        public string TaskDetails { get; set; }

        public AddTimerViewModel(Models.Task task)
        {
            this.TaskId = task.Id;
            this.TaskDetails= task.Details;
        }

        public AddTimerViewModel()
        {
        }

    } // class

} // namespace
