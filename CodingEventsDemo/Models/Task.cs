using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Details { get; set; }

        public Project Project { get; set; }

        public int ProjectId { get; set; }

        public Task(string details)
        {
            Details = details;
        }

        public Task()
        {

        }
    } // class

} // namespace
