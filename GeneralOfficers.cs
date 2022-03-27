using StockDataViewer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDataViewerEntity
{
    public class GeneralOfficers
    {

        #region Properties
        public string Name { get; set; }
        public string YearBorn { get; set; }
        public string Title { get; set; }
        #endregion

        #region ForeignKeys
        public General General;
        #endregion

        public const string WebApiFilter = "&filter=General::Officers";
    }
}
