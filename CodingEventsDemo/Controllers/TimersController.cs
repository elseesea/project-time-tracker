using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Controllers
{
    public class TimersController : Controller
    {
        private EventDbContext context;

        public TimersController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/timers/create/{taskId}")]
        public IActionResult Create(int taskId)
        {
            Models.Task task = context.Tasks
                .Single(t => t.Id == taskId);
            AddTimerViewModel addTimerViewModel = new AddTimerViewModel(task);
            return View(addTimerViewModel);
        }

        [HttpPost]
        public IActionResult Create(AddTimerViewModel addTimerViewModel)
        {
            if (ModelState.IsValid)
            {
                Timer newTimer = new Timer
                {
                    BeginTime = addTimerViewModel.BeginTime,
                    EndTime = addTimerViewModel.EndTime,
                    TaskId = addTimerViewModel.TaskId
                };

                context.Timers.Add(newTimer);
                context.SaveChanges();

                return Redirect("/Tasks/Detail/" + addTimerViewModel.TaskId);
            }

            return View(addTimerViewModel);
        }


    } // class
} // namespace
