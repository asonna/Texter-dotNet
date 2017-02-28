using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Texter.Models;

namespace Texter.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetMessages()
        {
            var allMessages = Message.GetMessages();
            return View(allMessages);
        }

        //public IActionResult SendMessage()
        //{
        //    return View();
        //}
        //[ActionName("SendMessage")]
        public IActionResult SendMessage(int id)
        {
            var thisContact = db.Contacts.FirstOrDefault(c => c.ContactId == id);
            ViewBag.Contact = thisContact;
            return View();
        }


        [HttpPost]
        public IActionResult SendMessage(Message newMessage)
        {
            newMessage.Send();
            return RedirectToAction("Index");
        }

        public IActionResult  CreateContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContact(Contact newContact)
        {
            db.Contacts.Add(newContact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ContactList()
        {
            //ViewBag.Contacts = db.Contacts.ToList();
            return View(db.Contacts.ToList());
        }
    }
}
