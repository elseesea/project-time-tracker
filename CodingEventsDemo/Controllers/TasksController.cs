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

                return Redirect("/Projects/Detail/" + addTasksViewModel.ProjectId);
            }

            return View(addTasksViewModel);
        }

        public IActionResult Detail(int id)
        {
            Task theTask = context.Tasks
               .Include(t => t.Project)
               .Include(t => t.Project.Client)
               .Include(t => t.Timers)
               .Single(t => t.Id == id);

            TaskDetailViewModel viewModel = new TaskDetailViewModel(theTask);

            return View(viewModel);
        }

        [HttpGet]
        [Route("/tasks/edit/{taskId}")]
        public IActionResult Edit(int taskId)
        {
            Models.Task task = context.Tasks
                .Include(t => t.Project)
                .Single(t => t.Id == taskId);

            EditTaskViewModel editTaskViewModel = new EditTaskViewModel(task);
            return View(editTaskViewModel);
        }

        [HttpPost]
        public IActionResult ProcessEditTaskForm(EditTaskViewModel editTaskViewModel)
        {
            if (ModelState.IsValid)
            {
                Models.Task task = new Models.Task
                {
                    Id = editTaskViewModel.TaskId,
                    Details = editTaskViewModel.Details,
                    ProjectId = editTaskViewModel.ProjectId
                };
                context.Update(task);
                context.SaveChanges();
                return Redirect("Detail/" + editTaskViewModel.TaskId);
            }

            return View("Edit", editTaskViewModel);
        }
    } // class
} // namespace
