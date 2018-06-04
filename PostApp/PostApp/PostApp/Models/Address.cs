using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Models
{
    public class Address
    {
        #region Attributes
        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public Geo Geo { get; set; }
        #endregion
    }
}
