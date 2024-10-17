using System.ComponentModel.DataAnnotations;

namespace CIS236_Contact_Manager.Models

{
    public class Contact
    {
		public int ContactId { get; set; }  // Primary key
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter a Category.")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public string Organization { get; set; }
        public DateTime DateAdded { get; set; }


        public string Slug => FullName()?.Replace(' ', '-').ToLower() + '-' + ContactId.ToString();

        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

    }
}
