using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Controllers
{
    public class ProjectClientController : Controller
    {
        private EventDbContext context;

        public ProjectClientController(EventDbContext dbContext)
        {
            context = dbContext;
        }


        public IActionResult Index()
        {
            List<ProjectClient> clients = context.Clients
                .Include(c => c.Projects)
                .ToList();

            return View(clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddProjectCategoryViewModel addProjectCategoryViewModel= new AddProjectCategoryViewModel();
            return View(addProjectCategoryViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateProjectClientForm(AddProjectCategoryViewModel addProjectCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                ProjectClient newClient = new ProjectClient
                {
                    Name = addProjectCategoryViewModel.Name
                };

                context.Clients.Add(newClient);
                context.SaveChanges();

                return Redirect("/ProjectClient");
            }

            return View("Create", addProjectCategoryViewModel);
        }

        [HttpGet]
        [Route("/projectclient/edit/{clientId}")]
        public IActionResult Edit(int clientId)
        {
            ProjectClient client = context.Clients
                .Include(c => c.Projects)
                .Single(c => c.Id == clientId);

            EditClientViewModel editClientViewModel = new EditClientViewModel(client);
            return View(editClientViewModel);
        }

        [HttpPost]
        public IActionResult ProcessEditProjectClientForm(EditClientViewModel editClientViewModel)
        {
            if (ModelState.IsValid)
            {
                ProjectClient client = new ProjectClient
                {
                    Id = editClientViewModel.ClientId,
                    Name = editClientViewModel.Name
                };
                context.Update(client);
                context.SaveChanges();
                return Redirect("Index");
            }

            return View("Edit", editClientViewModel);
        }
        // Show all projects for a given client
        public IActionResult Detail(int id)
        {
            ProjectClient client = context.Clients
               .Include(c => c.Projects)
               .Single(c => c.Id == id);

            ClientDetailViewModel viewModel = new ClientDetailViewModel(client);

            return View(viewModel);
        }

    } // class
} // namespace
