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

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            return con;
        }

        public static List<Projects> getProjects()
        {
            // Schnellvariante, wie oben aber alles in einer Zeile....
            SqlCommand cmd = new SqlCommand("Select * from Projects", Main.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            List<Projects> allProjects = new List<Projects>();
            while (reader.Read())
            {
                Projects project = new Projects();
                project.id = reader.GetInt32(0);
                project.name = reader.GetString(1);
                project.customerID = reader.GetInt32(2);
                SqlCommand cmdCustomer = new SqlCommand("Select * from Customers WHERE id = " + project.customerID, Main.GetConnection());
                SqlDataReader readerCustomer = cmdCustomer.ExecuteReader();
                while (readerCustomer.Read())
                {
                    project.customerName = readerCustomer.GetString(1);
                }
                allProjects.Add(project);
            }
            Console.Write(allProjects);

            return allProjects;
        }


        //Methode ladet einen Projectrecord direkt aus der DB, speichert Werte in
        //BO_FreelanceTool-Objekt und gibt initialisiertes Objekt zurück.
        public static Projects getProjectByID(int ID)
        {
            return Projects.Load(ID);
        }
        /*
        public static Customers getCustomers()
        {

        }

        public static Customers getCustomerByID(int ID)
        {

        }
        */

        //gibt ein neues leeres Projektobjekt zum Speichern neuer Projekte zurück
        public static Projects newProject()
        {
            // falls man gleich etwas vorinitialisieren will, muss man später im PL nichts ändern
            return new Projects();
        }
    }
}
