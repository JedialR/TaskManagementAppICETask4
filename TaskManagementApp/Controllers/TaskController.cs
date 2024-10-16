using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagementApp.Controllers
{
    public class TaskController : Controller
    {
        // In-memory task list
        private static List<TaskModel> taskList = new List<TaskModel>();

        // Display all tasks
        public IActionResult Index()
        {
            return View(taskList);
        }

        // Create new task (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Create new task (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                task.Id = taskList.Count + 1; // Simple ID incrementing
                taskList.Add(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // Edit task (GET)
        public IActionResult Edit(int id)
        {
            var task = taskList.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // Edit task (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TaskModel updatedTask)
        {
            if (ModelState.IsValid)
            {
                var task = taskList.FirstOrDefault(t => t.Id == id);
                if (task == null)
                {
                    return NotFound();
                }

                task.Title = updatedTask.Title;
                task.Description = updatedTask.Description;
                task.Deadline = updatedTask.Deadline;

                return RedirectToAction("Index");
            }
            return View(updatedTask);
        }

        // Delete task (GET)
        public IActionResult Delete(int id)
        {
            var task = taskList.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // Delete task (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = taskList.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            taskList.Remove(task);
            return RedirectToAction("Index");
        }
    }
}
