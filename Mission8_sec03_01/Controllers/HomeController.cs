using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission8_sec03_01.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_sec03_01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TaskDatabaseContext _taskContext { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewTasks()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _taskContext.Categories.ToList();
            return View(new TaskModel());
        }
        [HttpPost]
        public IActionResult AddTask(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                _taskContext.Add(task);
                _taskContext.SaveChanges();

                return RedirectToAction("ViewTasks");
            }
            else
            {
                ViewBag.Categories = _taskContext.Categories.ToList();

                return View(task);
            }
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = _taskContext.categories.ToList();
            var task = _taskContext.movies.Single(m => m.TaskID == taskid);

            return View("AddTask", task);
        }
        [HttpPost]
        public IActionResult Edit(TaskModel task)
        {
            // Check form validity before allowing changes
            if (ModelState.IsValid)
            {
                _taskContext.Update(task);
                _taskContext.SaveChanges();

                return RedirectToAction("MovieList");
            }
            else // Redirect if invalid
            {
                ViewBag.Categories = _taskContext.Categories.ToList();
                return View(task);
            }
        }

        [HttpGet]
        public IActionResult DeleteTask(int taskid)
        {
            var task = _taskContext.tasks.Single(t => t.TaskId == taskid);
            return View(task);
        }
        [HttpPost]
        public IActionResult DeleteTask(Task task)
        {
            _taskContext.tasks.Remove(task);
            _taskContext.SaveChanges();

            return RedirectToAction("ViewTasks");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
