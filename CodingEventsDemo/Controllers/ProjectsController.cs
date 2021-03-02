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

        // Add a project for a specific client
        [Route("/projects/add/{clientId}")]
        public IActionResult Add(int clientId)
        {
            ProjectClient client = context.Clients
                .Single(c => c.Id == clientId);

            List<ProjectClient> clients = new List<ProjectClient> { client };
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

        [Route("/projects/detail/{id}")]
        public IActionResult Detail(int id)
        {
            Project theProject = context.Projects
               .Include(p => p.Client)
               .Include(p => p.Tasks)
               .Single(p => p.Id == id);

            ProjectDetailViewModel viewModel = new ProjectDetailViewModel(theProject);

            return View(viewModel);
        }

        [HttpGet]
        [Route("/projects/edit/{projectId}")]
        public IActionResult Edit(int projectId)
        {
            Models.Project project = context.Projects
                .Include(p => p.Client)
                .Single(p => p.Id == projectId);

            EditProjectViewModel editProjectViewModel = new EditProjectViewModel(project);
            return View(editProjectViewModel);
        }

        [HttpPost]
        public IActionResult ProcessEditProjectForm(EditProjectViewModel editProjectViewModel)
        {
            if (ModelState.IsValid)
            {
                Models.Project project = new Models.Project
                {
                    Id = editProjectViewModel.ProjectId,
                    Description = editProjectViewModel.Description,
                    ClientId = editProjectViewModel.ClientId
                };
                context.Update(project);
                context.SaveChanges();
                return Redirect("Detail/" + editProjectViewModel.ProjectId);
            }

            return View("Edit", editProjectViewModel);
        }

    } // class
} // namespace
