using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace StockDataViewerEntity
{

    /// <summary>
    /// Class to represent Financials Entity of EOD Historial Data
    /// </summary>
    public class Financials
    {
        #region ForeignKeys
        [Required]
        public string Ticker { get; set; }
        [Required]
        public string Country { get; set; }
        #endregion

        public string FinancialType { get; set; }
        public string FinancialPeriod { get; set; }
        

        public static string CreateClassItem(DataTable item)
        {
            string className = "public class " + item.TableName;
            string newLine = Environment.NewLine;

            StringBuilder classBuilder = new StringBuilder();
            classBuilder.Append(className);
            classBuilder.AppendLine(Environment.NewLine + "{");

            foreach (DataColumn column in item.Columns)
            {
                string columnToAdd = "    public string " + column.ToString() + " {get; set; }" + Environment.NewLine;
                classBuilder.Append(columnToAdd);
            }

            classBuilder.Append("}");


            return classBuilder.ToString();
        }

        public static string GetFinancialsIncomeStatementQuarterlyRawData(string tick, string token)
        {
            string baseUrl = "https://eodhistoricaldata.com/api/fundamentals/" + tick + "?api_token=" + token;
            string transactions = "&filter=Financials::Income_Statement::quarterly";
            string url = baseUrl + transactions;

            //Web Request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }


        public static string GetFinancialsIncomeStatementYearlyRawData(string tick, string token)
        {
            string baseUrl = "https://eodhistoricaldata.com/api/fundamentals/" + tick + "?api_token=" + token;
            string transactions = "&filter=Financials::Income_Statement::yearly";
            string url = baseUrl + transactions;

            //Web Request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }

        public static string GetFinancialsCashFlowQuarterlyRawData(string tick, string token)
        {
            string baseUrl = "https://eodhistoricaldata.com/api/fundamentals/" + tick + "?api_token=" + token;
            string transactions = "&filter=Financials::Cash_Flow::quarterly";
            string url = baseUrl + transactions;

            //Web Request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }

        public static string GetFinancialsCashFlowYearlyRawData(string tick, string token)
        {
            string baseUrl = "https://eodhistoricaldata.com/api/fundamentals/" + tick + "?api_token=" + token;
            string transactions = "&filter=Financials" + "::Cash_Flow::yearly";
            string url = baseUrl + transactions;

            //Web Request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }


        public static string GetFinancialsBalanceSheetQuarterlyRawData(string tick, string token)
        {
            string baseUrl = "https://eodhistoricaldata.com/api/fundamentals/" + tick + "?api_token=" + token;
            string transactions = "&filter=Financials::Balance_Sheet::quarterly";
            string url = baseUrl + transactions;

            //Web Request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }

        public static string GetFinancialsBalanceSheetYearlyRawData(string tick, string token)
        {
            string baseUrl = "https://eodhistoricaldata.com/api/fundamentals/" + tick + "?api_token=" + token;
            string transactions = "&filter=Financials::Balance_Sheet::yearly";
            string url = baseUrl + transactions;

            //Web Request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }

        public static DataTable FinanicalDataTableMaker(string rawData)
        {
            string[] separators = { "{", "}" };
            string[] items = rawData.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            DataTable table = new DataTable();

            foreach (string i in items)
            {
                if (i.Length == 14 || i.Length == 13)
                {
                    continue;
                }

                List<string> toAdd = new List<string>();
                string[] values = i.Replace("\"", string.Empty).Split(",");
                foreach (string v in values)
                {
                    int index = v.IndexOf(":");
                    string name = v.Substring(0, index);
                    string item = v.Substring(index + 1, v.Length - index - 1);

                    if (table.Columns.Contains(name))
                    {
                        toAdd.Add(item);
                    }
                    else
                    {
                        table.Columns.Add(name);
                        toAdd.Add(item);
                    }
                }
                table.Rows.Add(toAdd.ToArray());
            }
            return table;
        }
    }
}
