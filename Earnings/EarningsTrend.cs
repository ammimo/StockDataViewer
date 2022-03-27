using System;
using System.Collections.Generic;
using System.Text;

namespace StockDataViewerEntity
{
    /// <summary>
    /// 
    /// </summary>
    public class RevenueTrend
    {
        #region Properties
        public DateTime Date { get; set; }
        public string Period { get; set; }
        public double Growth { get; set; }
        public double EarningsEstimateAvg { get; set; }
        public double EarningsEstimateLow { get; set; }
        public double EarningsEstimateHigh { get; set; }
        public double EarningsEstimateYearAgoEps { get; set; }
        public double EarningEstimateNumberOfAnalysts { get; set; }
        public double EarningsEstimateGrowth { get; set; }
        public double RevenueEstimateAvg { get; set; }
        public double RevenyeEstimateLow { get; set; }
        public double RevenueEstimateHigh { get; set; }
        public double RevenueEstimateYearAgoEps { get; set; }
        public double RevenueEstimateNumberOfAnalysts { get; set; }
        public double RevenueEstimateGrowth { get; set; }
        public double EpsTrendCurrent { get; set; }
        public double EpsTrend7DaysAgo { get; set; }
        public double EpsTrend30DaysAgo { get; set; }
        public double EpsTrend60DaysAgo { get; set; }
        public double EpsTrend90DaysAgo { get; set; }
        public double EpsRevisionsUpLast7Days { get; set; }
        public double EpsRevisionsUpLast30Days { get; set; }
        public double EpsRevisionsDownLast7Days { get; set; }
        public double EpsRevisionsDownLast30Days { get; set; }
        #endregion

    }
}
