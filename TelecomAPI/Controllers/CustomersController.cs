using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace TelecomAPI.Controllers
{
    public class CustomersController : ApiController
    {
        /// <summary>
        /// 
        ///  API Description:
        ///  Retrieve all customers
        ///  
        /// Endpoint :
        /// GET example.org/api/Customers/Get
        /// 
        /// </summary>
        /// <returns>Response object containing success / fail and all customers</returns>
        public string Get()
        {
            try
            {
                return JsonConvert.SerializeObject(new Models.Response<List<Models.Customer>>(Models.Customer.GetAllCustomers()));
            }
            catch (Exception ex)
            {
                //todo: add error logging here
                return JsonConvert.SerializeObject(new Models.Response<List<Models.Customer>>("Unknown"));
            }
        }

        /// <summary>
        /// 
        ///  API Description:
        ///  Retrieve customer id
        ///  
        /// Endpoint:
        /// GET example.org/api/Customers/Get/{ID} (e.g. 1)
        /// 
        /// </summary>
        /// <returns>Response object containing success / fail and requested customer</returns>
        public string Get(int id)
        {
            try
            {
                return JsonConvert.SerializeObject(new Models.Response<Models.Customer>(Models.Customer.GetCustomer(id)));
            }
            catch (Exception ex)
            {
                //todo: add error logging here
                return JsonConvert.SerializeObject(new Models.Response<Models.Customer>("Unknown"));
            }
        }
    }
}
