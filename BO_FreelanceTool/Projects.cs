using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BO_FreelanceTool
{
    public class Projects
    {
    // FELDER bzw. VARIABLEN *********************************************************************************************
        private string _id;
        private string _customerID;
        private string _name;
        private string _customerName;


    // PROPERTIES *********************************************************************************************
        public string id
        {
            get { return _id; }
            internal set { _id = value; }
        }
        public string customerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string customerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public List<Tasks> getTasks
        {
            get
            {
                return Tasks.LoadTasksForProject(this);
            }

        }
        /*
        public Customers getCustomer()
        {

        }


        public Boolean save()
        {

        }

        public Boolean delete()
        {

        }*/

        /************************************************************************************************************
        STATISCHE METHODEN
        internal bedeutet, dass sie nur von Klassen aus BOKunden (aus dem eigenem Namespace) aufgerufen werden können 
        - also nicht direkt aus dem PL

        Die Methoden sind im BOKunde-Objekt, damit der BO-Programmierer alle SQL-Statements, die Kunden betreffen, an einer Stelle hat
        Der PL-Programmierer sieht diese Implementation aber nicht. Er sieht die Methoden, von wo aus er diese Objekte "bekommt"
        (also entsprechend der Navigability). Man hätte diese Methoden technisch aber problemlos auch in die cMain geben können!
        */


        // Hilfsfunktion für die beiden unteren Methoden
        private static Projects fillProjectFromSQLDataReader(SqlDataReader reader)
        {
            Projects oneProject = new Projects();
            oneProject.id = reader.GetString(0);
            oneProject.name = reader.GetString(1);
            oneProject.customerID = reader.GetString(2);
            Customers projectCustomer = Customers.Load(oneProject.customerID);
            oneProject.customerName = projectCustomer.name;
            return oneProject;
        }
        // Laden eines Projectobjekts - wird von Main.getProjectByID() aufgerufen
        internal static Projects Load(string ProjectID)
        {
            string SQL = "select id, name, customerID from Projects where id = @id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            cmd.Parameters.Add(new SqlParameter("id", ProjectID));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); //setzt den Reader auf den ersten / nächsten DS
                return fillProjectFromSQLDataReader(reader);
            }
            else
                return null;
        }
        // Laden aller Projects als Liste von Objekten
        internal static List<Projects> LoadAll()
        {
            SqlCommand cmd = new SqlCommand("Select id, name, customerID from Projects", Main.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            List<Projects> allProjects = new List<Projects>();
            while (reader.Read())
            {
                Projects project = fillProjectFromSQLDataReader(reader);
                allProjects.Add(project);
            }
            return allProjects;
        }
    }
}
