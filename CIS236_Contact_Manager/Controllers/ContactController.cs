using System.Diagnostics;
using CIS236_Contact_Manager.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIS236_Contact_Manager.Controllers
{
	public class ContactController : Controller
	{
		private ContactContext context { get; set; }

		public ContactController(ContactContext ctx)
		{
			context = ctx;
		}

        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = context.Contacts.Find(id);
            return View(contact);
        }

    }
}
