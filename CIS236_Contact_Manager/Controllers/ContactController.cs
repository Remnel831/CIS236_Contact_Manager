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
			ViewBag.Category = context.Categories.OrderBy(c => c.Name).ToList();
			return View(contact);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var contact = context.Contacts.Find(id);
			return View(contact);
		}

		[HttpPost]
		public IActionResult Delete(Contact contact)
		{
			context.Contacts.Remove(contact);
			context.SaveChanges();
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";
			ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
			var contact = context.Contacts.Find(id);
			return View(contact);
		}

		[HttpPost]
		public IActionResult Edit(Contact contact)
		{
			if (ModelState.IsValid)
			{
				if (contact.ContactId == 0)
				{
					context.Contacts.Add(contact);
				}

				else
				{
					context.Contacts.Update(contact);

				}

				context.SaveChanges();
				return View("Index");
			}

			else
			{
				ViewBag.Action = (contact.ContactId == 0) ? "Add" : "Edit";
				ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
				return View(contact);
			}
		}
	}
}

