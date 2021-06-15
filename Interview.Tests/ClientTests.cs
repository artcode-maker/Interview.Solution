using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Interview.Models;

namespace Interview.Tests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void CanAssignZeroOrGreaterId()
        {
            // Arrange
            Client client1 = new Client();
            Client client2 = new Client();
            Client client3 = new Client();

            // Act
            client1.ClientId = 0;
            client2.ClientId = 15;
            client3.ClientId = -5;

            // Assert
            Assert.AreEqual(0, client1.ClientId);
            Assert.AreEqual(15, client2.ClientId);
            Assert.AreEqual(0, client3.ClientId);
        }

        [TestMethod]
        public void CanAssignFirstName()
        {
            Client client1 = new Client();
            Client client2 = new Client();
            Client client3 = new Client();
            Client client4 = new Client();

            // Act
            client1.FirstName = new String('1', 2);
            client2.FirstName = new String('1', 12);
            client3.FirstName = new String('1', 20);
            client4.FirstName = new String('1', 25);

            // Assert
            Assert.AreEqual(new String('1', 2), client1.FirstName);
            Assert.AreEqual(new String('1', 12), client2.FirstName);
            Assert.AreEqual(new String('1', 20), client3.FirstName);
            Assert.AreEqual("Invalid Data", client4.FirstName);
        }

        [TestMethod]
        public void CanAssignFamilyName()
        {
            // Arrange
            Client client1 = new Client();
            Client client2 = new Client();
            Client client3 = new Client();
            Client client4 = new Client();

            // Act
            client1.FamilyName = new String('1', 2);
            client2.FamilyName = new String('1', 12);
            client3.FamilyName = new String('1', 20);
            client4.FamilyName = new String('1', 25);

            // Assert
            Assert.AreEqual(new String('1', 2), client1.FamilyName);
            Assert.AreEqual(new String('1', 12), client2.FamilyName);
            Assert.AreEqual(new String('1', 20), client3.FamilyName);
            Assert.AreEqual("Invalid Data", client4.FamilyName);
        }

        [TestMethod]
        public void CanAssignAddress()
        {
            // Arrange
            Client client1 = new Client();
            Client client2 = new Client();
            Client client3 = new Client();
            Client client4 = new Client();

            // Act
            client1.Address = new String('1', 10);
            client2.Address = new String('1', 15);
            client3.Address = new String('1', 30);
            client4.Address = new String('1', 31);

            // Assert
            Assert.AreEqual(new String('1', 10), client1.Address);
            Assert.AreEqual(new String('1', 15), client2.Address);
            Assert.AreEqual(new String('1', 30), client3.Address);
            Assert.AreEqual("Invalid Data", client4.Address);
        }

        [TestMethod]
        public void CanAssignAppropriateEmail()
        {
            // Arrange
            Client client1 = new Client();
            Client client2 = new Client();
            Client client3 = new Client();
            Client client4 = new Client();

            // Act
            client1.Email = String.Format("hello@mail.com");
            client2.Email = String.Format("hello@mail");
            client3.Email = String.Format("hellomail.com");
            client4.Email = String.Format("@mail.com");

            // Assert
            Assert.AreEqual(String.Format("hello@mail.com"), client1.Email);
            Assert.AreEqual(String.Format("Invalid Data"), client2.Email);
            Assert.AreEqual(String.Format("Invalid Data"), client3.Email);
            Assert.AreEqual(String.Format("Invalid Data"), client4.Email);
        }

        [TestMethod]
        public void CanAssignIssue()
        {
            // Arrange
            Client client1 = new Client();
            Client client2 = new Client();
            Client client3 = new Client();
            Client client4 = new Client();

            // Act
            client1.Issue = new String('1', 10);
            client2.Issue = new String('1', 50);
            client3.Issue = new String('1', 100);
            client4.Issue = new String('1', 5);

            // Assert
            Assert.AreEqual(new String('1', 10), client1.Issue);
            Assert.AreEqual(new String('1', 50), client2.Issue);
            Assert.AreEqual(new String('1', 100), client3.Issue);
            Assert.AreEqual("Invalid Data", client4.Issue);
        }
    }
}
