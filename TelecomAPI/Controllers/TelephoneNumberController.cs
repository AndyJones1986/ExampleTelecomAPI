using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace TelecomAPI.Controllers
{
    public class TelephoneNumberController : ApiController
    {
        /// <summary>
        /// 
        /// API Description:
        ///  Activate new number against customer
        ///  
        /// Endpoint:
        /// GET example.org/api/TelephoneNumber/Activate/{customerid}/{number}
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="number"></param>
        /// <returns>repsonse object with success/fail, if successful will return customer object.</returns>
        [HttpGet]
        [Route("api/TelephoneNumber/{customerId}/{number}")]
        public string Activate(int customerId, string number)
        {
            try
            {

                Models.Customer customer = new Models.Customer(customerId);

                if (customer != null && ValidateNumber(number))
                {
                    customer.ActivateNumber(number);
                    return JsonConvert.SerializeObject(new Models.Response<Models.Customer>(customer));
                }
                else
                {
                    //todo: add error logging here
                    return JsonConvert.SerializeObject(new Models.Response<Models.Customer>("INVALID NUMBER OR CUSTOMER"));
                }

            }
            catch (Exception ex)
            {
                //todo: add error logging here
                return JsonConvert.SerializeObject(new Models.Response<Models.Customer>("Unknown"));
            }
        }

        /// <summary>
        /// Little validation method, i suspect this would be expanded within production code
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool ValidateNumber(string number)
        {
            if (!string.IsNullOrWhiteSpace(number) && number.Length > 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
