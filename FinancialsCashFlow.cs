using System;
using System.Collections.Generic;
using System.Text;

namespace StockDataViewerEntity
{
    public class FinancialsCashFlow
    {
        public string Date { get; set; }
        public string FilingDate { get; set; }
        public string CurrencySymbol { get; set; }
        public string Investments { get; set; }
        public string ChangeToLiabilities { get; set; }
        public string TotalCashFlowsFromInvestingActivities { get; set; }
        public string NetBorrowings { get; set; }
        public string TotalCashFromFinancingActivities { get; set; }
        public string ChangeToOperatingActivities { get; set; }
        public string NetIncome { get; set; }
        public string ChangeInCash { get; set; }
        public string BeginPeriodCashFlow { get; set; }
        public string EndPeriodCashFlow { get; set; }
        public string TotalCashFromOperatingActivities { get; set; }
        public string Depreciation { get; set; }
        public string OtherCashFlowsFromInvestingActivities { get; set; }
        public string DividendsPaid { get; set; }
        public string ChangeToInventory { get; set; }
        public string ChangeToAccountReceivables { get; set; }
        public string SalePurchaseOfStock { get; set; }
        public string OtherCashFlowsFromFinancingActivities { get; set; }
        public string ChangeToNetIncome { get; set; }
        public string CapitalExpenditures { get; set; }
        public string ChangeReceivables { get; set; }
        public string CashFlowsOtherOperating { get; set; }
        public string ExchangeRateChanges { get; set; }
        public string CashAndCashEquivalentsChanges { get; set; }
        public string ChangeInWorkingCapital { get; set; }
        public string OtherNonCashItems { get; set; }
        public string FreeCashFlow { get; set; }
    }
}
