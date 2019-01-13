using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelecomAPI.Models;

namespace TelecomAPI.Tests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void TestGetAllCustomers()
        {
            //Arrange
            List<Customer> customers = new List<Customer>();

            //Act
            customers = Customer.GetAllCustomers();

            //Assert
            Assert.IsNotNull(customers, "Found some customers");
        }

        [TestMethod]
        public void TestGetCustomer()
        {
            // Arrange
            Customer customer;
            int id =1;
            // Act
            customer = Customer.GetCustomer(id);

            // Assert
            Assert.IsNotNull(customer, string.Format("{0} found", id));

        }
    }
}
