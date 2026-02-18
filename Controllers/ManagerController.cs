using DecBatch2025MVCCoreProject.Data;
using DecBatch2025MVCCoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DecBatch2025MVCCoreProject.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext db;
        public ManagerController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data=db.mang.ToList();
            return View(data);
        }

        public IActionResult AddManager()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddManager(Manager m)
        {
            db.mang.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
