using DecBatch2025MVCCoreProject.Data;
using DecBatch2025MVCCoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DecBatch2025MVCCoreProject.Controllers
{
    public class StudentsController : Controller
    {
        ApplicationDbContext db;
        IWebHostEnvironment env;
        public StudentsController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        public IActionResult Index()
        {
            var data=db.stud.ToList();
            return View(data);
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(StudentView sv)
        {
            string path = env.WebRootPath; //wwwroot folder
            string filename = "Content/Images/" + sv.sprofile.FileName;
            string fullpath = Path.Combine(path, filename);
            UploadFile(sv.sprofile, fullpath);
            var st = new Student()
            {
                sname=sv.sname,
                scourse=sv.scourse,
                sprofile=filename
            };
            db.stud.Add(st);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void UploadFile(IFormFile file,string fullpath)
        {
            FileStream stream = new FileStream(fullpath,FileMode.Create);
            file.CopyTo(stream);
        }
    }
}
