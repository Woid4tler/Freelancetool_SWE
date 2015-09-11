using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_FreelanceTool;

namespace FreelanceTool
{
    public partial class CustomersOverview : System.Web.UI.Page
    {
        private List<Customers> allCustomers;

        protected void Page_Load(object sender, EventArgs e)
        {
            //GVCustomers.DataSource wird auf eine Liste von BO-Objekte gesetzt
            if (!IsPostBack)
            {
                allCustomers = Main.getCustomers(); //hier stecken alle Kunden als einzelne Objekte drin!
                Session["allCustomers"] = allCustomers; // die heb ich mir in der Session auf
                GVCustomers.DataSource = allCustomers;
                GVCustomers.DataBind(); //dadurch wirds angezeigt
            }
            else
            {
                allCustomers = (List<Customers>)Session["allCustomers"];
            }
        }

        //Button zur Projektübersicht
        protected void btnToProjectsOverview_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProjectsOverview.aspx"); //Redirect zur Projektübersicht
        }

        //Button neuen Kunden anlegen
        protected void btnNewCustomer_Click(object sender, EventArgs e)
        {
            Session["id"] = ""; //leere ID - also neu
            Response.Redirect("CustomerDetails.aspx"); //Redirect zur Kundendetailseite
        }

        protected void GVCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GVCustomers.SelectedRow;
            // die Zeilennummer in der GridView entsricht der Position in der Liste
            Session["id"] = allCustomers[row.RowIndex].id; //ID aus dem Objekt rausholen und in der Session speichern
            Response.Redirect("CustomerDetails.aspx"); //Kundendetailseite aufrufen - die ladet sich dann das Objekt neu.
        }
    }
}