using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CIS236_Contact_Manager.Models
{
	public class ContactList
	{
		// EF Core will configure the database to generate this value
		public int MovieId { get; set; }

		[Required(ErrorMessage = "Please enter a first name.")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Please enter a last name.")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter a year.")]
		[Range(1889, 2999, ErrorMessage = "Year must be after 1889.")]
		public int? Year { get; set; }

		[Required(ErrorMessage = "Please enter a rating.")]
		[Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
		public int? Rating {get; set;}
	}
}