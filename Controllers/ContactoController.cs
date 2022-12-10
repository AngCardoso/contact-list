using contact_list.Data;
using contact_list.Models;
using contact_list.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contact_list.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactoController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
           List<ContactModel> Contacts = _contactRepository.FindAll();
            return View(Contacts);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }

        public IActionResult ConfirmDelete(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            _contactRepository.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            _contactRepository.Add(contact);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            _contactRepository.Update(contact);
            return RedirectToAction("Index");
        }
    }
}

