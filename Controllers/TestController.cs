using DecBatch2025MVCCoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DecBatch2025MVCCoreProject.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var a = new Auth()
            {
                Email="abc@gmail.com",
                Password="123"
            };
            
            return View();
        }

        public IActionResult AuthData()
        {
            var u = new List<Auth>()
            {
                new Auth(){Email="abc@gmail.com",Password="123"},
                new Auth(){Email="xyz@gmail.com",Password="1232"},
                new Auth(){Email="pqr@gmail.com",Password="1233"}
            };
            return View(u);
        }

        public IActionResult Login()
        {
            var u = new List<User>()
            {
                new User(){Name="abc@gmail.com",Contact="123"},
                new User(){Name="xyz@gmail.com",Contact="1232"},
                new User(){Name="pqr@gmail.com",Contact="1233"}
            };

            var au = new AuthUser()
            {
                auth =new Auth(),
                user=u
            };
            return View(au);
        }
        [HttpPost]
        public IActionResult Login(AuthUser d)
        {
            var u = new List<User>()
            {
                new User(){Name="abc@gmail.com",Contact="123"},
                new User(){Name="xyz@gmail.com",Contact="1232"},
                new User(){Name="pqr@gmail.com",Contact="1233"}
            };

            var au = new AuthUser()
            {
                auth = new Auth(),
                user = u
            };

            if(ModelState.IsValid)
            {
                if (d.auth.Email.Equals("abc@gmail.com") && d.auth.Password.Equals("123"))
                {
                    return RedirectToAction("AuthData");
                }
                else
                {
                    ViewBag.msg = "Invalid";
                    return View(au);
                }
            }
            else
            {
                return View(au);
            }
            
                
        }

       
    }
}
