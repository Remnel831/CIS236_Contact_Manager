using Microsoft.EntityFrameworkCore;
namespace CIS236_Contact_Manager.Models

{
	public class ContactContext : DbContext
	
	{
		public ContactContext(DbContextOptions<ContactContext> options)
		: base(options)
		{ }
		public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Category>().HasData(
                 new Category { CategoryId = 1, Name = "Family" },
                 new Category { CategoryId = 2, Name = "Friend" },
                 new Category { CategoryId = 3, Name = "Work" },
				 new Category { CategoryId = 4, Name = "None" }
			 );


            modelBuilder.Entity<Contact>().HasData(
				new Contact
				{
					ContactId = 1,
					FirstName = "Adam",
					LastName = "Last",
					PhoneNumber = "555-123-3212",
					EmailAddress = "Adam.Last@aol.com",
					CategoryId = 1,
					Organization = "Garden of Eden",
					DateAdded = DateTime.UtcNow.AddDays(-1)
				},
				new Contact
				{
					ContactId = 2,
					FirstName = "Eve",
					LastName = "Last",
					PhoneNumber = "555-321-3212",
					EmailAddress = "Eve.Last@aol.com",
					CategoryId = 1,
					Organization = "Garden of Eden",
					DateAdded = DateTime.UtcNow.AddDays(-2)
				},
				new Contact
				{
					ContactId = 3,
					FirstName = "Draco",
					LastName = "Light",
					PhoneNumber = "555-123-3212",
					EmailAddress = "Draco.Light@ole.com",
					CategoryId = 3,
					Organization = "Top LLC",
					DateAdded = DateTime.UtcNow.AddDays(-3)
				}

			);
		}
	}
}