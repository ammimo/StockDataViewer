using System;
using System.Collections.Generic;
using System.Text;

namespace StockDataViewerEntity
{
    /// <summary>
    /// Class to represent AnalystRatings entity for EOD Historical Data Fundamentals
    /// </summary>
    public class AnalystRatings
    {
        #region Properties
        public double Rating { get; set; }
        public double TargetPrice { get; set; }
        public double StrongBuy { get; set; }
        public int Buy { get; set; }
        public int Hold { get; set; }
        public int Sell { get; set; }
        public int StrongSell { get; set; }
        #endregion
    }
}
