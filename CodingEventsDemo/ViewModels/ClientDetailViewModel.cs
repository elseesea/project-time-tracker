using System;
using System.Collections.Generic;
using CodingEventsDemo.Models;

namespace CodingEventsDemo.ViewModels
{
    public class ClientDetailViewModel
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();

        public ClientDetailViewModel(ProjectClient theClient)
        {
            ClientId = theClient.Id;
            ClientName = theClient.Name;
            Projects = theClient.Projects;
        }

        public ClientDetailViewModel()
        {

        }

    } // class
} // namespace