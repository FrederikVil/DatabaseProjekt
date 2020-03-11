using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseProjekt.Model;

namespace DatabaseProjekt
{
    class Program
    {
        
        public static void Main()
        {

            //InsertPostnummerOgBy();

            //SelectByNavn();

            //DeleteByWorksForAllClasses();

            //DeletePostnummerWorksForAllClasses();

            UpdatePostnummer();

        }

        // Min connection string jeg kan tage med i andre klasser
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
            return conn;
        }

        // Delete postnummer med metoden der kan bruges i alle klasser. 
        // SQL server forbyder at man sletter et postnummer hvis det bruges som foreign key i en anden tabel.
        static void DeletePostnummerWorksForAllClasses()
        {
            SqlConnection c = GetConnection();
            Postnummer zip = new Postnummer(c);
            Console.Write("Fjern postnummer: ");
            zip.postnummer = Convert.ToInt32(Console.ReadLine());
            zip.Save();
        }

        // Delete by, med metoden der kan bruges i alle klasser.
        static void DeleteByWorksForAllClasses()
        {
            SqlConnection c = GetConnection();
            ByNavn city = new ByNavn(c);
            Console.Write("Fjern by: ");
            city.byNavn = Convert.ToString(Console.ReadLine());
            city.Save();
        }

        // Insert Postnummer og by i databasen.
        static void InsertPostnummerOgBy()
        {
            SqlConnection c = GetConnection();
            Postnummer zip = new Postnummer(c);
            Console.Write("Tilføj postnummer: ");
            zip.postnummer = Convert.ToInt32(Console.ReadLine());
            int newID = zip.Insert();
            Console.WriteLine("Postnummerets ID er: " + newID);

            ByNavn city = new ByNavn(c);
            Console.Write("Tilføj by: ");
            city.byNavn = Convert.ToString(Console.ReadLine());
            Console.Write("Tilføj byens Postnummer ID: ");
            city.postnummerID = Convert.ToString(Console.ReadLine());
            city.Insert();
        }

        // Printer bynavne og deres postnummer ud
        static void SelectByNavn()
        {
            SqlConnection c = GetConnection();
            ByNavn city = new ByNavn(c);
            city.Select();
        }

        // Opdaterer postnummer
        static void UpdatePostnummer()
        {
            SqlConnection c = GetConnection();
            Postnummer zip = new Postnummer(c);
            Console.Write("Vælg et postnummmer ID der skal opdateres: ");
            zip.postnummerID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Skriv det nye postnummer: ");
            zip.postnummer = Convert.ToInt32(Console.ReadLine());

            // Liste med felter der skal opdateres tages med ind i Postnummer klassen.
            List<string> propertiesToBeUpdated = new List<string>
            {
                "postnummer"            
            };

            zip.Update(propertiesToBeUpdated);           
        }
    }
}
