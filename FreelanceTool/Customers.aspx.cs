using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreelanceTool
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Button zur Projektübersicht
        protected void btnToDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx"); //Redirect zur Projektübersicht
        }

        //Button neuen Kunden anlegen
        protected void btnNewCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerDetails.aspx"); //Redirect zur Kundendetailseite
        }
    }
}