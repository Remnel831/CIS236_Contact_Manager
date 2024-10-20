using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CIS236_Contact_Manager.Models

{
    public class Contact
    {
		public int ContactId { get; set; }  // Primary key
		[Required(ErrorMessage = "First name is required")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Last name is required")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Phone Number is required")]
		[RegularExpression(@"^(?:\D*\d){10}\D*$", ErrorMessage = "Phone number must be 10 digits")]
		public string PhoneNumber { get; set; }


		[Required(ErrorMessage = "Email is required")]
		public string EmailAddress { get; set; }

		[Range(1, 4, ErrorMessage = "Category must be selected.")]
		public int CategoryId { get; set; }

        public Category? Category { get; set; }

        
        public string? Organization { get; set; }
        public DateTime DateAdded { get; set; }

        //read only slug
        public string Slug => FullName()?.Replace(' ', '-').ToLower();

        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

    }
}
