using CodingEventsDemo.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

    } // class
} // namespace
