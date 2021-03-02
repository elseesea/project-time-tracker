using CodingEventsDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.ViewModels
{
    public class EditClientViewModel
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters long")]
        public string Name { get; set; }

        public int ClientId { get; set; }

        public List<Project> Projects { get; set; }

        public EditClientViewModel(ProjectClient client)
        {
            this.ClientId = client.Id;
            this.Name = client.Name;
            this.Projects = client.Projects;
        }

        public EditClientViewModel()
        {
        }

    } // class
} // namespace
