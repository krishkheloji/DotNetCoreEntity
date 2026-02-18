using DecBatch2025MVCCoreProject.Data;
using DecBatch2025MVCCoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DecBatch2025MVCCoreProject.Controllers
{
    public class AjaxController : Controller
    {
        ApplicationDbContext db;
    
        public AjaxController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FetchManagers()
        {
            var data = db.mang.ToList();
            return Json(data);
        }

        public IActionResult SearchManagers(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return FetchManagers();
            }
            else
            {
                var d = db.mang.Where(x => x.mname.Contains(name)).ToList();
                return Json(d);    
            }

        }

        public IActionResult AddManager(Manager m)
        {
            db.mang.Add(m);
            db.SaveChanges();
            return Json("");
        }
    }
}
