using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TelecomAPI.Models
{
    public class Response<T>
    {
        public bool Successful { get; set; }
        public DateTime ResponseTime { get { return DateTime.Now; } }
        public DateTime ResponseTimeUTC { get { return DateTime.UtcNow; } }
        public T ReturnData { get; set; }
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Generic successful constructor
        /// </summary>
        /// <param name="data">Data set to be returned</param>
        public Response(T data)
        {
            Successful = true;
            ReturnData = data;
        }

        /// <summary>
        /// Unsuccessful constructor
        /// </summary>
        public Response(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.Successful = false;
        }

    }
}