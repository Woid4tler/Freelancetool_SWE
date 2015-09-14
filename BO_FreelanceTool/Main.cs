using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.IO;

namespace BO_FreelanceTool
{
    public static class Main
    {

        static internal SqlConnection GetConnection()
        {
            List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
            dirs.RemoveAt(dirs.Count - 1); //letztes Verzeichnis entfernen
            string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + String.Join(@"\", dirs) + @"\FreelanceTool.mdf;Integrated Security=True;Connect Timeout=5";
            // MATHIAS connection String string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mathias\Documents\GitHub\Freelancetool_SWE\FreelanceTool.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            return con;
        }

        public static List<Projects> getProjects()
        {
            return Projects.LoadAll();
        }


        //Methode ladet einen Projectrecord direkt aus der DB, speichert Werte in
        //BO_FreelanceTool-Objekt und gibt initialisiertes Objekt zurück.
        public static Projects getProjectByID(string ID)
        {
            return Projects.Load(ID);
        }
        
        public static List<Customers> getCustomers()
        {
            return Customers.LoadAll(); ;
        }

        //Methode ladet einen Projectrecord direkt aus der DB, speichert Werte in
        //BO_FreelanceTool-Objekt und gibt initialisiertes Objekt zurück.
        public static Customers getCustomerByID(string ID)
        {
            return Customers.Load(ID);
        }
        

        //gibt ein neues leeres Projektobjekt zum Speichern neuer Projekte zurück
        public static Projects newProject()
        {
            // falls man gleich etwas vorinitialisieren will, muss man später im PL nichts ändern
            return new Projects();
        }

        //gibt ein neues leeres Kundenobjekt zum Speichern neuer Kunden zurück
        public static Customers newCustomer()
        {
            // falls man gleich etwas vorinitialisieren will, muss man später im PL nichts ändern
            return new Customers();
        }
    }
}
