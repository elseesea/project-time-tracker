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

        [Route("/tasks/create/{taskProjectId}")]
        public IActionResult Create(int taskProjectId)
        {
            AddTasksViewModel addTasksViewModel = new AddTasksViewModel(taskProjectId);
            return View(addTasksViewModel);
        }

        [HttpPost]
        public IActionResult Create(AddTasksViewModel addTasksViewModel)
        {
            if (ModelState.IsValid)
            {
                Task newTask= new Task
                {
                    Details = addTasksViewModel.Details,
                    ProjectId = addTasksViewModel.ProjectId
                };

                context.Tasks.Add(newTask);
                context.SaveChanges();

                return Redirect("/Tasks");
            }

            return View(addTasksViewModel);
        }

    } // class
} // namespace
