using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BO_FreelanceTool
{
    public class Customers
    {
        private string _id;
        private string _name;
        private string _mail;
        private string _phone;


        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string mail
        {
            get { return _mail; }
            set { _mail = value; }
        }
        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public List<Adresses> getAdresses {
            get {
                return Adresses.LoadAdressesForCustomer(this);
            }
        }

        /*
        public Boolean save(){

        }

        public Boolean delete(){

        }*/


        /************************************************************************************************************
        STATISCHE METHODEN
        internal bedeutet, dass sie nur von Klassen aus BO_Freelancetool (aus dem eigenem Namespace) aufgerufen werden können 
        - also nicht direkt aus dem PL

        Die Methoden sind im BO_Freelancetool-Objekt, damit der BO-Programmierer alle SQL-Statements, die Kunden betreffen, an einer Stelle hat
        Der PL-Programmierer sieht diese Implementation aber nicht. Er sieht die Methoden, von wo aus er diese Objekte "bekommt"
        (also entsprechend der Navigability). Man hätte diese Methoden technisch aber problemlos auch in die cMain geben können!
        */


        // Hilfsfunktion für die beiden unteren Methoden
        private static Customers fillCustomerFromSQLDataReader(SqlDataReader reader)
        {
            Customers oneCustomer = new Customers();
            oneCustomer.id = reader.GetString(0);
            oneCustomer.name = reader.GetString(1);
            oneCustomer.mail = reader.GetString(2);
            oneCustomer.phone = reader.GetString(3);
            return oneCustomer;
        }
        // Laden eines Customerobjekts - wird von Main.getCustomerByID() aufgerufen
        internal static Customers Load(string CustomerID)
        {
            string SQL = "select id, name, mail, phone from Customers where id = @id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            cmd.Parameters.Add(new SqlParameter("id", CustomerID));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); //setzt den Reader auf den ersten / nächsten DS
                return fillCustomerFromSQLDataReader(reader);
            }
            else
                return null;
        }

        // Laden aller Customers als Liste von Objekten
        internal static List<Customers> LoadAll()
        {
            SqlCommand cmd = new SqlCommand("Select id, name, mail, phone from Customers", Main.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            List<Customers> allCustomers = new List<Customers>();
            while (reader.Read())
            {
                Customers customer = fillCustomerFromSQLDataReader(reader);
                allCustomers.Add(customer);
            }
            return allCustomers;
        }
    }
}
