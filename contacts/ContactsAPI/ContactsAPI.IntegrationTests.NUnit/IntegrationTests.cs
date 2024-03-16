// IntegrationTests.cs

using NUnit.Framework;
using ContactsConsoleAPI.Business;
using ContactsConsoleAPI.Business.Contracts;
using ContactsConsoleAPI.Data.Models;
using ContactsConsoleAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsConsoleAPI.IntegrationTests.NUnit
{
    public class IntegrationTests
    {
        private TestContactDbContext dbContext;
        private IContactManager contactManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestContactDbContext();
            this.contactManager = new ContactManager(new ContactRepository(this.dbContext));
        }

        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }

        [Test]
        public async Task AddContactAsync_ShouldAddNewContact()
        {
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH",
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            await contactManager.AddAsync(newContact);

            var dbContact = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);

            Assert.NotNull(dbContact);
            Assert.AreEqual(newContact.FirstName, dbContact.FirstName);
            Assert.AreEqual(newContact.LastName, dbContact.LastName);
            Assert.AreEqual(newContact.Phone, dbContact.Phone);
            Assert.AreEqual(newContact.Email, dbContact.Email);
            Assert.AreEqual(newContact.Address, dbContact.Address);
            Assert.AreEqual(newContact.Contact_ULID, dbContact.Contact_ULID);
        }

        [Test]
        public async Task AddContactAsync_TryToAddContactWithInvalidCredentials_ShouldThrowException()
        {
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH",
                Email = "invalid_Mail", //invalid email
                Gender = "Male",
                Phone = "0889933779"
            };

            var ex = Assert.ThrowsAsync<ValidationException>(async () => await contactManager.AddAsync(newContact));
            var actual = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);

            Assert.IsNull(actual);
            Assert.That(ex?.Message, Is.EqualTo("Invalid contact!"));
        }

        [Test]
        public async Task DeleteContactAsync_WithValidULID_ShouldRemoveContactFromDb()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH",
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };
            await contactManager.AddAsync(newContact);

            // Act
            await contactManager.DeleteAsync(newContact.Contact_ULID);
            var dbContact = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);

            // Assert
            Assert.Null(dbContact);
        }

        [Test]
        public async Task DeleteContactAsync_TryToDeleteWithNullOrWhiteSpaceULID_ShouldThrowException()
        {
            // Arrange

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await contactManager.DeleteAsync(null));

            // Assert
            Assert.That(ex?.Message, Is.EqualTo("ULID cannot be empty."));
        }

        [Test]
        public async Task GetAllAsync_WhenContactsExist_ShouldReturnAllContacts()
        {
            // Arrange
            var newContact1 = new Contact()
            {
                FirstName = "TestFirstName1",
                LastName = "TestLastName1",
                Address = "Anything for testing address1",
                Contact_ULID = "1ABC23456HA",
                Email = "test1@gmail.com",
                Gender = "Male",
                Phone = "0889933770"
            };

            var newContact2 = new Contact()
            {
                FirstName = "TestFirstName2",
                LastName = "TestLastName2",
                Address = "Anything for testing address2",
                Contact_ULID = "1ABC23456HB",
                Email = "test2@gmail.com",
                Gender = "Female",
                Phone = "0889933771"
            };

            await contactManager.AddAsync(newContact1);
            await contactManager.AddAsync(newContact2);

            // Act
            var allContacts = await contactManager.GetAllAsync();

            // Assert
            Assert.NotNull(allContacts);
            Assert.AreEqual(2, allContacts.Count());
            Assert.IsTrue(allContacts.Any(c => c.FirstName == newContact1.FirstName));
            Assert.IsTrue(allContacts.Any(c => c.FirstName == newContact2.FirstName));
        }

        [Test]
        public async Task GetAllAsync_WhenNoContactsExist_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(async () => await contactManager.GetAllAsync());

            // Assert
            Assert.That(ex?.Message, Is.EqualTo("No contact found."));
        }

        [Test]
        public async Task SearchByFirstNameAsync_WithExistingFirstName_ShouldReturnMatchingContacts()
        {
            // Arrange
            var newContact1 = new Contact()
            {
                FirstName = "TestFirstName1",
                LastName = "TestLastName1",
                Address = "Anything for testing address1",
                Contact_ULID = "1ABC23456HA",
                Email = "test1@gmail.com",
                Gender = "Male",
                Phone = "0889933770"
            };

            var newContact2 = new Contact()
            {
                FirstName = "TestFirstName2",
                LastName = "TestLastName2",
                Address = "Anything for testing address2",
                Contact_ULID = "1ABC23456HB",
                Email = "test2@gmail.com",
                Gender = "Female",
                Phone = "0889933771"
            };

            await contactManager.AddAsync(newContact1);
            await contactManager.AddAsync(newContact2);

            // Act
            var searchResults = await contactManager.SearchByFirstNameAsync("TestFirstName1");

            // Assert
            Assert.NotNull(searchResults);
            Assert.AreEqual(1, searchResults.Count());
            Assert.IsTrue(searchResults.Any(c => c.FirstName == newContact1.FirstName));
        }

        [Test]
        public async Task SearchByFirstNameAsync_WithNonExistingFirstName_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(async () => await contactManager.SearchByFirstNameAsync("NonExistingFirstName"));

            // Assert
            Assert.That(ex?.Message, Is.EqualTo("No contact found with the given first name."));
        }

        [Test]
        public async Task SearchByLastNameAsync_WithExistingLastName_ShouldReturnMatchingContacts()
        {
            // Arrange
            var newContact1 = new Contact()
            {
                FirstName = "TestFirstName1",
                LastName = "TestLastName1",
                Address = "Anything for testing address1",
                Contact_ULID = "1ABC23456HA",
                Email = "test1@gmail.com",
                Gender = "Male",
                Phone = "0889933770"
            };

            var newContact2 = new Contact()
            {
                FirstName = "TestFirstName2",
                LastName = "TestLastName2",
                Address = "Anything for testing address2",
                Contact_ULID = "1ABC23456HB",
                Email = "test2@gmail.com",
                Gender = "Female",
                Phone = "0889933771"
            };

            await contactManager.AddAsync(newContact1);
            await contactManager.AddAsync(newContact2);

            // Act
            var searchResults = await contactManager.SearchByLastNameAsync("TestLastName1");

            // Assert
            Assert.NotNull(searchResults);
            Assert.AreEqual(1, searchResults.Count());
            Assert.IsTrue(searchResults.Any(c => c.LastName == newContact1.LastName));
        }

        [Test]
        public async Task SearchByLastNameAsync_WithNonExistingLastName_ShouldThrowException()
        {
            // Arrange

            // Act
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(async () => await contactManager.SearchByLastNameAsync("NonExistingLastName"));

            // Assert
            Assert.That(ex?.Message, Is.EqualTo("No contact found with the given last name."));
        }



        [Test]
        public async Task GetSpecificAsync_WithValidULID_ShouldReturnContact()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH",
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };
            await contactManager.AddAsync(newContact);

            // Act
            var specificContact = await contactManager.GetSpecificAsync(newContact.Contact_ULID);

            // Assert
            Assert.NotNull(specificContact);
            Assert.AreEqual(newContact.FirstName, specificContact.FirstName);
            Assert.AreEqual(newContact.LastName, specificContact.LastName);
            Assert.AreEqual(newContact.Phone, specificContact.Phone);
            Assert.AreEqual(newContact.Email, specificContact.Email);
            Assert.AreEqual(newContact.Address, specificContact.Address);
            Assert.AreEqual(newContact.Contact_ULID, specificContact.Contact_ULID);
        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidULID_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(async () => await contactManager.GetSpecificAsync("InvalidULID"));

            // Assert
            Assert.That(ex?.Message, Is.EqualTo("No contact found with ULID: InvalidULID"));
        }

        [Test]
        public async Task UpdateAsync_WithValidContact_ShouldUpdateContact()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "UpdatedFirstName",
                LastName = "UpdatedLastName",
                Address = "Updated address",
                Contact_ULID = "1ABC23456HH",
                Email = "updated@gmail.com",
                Gender = "Male",
                Phone = "0999888777"
            };
            await contactManager.AddAsync(newContact);

            var updatedContact = new Contact()
            {
                FirstName = "UpdatedFirstName",
                LastName = "UpdatedLastName",
                Address = "Updated address",
                Contact_ULID = "1ABC23456HH",
                Email = "updated@gmail.com",
                Gender = "Female",
                Phone = "0999888777"
            };

            // Act
            await contactManager.UpdateAsync(updatedContact);

            var dbContact = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);

            // Assert
            Assert.NotNull(dbContact);
            Assert.AreEqual(updatedContact.FirstName, dbContact.FirstName);
            Assert.AreEqual(updatedContact.LastName, dbContact.LastName);
            Assert.AreEqual(updatedContact.Phone, dbContact.Phone);
            Assert.AreEqual(updatedContact.Email, dbContact.Email);
            Assert.AreEqual(updatedContact.Address, dbContact.Address);
            Assert.AreEqual(updatedContact.Contact_ULID, dbContact.Contact_ULID);
        }

        [Test]
        public async Task UpdateAsync_WithInvalidContact_ShouldThrowValidationException()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH",
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };
            await contactManager.AddAsync(newContact);

            var updatedContact = new Contact()
            {
                FirstName = "UpdatedFirstName",
                LastName = "UpdatedLastName",
                Address = "Updated address",
                Contact_ULID = "1ABC23456HH",
                Email = "invalid_email", // Invalid email
                Gender = "Female",
                Phone = "0999888777"
            };

            // Act
            var ex = Assert.ThrowsAsync<ValidationException>(async () => await contactManager.UpdateAsync(updatedContact));

            // Assert
            Assert.That(ex?.Message, Is.EqualTo("Invalid contact!"));
        }
    }
}
