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
        private int _zip;
        private string _street;
        private int _nr;

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
        public string city
        {
            get { return _city; }
            set { _city = value; }
        }
        public int zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
        public string street
        {
            get { return _street; }
            set { _street = value; }
        }
        public int nr
        {
            get { return _nr; }
            set { _nr = value; }
        }
        /*
        public Boolean save()
        {

        }

        public Boolean delete()
        {

        }*/


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
                oneAdress.zip = reader.GetInt32(2);
                oneAdress.street = reader.GetString(3);
                oneAdress.nr = reader.GetInt32(4);
                oneAdress.customerID = reader.GetString(5);
                allAdresses.Add(oneAdress);
            }
            return allAdresses;
        }
    }
}
