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
    public class AddProjectViewModel
    {
        [Required(ErrorMessage = "Description is required!")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 100 characters long")]
        public string Description { get; set; }

        public int ClientId { get; set; }

        public List<SelectListItem> Clients { get; set; }

        public AddProjectViewModel(List<ProjectClient> clients)
        {
            Clients = new List<SelectListItem>();
            foreach (var client in clients)
            {
                Clients.Add(
                    new SelectListItem
                    {
                        Value = client.Id.ToString(),
                        Text = client.Name
                    }
                ); ;
            }
        }

        public AddProjectViewModel()
        {

        }

    } // class

} // namespace
