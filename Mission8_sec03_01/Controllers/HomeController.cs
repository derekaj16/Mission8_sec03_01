using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public HomeController(ILogger<HomeController> logger, TaskDatabaseContext taskContext)
        {
            _logger = logger;
            _taskContext = taskContext;
        }

        public IActionResult Index()
        {
            var tasks = _taskContext.Tasks.Include(x => x.Category).ToList();
            return View("Quadrants", tasks);
        }

        [HttpGet]
        public IActionResult TasksForm()
        {
            ViewBag.Categories = _taskContext.Categories.ToList();
            return View(new TaskModel());
        }
        [HttpPost]
        public IActionResult TasksForm(TaskModel t)
        {
            if (ModelState.IsValid)
            {
                _taskContext.Add(t);
                _taskContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = _taskContext.Categories.ToList();
                return View(t);
            }
        }

        [HttpGet]
        public IActionResult EditTask(int taskid)
        {
            ViewBag.Categories = _taskContext.Categories.ToList();
            var task = _taskContext.Tasks.Single(m => m.TaskID == taskid);

            return View("TasksForm", task);
        }
        [HttpPost]
        public IActionResult EditTask(TaskModel t)
        {
            // Check form validity before allowing changes
            if (ModelState.IsValid)
            {
                _taskContext.Update(t);
                _taskContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else // Redirect if invalid
            {
                ViewBag.Categories = _taskContext.Categories.ToList();
                return View(t);
            }
        }

        [HttpGet]
        public IActionResult DeleteTask(int taskid)
        {
            var task = _taskContext.Tasks.Single(t => t.TaskID == taskid);
            _taskContext.Tasks.Remove(task);
            _taskContext.SaveChanges();

            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public IActionResult DeleteTask(TaskModel task)
        //{
        //    _taskContext.Tasks.Remove(task);
        //    _taskContext.SaveChanges();

        //    return RedirectToAction("ViewTasks");
        //}

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
