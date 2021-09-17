using ContactWebsite.Models;
using ContactWebsite.Tools;
using DAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactWebsite.Controllers
{
    public class UserController : Controller
    {
        private IUserService _service;


        public UserController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            User currentUser = _service.Login(form.Email, form.Password).ToWEB();
            HttpContext.Session.SetUser(currentUser);

            return RedirectToAction("Index");
        }

        [AuthRequired]
        public IActionResult ListUser()
        {
            return View(_service.GetAll(HttpContext.Session.GetUser().Token).Select(u => u.ToWEB()));
        }

        public IActionResult Index()
        {
            return View();
        }

        [AuthRequired]
        public IActionResult Logout()
        {
            HttpContext.Session.Disconnect();
            return RedirectToAction("Index");
        }

        [AdminRequired]
        public IActionResult Delete(int id)
        {
            _service.Delete(id, HttpContext.Session.GetUser().Token);
            return RedirectToAction("ListUser");
        }


    }
}
