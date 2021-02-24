using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodingEventsDemo.Controllers
{
    public class ProjectsController : Controller
    {

        private EventDbContext context;

        public ProjectsController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            //var user = context.Users.Single(a => a.Login == User.Identity.Name);

            //string currentUser = User.Identity.Name;

            /*
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            Project project = new Project(;

            return View(currentUserID);
            */

            List<Project> projects = context.Projects
                .Include(p => p.Client)
                .ToList();


            return View(projects);
        }

        public IActionResult Add()
        {
            List<ProjectClient> clients = context.Clients.ToList();
            AddProjectViewModel addProjectViewModel = new AddProjectViewModel(clients);

            return View(addProjectViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddProjectViewModel addProjectViewModel)
        {
            if (ModelState.IsValid)
            {
                ProjectClient theClient = context.Clients.Find(addProjectViewModel.ClientId);
                Project newProject = new Project
                {
                    Description = addProjectViewModel.Description,
                    Client = theClient
                };

                context.Projects.Add(newProject);
                context.SaveChanges();

                return Redirect("/Projects");
            }

            return View(addProjectViewModel);
        }

        public IActionResult Detail(int id)
        {
            Project theProject = context.Projects
               .Include(p => p.Client)
               .Include(p => p.Tasks)
               .Single(p => p.Id == id);

            ProjectDetailViewModel viewModel = new ProjectDetailViewModel(theProject);

            return View(viewModel);
        }

    } // class
} // namespace
