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
        // FELDER bzw. VARIABLEN *********************************************************************************************
        private string _id = "";
        private string _name;
        private string _mail;
        private string _phone;

        // PROPERTIES *********************************************************************************************
        
        public string id
        {
            get { return _id; }
            private set { _id = value; }
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

       
        public Boolean save(){
            if (_id == "")
            {
                //neuer Record -> INSERT
                string SQL = "insert into Customers (id, name, mail,phone) values (@id, @cust_name, @cust_mail,@cust_phone)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                //GUID für ID erzeugen und als String zurückgeben (weil mID=="")!
                _id = Guid.NewGuid().ToString();
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("id", _id));
                cmd.Parameters.Add(new SqlParameter("cust_name", _name));
                cmd.Parameters.Add(new SqlParameter("cust_mail", _mail));
                cmd.Parameters.Add(new SqlParameter("cust_phone", _phone));
                // ExecuteNonQuery() gibt die Anzahl der veränderten/angelegten Records zurück.
                return (cmd.ExecuteNonQuery() > 0); //hat der INSERT geklappt, sollte genau ein Record verändert worden sein
            }
            else
            {
                //bestehender Record -> UPDATE
                string SQL = "update Customers set name=@cust_name, mail=@cust_mail, phone=@cust_phone where id = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                cmd.Parameters.Add(new SqlParameter("id", _id));
                cmd.Parameters.Add(new SqlParameter("cust_name", _name));
                cmd.Parameters.Add(new SqlParameter("cust_mail", _mail));
                cmd.Parameters.Add(new SqlParameter("cust_phone", _phone));
                return (cmd.ExecuteNonQuery() > 0);
            }
        }
        
       public Boolean delete(){
            if (_id != "")
            {
                foreach (Adresses address in getAdresses) { address.delete(); } //erst alle Adressen des Kunden löschen!
                string SQL = "delete Customers where id = @id";
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
