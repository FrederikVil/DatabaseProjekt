using System;
using System.Data.SqlClient;
using DatabaseProjekt.Model;

namespace DatabaseProjekt
{
    class Program
    {
        
        public static void Main()
        {

            //SavePostnummer();

            //SaveByNavn();

            DeletePostnummer();

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

        static void SavePostnummer()
        {
            SqlConnection c = GetConnection();
            Postnummer zip = new Postnummer(c);
            Console.Write("Tilføj postnummer: ");
            zip.postnummer = Convert.ToInt32(Console.ReadLine());
            zip.Save();
        }

        static void DeletePostnummer()
        {
            SqlConnection c = GetConnection();
            Postnummer zip = new Postnummer(c);
            Console.Write("Fjern postnummer: ");
            zip.postnummer = Convert.ToInt32(Console.ReadLine());
            zip.Delete();
        }

        static void SaveByNavn()
        {
            SqlConnection c = GetConnection();
            ByNavn city = new ByNavn(c);
            Console.Write("Tilføj by: ");
            city.byNavn = Convert.ToString(Console.ReadLine());
            city.Save();
        }


    }
}
