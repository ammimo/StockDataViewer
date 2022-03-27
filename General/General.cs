using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace StockDataViewer
{

    /// <summary>
    /// Class to represent general entity on EOD Historical Data API
    /// </summary>
    public class General
    {
        public string Code { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Exchange { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public string CountryName { get; set; }
        public string CountryISO { get; set; }
        public string ISIN { get; set; } //primary key
        public string CUSIP { get; set; }
        public string CIK { get; set; }
        public string EmployerIdNumber { get; set; }
        public DateTime FiscalYearEnd { get; set; }
        public DateTime IPODate { get; set; }
        public string InternationalDomestic { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string GicSector { get; set; }
        public string GicGroup { get; set; }
        public string GicIndustry { get; set; }
        public string GicSubIndustry { get; set; }
        public string HomeCategory { get; set; }
        public Boolean IsDelisted { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string WebURL { get; set; }
        public string LogoURL { get; set; }
        public double FullTimeEmployees { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string GeneralType { get; set; }



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



        public static DataTable GetGeneralAddressWebClient(string tick, string token)
        {
            string baseUrl = "https://eodhistoricaldata.com/api/fundamentals/" + tick + "?api_token=" + token;
            string general = "&filter=General::AddressData";
            string url = baseUrl + general;

            //Web Request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
            if (results.Contains("\"NA\""))
            {
                return null;
            }
            DataTable table = new DataTable();

            string[] items = results.Replace("{", string.Empty).Replace("}", string.Empty).Split("\",");

            List<string> values = new List<string>();
            foreach (string i in items)
            {
                string[] split = i.Split(":");
                DataColumn column = new DataColumn();
                column.ColumnName = split[0].Replace("\"", string.Empty);
                table.Columns.Add(column);
                values.Add(split[1].Replace("\"", string.Empty));
            }
            table.Rows.Add(values.ToArray());
            return table;
        }

        public static DataTable GetGeneralListingsWebClient(string tick, string token)
        {
            //Url Creator
            string baseUrl = "https://eodhistoricaldata.com/api/fundamentals/" + tick + "?api_token=" + token;
            string general = "&filter=General::Listings";
            string url = baseUrl + general;

            //Web Request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
            if (results == "{}")
            {
                return null;
            }


            DataTable table = new DataTable();
            DataColumn hashCode = new DataColumn();
            hashCode.ColumnName = "HashCode";
            DataColumn Name = new DataColumn();
            Name.ColumnName = "Ticker";
            DataColumn Title = new DataColumn();
            Title.ColumnName = "Exchange";
            DataColumn YearBorn = new DataColumn();
            YearBorn.ColumnName = "Name";
            DataColumn TimeofDataEntry = new DataColumn();
            TimeofDataEntry.ColumnName = "TimeOfDataEntry";
            table.Columns.Add(hashCode);
            table.Columns.Add(TimeofDataEntry);
            table.Columns.Add(Name);
            table.Columns.Add(Title);
            table.Columns.Add(YearBorn);


            string[] seperators = { "{", "}" };
            string[] values = results.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string stock in values)
            {
                if (stock.Length == 4 || stock.Length == 5)
                {
                    continue;
                }

                string[] newSplit = stock.Split("\",");
                string ticker = newSplit[0].Replace("\"", string.Empty).Substring(newSplit[0].IndexOf(":") - 1, newSplit[0].Length - newSplit[0].IndexOf(":") - 2);
                string ex = newSplit[1].Replace("\"", string.Empty).Substring(newSplit[1].IndexOf(":") - 1, newSplit[1].Length - newSplit[1].IndexOf(":") - 2);
                string name = newSplit[2].Replace("\"", string.Empty).Substring(newSplit[2].IndexOf(":") - 1, newSplit[2].Length - newSplit[2].IndexOf(":") - 3);
                string timeOfDataEntry = DateTime.Now.ToString();

                List<string> val = new List<string>()
                {
                    timeOfDataEntry, ticker, ex, name
                };
                string hashcode = val.GetHashCode().ToString();
                val.Insert(0, hashcode);
                table.Rows.Add(val.ToArray());

            }
            return table;
        }

        public static DataTable GetGeneralOfficersWebClient(string ticker, string apiToken)
        {
            //Url Creator
            string baseUrl = "https://eodhistoricaldata.com/api/fundamentals/" + ticker + "?api_token=" + apiToken;
            string general = "&filter=General::Officers";
            string url = baseUrl + general;

            //Web Request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
            if (results == "{}")
            {
                return null;
            }


            DataTable table = new DataTable();
            DataColumn Name = new DataColumn();
            Name.ColumnName = "Name";
            DataColumn Title = new DataColumn();
            Title.ColumnName = "Title";
            DataColumn YearBorn = new DataColumn();
            YearBorn.ColumnName = "YearBorn";
            table.Columns.Add(Name);
            table.Columns.Add(Title);
            table.Columns.Add(YearBorn);

            string[] separators = { "{", "}" };
            string[] values = results.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string officer in values)
            {
                if (officer.Length == 4 || officer.Length == 5)
                {
                    continue;
                }
                string[] inf = officer.Split("\",");
                string name = inf[0].Replace("\"", string.Empty).Substring(inf[0].IndexOf(":") - 1, inf[0].Length - inf[0].IndexOf(":") - 2);
                string title = inf[1].Replace("\"", string.Empty).Substring(inf[1].IndexOf(":") - 1, inf[1].Length - inf[1].IndexOf(":") - 2);
                string yearBorn = inf[2].Replace("\"", string.Empty).Substring(inf[2].IndexOf(":") - 1, inf[2].Length - inf[2].IndexOf(":") - 3);
                List<string> add = new List<string>()
                {
                    name.Replace("  ", " "), title, yearBorn
                };
                table.Rows.Add(add.ToArray());

            }
            return table;
        }

        public static DataTable GetGeneralWebClient(string ticker, string apiToken)
        {
            //Url Creator
            string baseUrl = "https://eodhistoricaldata.com/api/fundamentals/" + ticker + "?api_token=" + apiToken;
            string general = "&filter=General";
            string url = baseUrl + general;

            //Web Request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            //Formatting
            string[] separators = { "AddressData", "\"Phone\"" };
            string[] words = results.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string itemToDeserialize = words[0] + "Phone" + words[2];
            string[] items = itemToDeserialize.Split(",\"");
            List<string> formatting = new List<string>();
            List<string> finalItems = new List<string>();
            foreach (string w in items)
            {
                string add = w.Replace("\"", String.Empty).Replace(@"""", String.Empty).Replace("{", String.Empty).Replace("}", String.Empty).Replace("/", String.Empty);
                formatting.Add(add);
            }

            //DataTable creation
            DataTable table = new DataTable();

            foreach (string item in formatting)
            {
                int index = item.IndexOf(":");
                string name = item.Substring(0, index);
                string number = item.Substring(index + 1, item.Length - index - 1);
                table.Columns.Add(name);
                finalItems.Add(number);

            }

            table.Rows.Add(finalItems.ToArray());
            formatting.Clear();
            finalItems.Clear();
            table.TableName = "General";
            return table;
        }
    }





}

