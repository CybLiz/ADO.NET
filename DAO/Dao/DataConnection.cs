using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient; 

namespace DAO.Dao
{
    internal class DataConnection
    {
        private static readonly string connectionString = "Data Source=(localdb)\\TestSql;Initial Catalog=TestSql;Integrated Security=True;Encrypt=True";
        public static SqlConnection GetConnection => new(connectionString);

    }
}
