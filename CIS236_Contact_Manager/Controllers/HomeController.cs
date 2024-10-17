using System.Diagnostics;
using CIS236_Contact_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CIS236_Contact_Manager.Controllers
{
	public class HomeController : Controller
	{
	
		private ContactContext context { get; set; }

		public HomeController(ContactContext ctx)
		{
			context = ctx;
		}


		public IActionResult Index()
		{
			var contacts = context.Contacts.Include(m => m.Category).OrderBy(m => m.LastName).ToList();
			return View(contacts);
		}

	}
}
