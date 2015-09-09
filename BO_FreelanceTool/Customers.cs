using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace BO_FreelanceTool
{
    public class Customers
    {
        private int _id;
        private string _name;
        private string _mail;
        private string _phone;
        private Adresses adress;


        public int id
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
	
        /*
        public Adresses getAdresses(){

        }

        public Boolean save(){

        }

        public Boolean delete(){

        }*/
    }
}
