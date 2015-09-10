using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BO_FreelanceTool
{
    public class Projects
    {
    // FELDER bzw. VARIABLEN *********************************************************************************************
        private int _id;
        private int _customerID;
        private string _name;
        private string _customerName;
        private Tasks[] tasks;


    // PROPERTIES *********************************************************************************************
        public int id
        {
            get { return _id; }
            internal set { _id = value; }
        }
        public int customerID
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

        /*
        public Customers getCustomer()
        {

        }

        public Tasks getTasks()
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
            oneProject.id = reader.GetInt32(0);
            oneProject.name = reader.GetString(1);
            oneProject.customerID = reader.GetInt32(2);
            return oneProject;
        }
        // Laden eines Projectobjekts - wird von Main.getProjectByID() aufgerufen
        internal static Projects Load(int ProjectID)
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
    }
}
