using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecomAPI.Models
{
    [Serializable()]
    public class Customer
    {
        #region Public Properties
        public int ID { get; set; }
        public string ForeName { get; set; }
        public string Surname { get; set; }

        public List<PhoneNumber> TelephoneNumbers { get; set; }

        #endregion

        #region Constructors
        public Customer(int id)
        {
            this.ID = id;
            // todo: change this to look up customer from storage
            this.ForeName = "Joe";
            this.Surname = "Bloggs";
            TelephoneNumbers = new List<PhoneNumber>();
            TelephoneNumbers.Add(new PhoneNumber(1, "+441234567890"));
        }

        public Customer(string forename, string surname)
        {
            // todo: insert new customer record and fetch PK as ID
            this.ID = 2;
            this.ForeName = forename;
            this.Surname = surname;

            // todo: lookup existing telephone numbers from storage and parse
            TelephoneNumbers = new List<PhoneNumber>();
            TelephoneNumbers.Add(new PhoneNumber(1, "+441234567890"));

        }
        #endregion

        #region Public Methods 

        public void ActivateNumber(string number)
        {
            if (TelephoneNumbers.Any(telNumber => telNumber.TelephoneNumber.Trim() == number.Trim()))
            {
                TelephoneNumbers
                    .Where(telNumber => telNumber.TelephoneNumber.Trim() == number.Trim())
                    .ToList()
                    .ForEach(telNumber => telNumber.Activate());

                //todo: save customer to storage
            }
            else
            {
                // todo: replace the below to use storage to increment pk and store
                int maxID = TelephoneNumbers.Count > 0 ? TelephoneNumbers.Max(telNumber => telNumber.ID) : 0;
                maxID++;
                TelephoneNumbers.Add(new PhoneNumber(maxID, number));
            }
        }



        #endregion

        #region Static Methods
        public static List<Customer> GetAllCustomers()
        {
            List<Customer> returnObject = new List<Customer>();
            returnObject.Add(new Customer(1));
            returnObject.Add(new Customer("Andy", "Jones"));
            returnObject.Where(customer => customer.TelephoneNumbers.Count == 0).ToList().ForEach(customer => customer.ActivateNumber("+449876543210"));
            return returnObject;
        }

        public static Customer GetCustomer(int id)
        {
            List<Customer> customers = GetAllCustomers();

            //todo: something more robust here, for now, let it bomb out if the customer isn't there, try catch will deal with this.
            return customers.Where(customer => customer.ID == id).First();
        }
        #endregion


    }
}