using AutoMapper;
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
    public class EmpHandlerController : ControllerBase
    {
        ApplicationDbContext db;
        IMapper mapper;
        public EmpHandlerController(ApplicationDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetEmp()
        {
            var dt=await db.employees.Include(x=>x.managers).ToListAsync();
            var res=mapper.Map<List<EmpDTO>>(dt);
            return Ok(res);
        }

        [HttpGet]
        [Route("getManager")]
        public IActionResult FetchAllManagers()
        {
            var data = db.mang.ToList();
            var res = mapper.Map<List<ManagerDTO>>(data);
            return Ok(res);
        }

        [HttpDelete]
        [Route("DelEmp/{id}")]
        public IActionResult DeleteEmpById(int id)
        {
            var data=db.employees.Find(id);
            db.employees.Remove(data);
            db.SaveChanges();
            return Ok(new { message = "Emp Deleted Successfull!!" });
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult getEmpById(int id)
        {
            var dt=db.employees.Find(id);
            return Ok(dt);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateEmp(EmpDTOAdd dto)
        {
            var dt = mapper.Map<Emp>(dto);
            db.employees.Update(dt);
            await db.SaveChangesAsync();
            return Ok(new { message = "Emp Updated Success" });
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddEmp(EmpDTOAdd dto)
        {
            var dt=mapper.Map<Emp>(dto);
            await db.employees.AddAsync(dt);
            await db.SaveChangesAsync();
            return Ok(new { message = "Emp Added Success" });
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult doLogin(AccountDTO account)
        {
            var User=db.acc.Where(x => x.email.Equals(account.email)).FirstOrDefault();
            if(User!=null)
            {
                var pass = User.password.Equals(account.password);
                if(pass)
                {
                    return Ok(new { urole = User.role,accuser=User });
                }
                else
                {
                    return Ok(new { message = "Invalid Password" });
                }
            }
            else
            {
                return Ok(new { message = "Invalid Email" });
            }
        }

    }
}
