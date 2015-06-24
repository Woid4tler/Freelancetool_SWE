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
        /*
        public static Projects getProjectByID(int ID)
        {

        }

        public static Customers getCustomers()
        {

        }

        public static Customers getCustomerByID(int ID)
        {

        }
        */
    }
}
