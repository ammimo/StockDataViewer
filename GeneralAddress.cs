using System;
using System.Collections.Generic;
using System.Text;

namespace StockDataViewer
{
    public class GeneralAddress
    {
        #region Properties
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZIP { get; set; }
        #endregion

        #region Foreign Keys
        public General General { get; set; }
        #endregion

        public const string WebApiFilter = "&filter = General::AddressData";
    }
}
