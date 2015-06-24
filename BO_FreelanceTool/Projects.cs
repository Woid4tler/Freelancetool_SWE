using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace BO_FreelanceTool
{
    public class Projects
    {
        private int _id;
        private int _customerID;
        private string _name;
        private string _customerName;
        private Tasks[] tasks;


        //Properties
        public int id
        {
            get { return _id; }
            set { _id = value; }
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
    }
}
