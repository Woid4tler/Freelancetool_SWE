using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BO_FreelanceTool
{
    public class Adresses
    {
        // FELDER bzw. VARIABLEN *********************************************************************************************
        private string _id;
        private string _customerID;
        private string _city;
        private string _zip;
        private string _street;
        private string _nr;

        // PROPERTIES *********************************************************************************************
        public string id
        {
            get { return _id; }
            private set { _id = value; }
        }
        public string customerID
        {
            get { return _customerID; }
            private set { _customerID = value; }
        }
        public string city
        {
            get { return _city; }
            set { _city = value; }
        }
        public string zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
        public string street
        {
            get { return _street; }
            set { _street = value; }
        }
        public string nr
        {
            get { return _nr; }
            set { _nr = value; }
        }
        
        public Boolean save()
        {
            string SQL = "insert into Adresses (id, city, zip, street, nr, customerID) values (@id, @city, @zip, @street, @nr, @customerID)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            _id = Guid.NewGuid().ToString();
            cmd.Parameters.Add(new SqlParameter("id", _id));
            cmd.Parameters.Add(new SqlParameter("city", _city));
            cmd.Parameters.Add(new SqlParameter("zip", _zip));
            cmd.Parameters.Add(new SqlParameter("street", _street));
            cmd.Parameters.Add(new SqlParameter("nr", _nr));
            cmd.Parameters.Add(new SqlParameter("customerID", _customerID));
            return (cmd.ExecuteNonQuery() > 0);
        }
        
        public Boolean delete()
        {
            if (_id != "")
            {
                SqlCommand cmd = new SqlCommand("delete Adresses where ID = @id", Main.GetConnection());
                cmd.Parameters.Add(new SqlParameter("id", _id));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    _id = "";
                    return true;
                }
                else return false; //Löschen aus DB klappt nicht
            }
            else return true;
        }

        public void addToCustomer(string cust_id)
        {
            _customerID = cust_id;
        }

        // Laden aller Adressen als Liste von Objekten für einen bestimmten Kunden - Funktion wird von Customers aufgerufen!
        internal static List<Adresses> LoadAdressesForCustomer(Customers theCustomer)
        {
            SqlCommand cmd = new SqlCommand("select id, city, zip, street, nr, customerID from Adresses where customerID = @customerID", Main.GetConnection());
            cmd.Parameters.Add(new SqlParameter("customerID", theCustomer.id));
            SqlDataReader reader = cmd.ExecuteReader();
            List<Adresses> allAdresses = new List<Adresses>(); //initialisiere lehre Liste von Adressen
            while (reader.Read())
            {
                Adresses oneAdress = new Adresses();
                oneAdress.id = reader.GetString(0);
                oneAdress.city = reader.GetString(1);
                oneAdress.zip = reader.GetString(2);
                oneAdress.street = reader.GetString(3);
                oneAdress.nr = reader.GetString(4);
                oneAdress.customerID = reader.GetString(5);
                allAdresses.Add(oneAdress);
            }
            return allAdresses;
        }
    }
}
