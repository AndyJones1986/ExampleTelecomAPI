using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecomAPI.Models
{
    public class PhoneNumber
    {
        #region Private Properties

        private bool _active { get; set; }

        #endregion


        #region Public Properties
        public int ID { get; set; }
        public string TelephoneNumber { get; set; }
        public bool Active { get { return _active; } }

        #endregion
        #region Constructors

        public PhoneNumber(string telephoneNumber)
        {
            //this.ID = id; TODO: Create new instance in storage and retrieve pk as ID
            this.TelephoneNumber = telephoneNumber;
            _active = true;

        }

        public PhoneNumber(int id, string telephoneNumber)
        {
            this.ID = id;
            this.TelephoneNumber = telephoneNumber;
            _active = true;
        }

        #endregion

        #region PublicMethods

        public void Activate()
        {
            this._active = true;
        }

        public void Deactivate()
        {
            this._active = false;
        }

        #endregion
    }
}