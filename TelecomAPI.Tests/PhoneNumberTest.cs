using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelecomAPI.Models;

namespace TelecomAPI.Tests
{
    [TestClass]
    public class PhoneNumberTest
    {
        [TestMethod]
        public void TestActivateNumber()
        {
            // arrange
            int customerID = 1;
            string number = "01234567890";

            // act
            Customer customer = new Customer(customerID);
            customer.ActivateNumber(number);

            // assert
            Assert.IsTrue(customer.TelephoneNumbers.Exists(telNumber => telNumber.TelephoneNumber == number && telNumber.Active));

        }

    }
}
