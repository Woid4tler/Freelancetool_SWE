using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreelanceTool
{
    public partial class CustomerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Button zur Kundenverwaltung
        protected void btnToCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customers.aspx"); //Redirect zur Kundenverwaltungseite
        }
    }
}