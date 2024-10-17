using System.Diagnostics;
using CIS236_Contact_Manager.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIS236_Contact_Manager.Controllers
{
	public class ContactController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public ContactController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		private ContactContext context { get; set; }

		public ContactController(ContactContext ctx)
		{
			context = ctx;
		}


		public IActionResult Index()
		{
			var contacts = context.Contacts.OrderBy(m => m.FirstName).ToList();
			return View(contacts);
		}

	}
}
