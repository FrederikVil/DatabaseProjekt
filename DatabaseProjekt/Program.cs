using System;
using System.Data.SqlClient;
using DatabaseProjekt.Model;

namespace DatabaseProjekt
{
    class Program
    {
        
        public static void Main()
        {
            SqlConnection c = GetConnection();
            Postnummer zip = new Postnummer(c);
            zip.postnummer = 2;
            zip.Save();
        }
        static SqlConnection GetConnection()
        {
            
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                InitialCatalog = "Dyr",
                UserID = "Dyr",
                Password = "admin",
                DataSource = "localhost"
            };

            SqlConnection conn = new SqlConnection(builder.ConnectionString);

          //  SqlConnection conn = new SqlConnection("Server=localhost; Database=Dyr; Uid=Dyr;Pwd=admin");

            return conn;
        }
    }
}
