using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockDataViewer
{
    public class GeneralListings
    {

        #region General Listings Properties
        public string Ticker { get; set; }
        public string Exchange { get; set; }
        public string Name { get; set; }
        #endregion

        #region Foreign Keys
        [Required]
        public General General { get; set; }
        #endregion
        

        public const string WebApiFilter = "&filter=General::Listings";
    }
}
