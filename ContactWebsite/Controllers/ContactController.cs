using ContactWebsite.Models;
using ContactWebsite.Tools;
using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactWebsite.Controllers
{
    public class ContactController : Controller
    {
        private IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll().Select(c => c.ToWeb()));
        }

        public IActionResult Detail(int Id)
        {
            return View(_service.GetById(Id).ToWeb());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact c)
        {
            if (!ModelState.IsValid)
            {
                return View(c);
            }

            _service.Insert(c.ToDAL());
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            return View(_service.GetById(Id).ToWeb());
        }

        [HttpPost]
        public IActionResult Edit(Contact c)
        {
            if (!ModelState.IsValid)
            {
                return View(c);
            }

            _service.Update(c.ToDAL());
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            _service.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
