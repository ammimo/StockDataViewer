using System;
using System.Collections.Generic;
using System.Text;

namespace StockDataViewerEntity
{
    /// <summary>
    /// Class
    /// </summary>
    public class EarningsAnnual
    {
        #region Properties
        public DateTime Date { get; set; }
        public double EpsActual { get; set; }
        #endregion

        #region ForeignKeys
        public Earnings Earnings { get; set; }
        #endregion
    }
}
