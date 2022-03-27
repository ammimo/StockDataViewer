using System;
using System.Collections.Generic;
using System.Text;

namespace StockDataViewerEntity
{
    /// <summary>
    /// Class to present Earnings entity for EOD Historical Data Fundamentals
    /// </summary>
    public class Earnings
    {
        public string EarningsType { get; set; }

        public ICollection<EarningsHistory> EarningsHistory { get; set; }
        public ICollection<EarningsAnnual> EarningsAnnual { get; set; }
        public ICollection<EarningsTrend> EarningsTrends { get; set; }

    }
}
