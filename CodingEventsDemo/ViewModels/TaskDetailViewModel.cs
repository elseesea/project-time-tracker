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

        //public List<Task> Tasks { get; set; } = new List<Task>();

        public TaskDetailViewModel(CodingEventsDemo.Models.Task theTask)
        {
            TaskId = theTask.Id;
            Details = theTask.Details;
            this.Project = theTask.Project;
        }

    }  // class
} // namespace
