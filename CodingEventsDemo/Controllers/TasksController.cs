using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = CodingEventsDemo.Models.Task;

namespace CodingEventsDemo.Controllers
{
    public class TasksController : Controller
    {
        private EventDbContext context;

        public TasksController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Models.Task> tasks = context.Tasks
                .ToList();


            return View(tasks);
        }

        [HttpGet]
        [Route("/tasks/create/{taskProjectId}")]
        public IActionResult Create(int taskProjectId)
        {
            Project aProject = context.Projects
               .Single(p => p.Id == taskProjectId);

            AddTasksViewModel addTasksViewModel = new AddTasksViewModel(aProject);
            return View(addTasksViewModel);
        }

        [HttpPost]
        public IActionResult Create(AddTasksViewModel addTasksViewModel)
        {
            if (ModelState.IsValid)
            {
                Task newTask = new Task
                {
                    Details = addTasksViewModel.Details,
                    ProjectId = addTasksViewModel.ProjectId
                };

                context.Tasks.Add(newTask);
                context.SaveChanges();

                return Redirect("/Tasks");
            }

            return View(addTasksViewModel);
/*
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
            */
        }


        public IActionResult Detail(int id)
        {
            Task theTask = context.Tasks
               .Include(t => t.Project)
                .Include(t => t.Project.Client)
               .Single(t => t.Id == id);

            TaskDetailViewModel viewModel = new TaskDetailViewModel(theTask);

            return View(viewModel);
        }

    } // class
} // namespace
