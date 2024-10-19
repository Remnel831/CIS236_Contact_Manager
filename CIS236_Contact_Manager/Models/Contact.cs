using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CIS236_Contact_Manager.Models

{
    public class Contact
    {
		public int ContactId { get; set; }  // Primary key
		public string FirstName { get; set; }
        public string LastName { get; set; }

		[Required(ErrorMessage = "Phone number is required")]
		[RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
		public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter a Category.")]   
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        
        public string? Organization { get; set; }
        public DateTime DateAdded { get; set; }


        public string Slug => FullName()?.Replace(' ', '-').ToLower();

        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

    }
}
