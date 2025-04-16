using KieuGiaConstruction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KieuGiaConstruction.Controllers
{
    public class ProjectsController : Controller
    {
        private static List<Project> projects = new List<Project>
        {
            new Project { Id = 1, ProjectName = "Dự án A", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), iStatus = "Đang tiến hành" },
            new Project { Id = 2, ProjectName = "Dự án B", StartDate = DateTime.Now.AddDays(-10), EndDate = DateTime.Now.AddDays(20), iStatus = "Đang tiến hành" },
        };

        public IActionResult Index()
        {
            return View(projects);
        }
        // POST: Projects/Create
        [HttpPost]
        public IActionResult Create(Project project)
        {
            project.Id = projects.Count > 0 ? projects.Max(p => p.Id) + 1 : 1; // Tạo ID mới
            projects.Add(project);
            return RedirectToAction("Index");
        }
        // GET: Projects/Edit/5
        public IActionResult Edit(int id)
        {
            var project = projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        public IActionResult Edit(Project updatedProject)
        {
            var project = projects.FirstOrDefault(p => p.Id == updatedProject.Id);
            if (project == null)
            {
                return NotFound();
            }

            project.ProjectName = updatedProject.ProjectName;
            project.StartDate = updatedProject.StartDate;
            project.EndDate = updatedProject.EndDate;
            project.iStatus = updatedProject.iStatus;

            return RedirectToAction("Index");
        }

        // POST: Projects/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var project = projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            projects.Remove(project);
            return RedirectToAction("Index");
        }


    }
}
