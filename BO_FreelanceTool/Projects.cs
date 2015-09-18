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
        private string _id = "";
        private string _customerID;
        private string _name;
        private string _customerName;
        private String _dateCreate, _dateEnd;


    // PROPERTIES *********************************************************************************************
        public string id
        {
            get { return _id; }
            private set { _id = value; }
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
        public string dateCreate
        {
            get { return _dateCreate; }
            private set { _dateCreate = value; }
        }
        public string dateEnd
        {
            get { return _dateEnd; }
            set { _dateEnd = value; }
        }

        public List<Tasks> getTasks
        {
            get
            {
                return Tasks.LoadTasksForProject(this);
            }

        }
        
        public Customers getCustomer
         {
            get{
                Customers projectCustomer = Customers.Load(this.customerID);
                return projectCustomer;
            }
        }

        public void setCustomer()
        {
            Customers projectCustomer = Customers.Load(this.customerID);
            this.customerName = projectCustomer.name;
        }
         

        public Boolean save()
         {
            if (_id == "")
            {
                //neuer Record -> INSERT
                string SQL = "insert into Projects (id, name, customerID, dateCreate, dateEnd) values (@id, @proj_name, @cust_id, CURRENT_TIMESTAMP, @date_end)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                //GUID für ID erzeugen und als String zurückgeben (weil mID=="")!
                _id = Guid.NewGuid().ToString();
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("id", _id));
                cmd.Parameters.Add(new SqlParameter("proj_name", _name));
                cmd.Parameters.Add(new SqlParameter("cust_id", _customerID));
                cmd.Parameters.Add(new SqlParameter("date_end", Convert.ToDateTime(_dateEnd)));
                // ExecuteNonQuery() gibt die Anzahl der veränderten/angelegten Records zurück.
                return (cmd.ExecuteNonQuery() > 0); //hat der INSERT geklappt, sollte genau ein Record verändert worden sein
            }
            else
            {
                //bestehender Record -> UPDATE
                string SQL = "update Projects set name=@proj_name, customerID=@cust_id, dateEnd=@date_end where id = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                cmd.Parameters.Add(new SqlParameter("id", _id));
                cmd.Parameters.Add(new SqlParameter("proj_name", _name));
                cmd.Parameters.Add(new SqlParameter("cust_id", _customerID));
                cmd.Parameters.Add(new SqlParameter("date_end", Convert.ToDateTime(_dateEnd)));
                return (cmd.ExecuteNonQuery() > 0);
            }
         }

         
        public Boolean delete()
        {
            if (_id != "")
            {
                foreach (Tasks task in getTasks) { task.delete(); } //erst alle tasks des Projekts löschen!
                string SQL = "delete Projects where id = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                cmd.Parameters.Add(new SqlParameter("id", _id));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    _id = ""; //das Objekt existiert weiter - es verhält sich aber wieder wie ein neuer Kunde
                    return true;
                }
                else return false; //Löschen aus DB klappt nicht...
            }
            else return true; // Kunde hat keine ID??? -> war noch gar nicht gespeichert.
            // wenn er nicht gespeichert war, kann man ihn auch nicht löschen,
            // aber jedenfalls ist er auch nicht in der DB, also sagen wir halt true :-)
        }

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
            oneProject.dateCreate = reader.GetDateTime(3).ToString("dd.MM.yyyy");
            oneProject.dateEnd = reader.GetDateTime(4).ToString("dd.MM.yyyy");
            Customers projectCustomer = Customers.Load(oneProject.customerID);
            oneProject.customerName = projectCustomer.name;
            return oneProject;
        }
        // Laden eines Projectobjekts - wird von Main.getProjectByID() aufgerufen
        internal static Projects Load(string ProjectID)
        {
            string SQL = "select id, name, customerID, dateCreate, dateEnd from Projects where id = @id";
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
            SqlCommand cmd = new SqlCommand("Select id, name, customerID, dateCreate, dateEnd from Projects", Main.GetConnection());
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
