using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ITMO.EXAMDB
{
    class DBSupport
    {

        private string connectionstring;
        public DBSupport(string name, string pass)
        {
            connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=AdventureWorks2017;Data Source=LAPTOP-RD2TJVDD\\SQLEXPRESS";
        }

        public List<SalesPersonData> Select()
        {
            List<SalesPersonData> l = new List<SalesPersonData>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("" +
                    "SELECT BusinessEntityID, TerritoryID, SalesLastYear, ModifiedDate FROM Sales.SalesPerson", connection))
                {
                    using(SqlDataReader r = command.ExecuteReader())
                    {
                        while(r.Read())
                        {
                            SalesPersonData s = new SalesPersonData();
                            s.BusinessEntityID = int.Parse(r[0].ToString());
                            if (String.IsNullOrEmpty(r[1].ToString()))
                                s.TerritoryID = 0;
                            else
                                s.TerritoryID = int.Parse(r[1].ToString());
                            s.SalesLastYear = decimal.Parse(r[2].ToString());
                            s.ModifiedDate = DateTime.Parse(r[3].ToString());
                            l.Add(s);
                        }
                    }
                }
                return l;
            }
            
        }

        public void Delete(SalesPersonData s)
        {

        }

        public void Add(SalesPersonData s)
        {

        }

        public void Edit(SalesPersonData s)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"UPDATE Sales.SalesPerson SET TerritoryID = {s.TerritoryID.ToString()}, SalesLastYear = {s.SalesLastYear.ToString()}, ModifiedDate = {s.ModifiedDate.ToString("yyyy-MM-dd")} WHERE BusinessEntityID = {s.BusinessEntityID.ToString()}", connection))
                {
                    command.ExecuteNonQuery();
                }
                
            }
        }

    }
}
