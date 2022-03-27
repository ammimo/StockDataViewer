using System;
using System.Collections.Generic;
using System.Text;

namespace StockDataViewerEntity
{
    public class EarningsHistory
    {
        #region Properties
        public DateTime ReportDate { get; set; }
        public DateTime Date { get; set; }
        public string BeforeAfterMarket { get; set; }
        public string Currency { get; set; }
        public double EpsActual { get; set; }
        public double EpsEstimate { get; set; }
        public double EpsDifference { get; set; }
        public double SuprisePercent { get; set; }
        #endregion

    }
}
