using CodingEventsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.ViewModels
{
    public class TaskDetailViewModel
    {
        public int TaskId { get; set; }
        public string Details { get; set; }
        public CodingEventsDemo.Models.Project Project { get; set; }

        public List<Timer> Timers { get; set; } = new List<Timer>();

        public TaskDetailViewModel(CodingEventsDemo.Models.Task theTask)
        {
            TaskId = theTask.Id;
            Details = theTask.Details;
            this.Project = theTask.Project;
            Timers = theTask.Timers;
        }

    }  // class
} // namespace
