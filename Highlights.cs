using System;
using System.Collections.Generic;
using System.Text;

namespace StockDataViewerEntity
{

    /// <summary>
    /// Class to represent Highlights Entity on EOD Historical Data
    /// </summary>
    public class Highlights
    {
        public string MarketCapitalization { get; set; }
        public string MarketCapitalizationMln { get; set; }
        public string EBITDA { get; set; }
        public string PERatio { get; set; }
        public string PEGRatio { get; set; }
        public string WallStreetTargetPrice { get; set; }
        public string BookValue { get; set; }
        public string DividendShare { get; set; }
        public string DividendYield { get; set; }
        public string EarningsShare { get; set; }
        public string EPSEstimateCurrentYear { get; set; }
        public string EPSEstimateNextYear { get; set; }
        public string EPSEstimateNextQuarter { get; set; }
        public string EPSEstimateCurrentQuarter { get; set; }
        public string MostRecentQuarter { get; set; }
        public string ProfitMargin { get; set; }
        public string OperatingMarginTTM { get; set; }
        public string ReturnOnAssetsTTM { get; set; }
        public string ReturnOnEquityTTM { get; set; }
        public string RevenueTTM { get; set; }
        public string RevenuePerShareTTM { get; set; }
        public string QuarterlyRevenueGrowthYOY { get; set; }
        public string GrossProfitTTM { get; set; }
        public string DilutedEpsTTM { get; set; }
        public string QuarterlyEarningsGrowthYOY { get; set; }


    }
}
