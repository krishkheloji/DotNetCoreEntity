using DecBatch2025MVCCoreProject.Data;
using DecBatch2025MVCCoreProject.DTO;
using DecBatch2025MVCCoreProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DecBatch2025MVCCoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPController : ControllerBase
    {
        ApplicationDbContext db;
        public SPController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        [Route("AddManager")]
        public IActionResult AddManager(ManagerDTO m)
        {
            var man = new Manager()
            {
                mname=m.mname
            };

            db.Database.ExecuteSqlRaw($"exec AddManagerProc '{man.mname}'");

            return Ok(new { message = "Manager Added Success" });
        }

        [HttpGet]
        [Route("FetchManager")]
        public IActionResult Fetchmanagers()
        {
            var dt=db.mang.FromSqlRaw("exec FetchManagerProc").ToList();
            return Ok(dt);
        }
    }
}
