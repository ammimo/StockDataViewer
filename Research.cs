using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace StockDataViewerEntity
{
    public class Research
    {

        static void Main(string[] args)
        {
            string tick = "SO.US";
            string token = "token";

            string finance = GetWebRequest(tick, token);

        }

        public static string GetWebRequest(string tick, string token)
        {
            string baseUrl = "https://eodhistoricaldata.com/api/fundamentals/" + tick + "?api_token=" + token + "&filter=SharesStats";
            string transactions = "&filter=Financials::Income_Statement::quarterly";
            string url = baseUrl;// + transactions;

            //Web Request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }

    }
}
