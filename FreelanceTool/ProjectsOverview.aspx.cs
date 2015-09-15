using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_FreelanceTool;

namespace FreelanceTool
{
    public partial class ProjectOverview : System.Web.UI.Page
    {
        private List<Projects> allProjects;

        protected void Page_Load(object sender, EventArgs e)
        {
            //GVProjects.DataSource wird auf eine Liste von BO-Objekte gesetzt
            if (!IsPostBack) {
                allProjects = Main.getProjects(); //hier stecken alle Projekte als einzelne Objekte drin!
                Session["allProjects"] = allProjects; // die heb ich mir in der Session auf
                GVProjects.DataSource = allProjects;
                GVProjects.DataBind(); //dadurch wirds angezeigt
            }
            else {
                allProjects = (List<Projects>)Session["allProjects"];
            }
        }

        //Button zur Kundenverwaltung
        protected void btnToCustomersOverview_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomersOverview.aspx"); //Redirect zur Kundenverwaltungseite
        }

        //Button neues Projekt anlegen
        protected void btnNewProject_Click(object sender, EventArgs e)
        {
            Session["id"] = ""; //leere ID - also neu
            Response.Redirect("ProjectDetails.aspx"); //Projektdetailseite aufrufen
        }

        // Um diese Methode automatisch anzulegen muss man die Gridview auswählen
        // und dann im Eigenschaftenfenster die Events auswählen (der Blitz)
        // dann Doppelklick in die Zeile SelectedIndexChanged
        // Tritt auf, wenn einer der Select-Button der GridView gedrückt wurde
        protected void GVProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GVProjects.SelectedRow;
            // die Zeilennummer in der GridView entsricht der Position in der Liste
            Session["id"] = allProjects[row.RowIndex].id; //ID aus dem Objekt rausholen und in der Session speichern
            Response.Redirect("ProjectDetails.aspx"); //Projektdetailseite aufrufen - die ladet sich dann das Objekt neu.
        }

    }
}