using CodingEventsDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.ViewModels
{
    public class EditProjectViewModel
    {
        [Required(ErrorMessage = "Description is required!")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Description must be between 4 and 100 characters long")]
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public EditProjectViewModel(Models.Project project)
        {
            this.ProjectId = project.Id;
            this.Description = project.Description;
            this.ClientId = project.ClientId;
            this.ClientName = project.Client.Name;
        }

        public EditProjectViewModel()
        {
        }

    } // class
} // namespace
