using System;
using System.Collections.Generic;
using CodingEventsDemo.Models;

namespace CodingEventsDemo.ViewModels
{
    public class ProjectDetailViewModel
    {
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public List<Task> Tasks { get; set; } = new List<Task>();

        public ProjectDetailViewModel(CodingEventsDemo.Models.Project theProject)
        {
            ProjectId = theProject.Id;
            Description = theProject.Description;
            ClientName = theProject.Client.Name;
            ClientId = theProject.ClientId;

            // The following code truncates, for display purposes, a task's details
            foreach (Task t in theProject.Tasks)
            {
                Task shortenedTask = new Task();
                int detailsLength = t.Details.Length;
                shortenedTask.Id = t.Id;
                if (detailsLength < 50)
                {
                    shortenedTask.Details = t.Details.Substring(0, detailsLength);
                }
                else
                {
                    shortenedTask.Details = t.Details.Substring(0, 50);
                }
                this.Tasks.Add(shortenedTask);
            }
        }

    } // class
} // namespace