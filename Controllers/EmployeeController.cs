
using AutoMapper;
using DecBatch2025MVCCoreProject.Data;
using DecBatch2025MVCCoreProject.DTO;
using DecBatch2025MVCCoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DecBatch2025MVCCoreProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext db;
        IMapper mapper;
        
        public EmployeeController(ApplicationDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = db.employees.Include(x => x.managers).ToList();
            //var data = db.employees.Include(x => x.managers)
            //        .Select(e => new EmpDTO
            //        {
            //            eid = e.eid,
            //            ename = e.ename,
            //            esalary = e.esalary,
            //            mname = e.managers.mname != null ? e.managers.mname : "No"
            //        }).ToList();

            var ndata=mapper.Map<List<EmpDTO>>(data);
            return View(ndata);
        }

        public IActionResult AddEmp()
        {
            var managers=db.mang.ToList();
            ViewBag.manager = new SelectList(managers,"mid","mname");
            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(EmpDTOAdd e)
        {
            //var em = new Emp()
            //{
            //    ename=e.ename,
            //    esalary=e.esalary,
            //    mid=e.mid
            //};

            var dt=mapper.Map<Emp>(e);

            db.employees.Add(dt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
