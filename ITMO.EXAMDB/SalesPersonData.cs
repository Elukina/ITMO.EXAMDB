using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO.EXAMDB
{
    public class SalesPersonData
    {
        private int businessEntityID = 0;
        private int territoryID = 0;
        private decimal salesLastYear = 0;
        private DateTime modifiedDate = DateTime.MinValue;

        public int BusinessEntityID { get => businessEntityID; set => businessEntityID = value; }
        public int TerritoryID { get => territoryID; set => territoryID = value; }
        public decimal SalesLastYear { get => salesLastYear; set => salesLastYear = value; }
        public DateTime ModifiedDate { get => modifiedDate; set => modifiedDate = value; }
    }
}
