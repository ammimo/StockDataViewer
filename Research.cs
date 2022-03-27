using System;
using System.Collections.Generic;
using System.Data;
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
            string token = "5f36bb14ec61e1.52623955";

            string finance = GetWebRequest(tick, token);
            //DataTable highlights = GetHighlightsWebClient(tick, token);
            
            //string classItem = CreateClassItem(highlights);

        }

        public static DataTable GetHighlightsWebClient(string tick, string token)
        {
            string baseUrl = "https://eodhistoricaldata.com/api/fundamentals/" + tick + "?api_token=" + token;
            string general = "&filter=Highlights";
            string url = baseUrl + general;

            //Web Request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            DataTable table = new DataTable();

            string[] items = results.Replace("\"", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty).Split(",");

            List<string> values = new List<string>();
            foreach (string i in items)
            {
                string[] split = i.Split(":");
                string name = split[0];

                table.Columns.Add(name);
                string value = split[1];
                values.Add(value);
            }
            table.Rows.Add(values.ToArray());

            return table;
        }

        public static string GetWebRequest(string tick, string token)
        {
            string baseUrl = "https://eodhistoricaldata.com/api/fundamentals/" + tick + "?api_token=" + token;// + "&filter=Highlights";
            string transactions = "&filter=General::Code,General";// +
               // "CountryISO,ISIN,CUSIP,CIK,EmployerIDNumber,FiscalYearEnd,IPODate,InternationalDomestic,Sector,Industry,GicSector,"+
               // "GicGroup,GicIndustry,GicSubIndustry,HomeCategory,IsDelisted,Description,Phone,WebURL,LogoURL,FullTimeEmployees,UpdatedAt";
            string url = baseUrl + transactions;

            //Web Request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }



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
    }
}
