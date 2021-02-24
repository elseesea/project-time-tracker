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


    } // class
} // namespace
