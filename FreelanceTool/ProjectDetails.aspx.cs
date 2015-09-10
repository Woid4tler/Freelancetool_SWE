using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_FreelanceTool;

namespace FreelanceTool
{
    public partial class ProjectDetails : System.Web.UI.Page
    {
        int currentID;
        Projects currentProject;

        // In der Methode wird das Business Objekt, welches in dieser Seite 
        // visualisiert wird, geladen (wenn bestehender Kunde) oder erzeugt (neuer Kunde)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                currentID = (int)Session["id"]; //wurde beim Aufruf übertragen
                if (currentID != 0)
                {
                    //Objekt laden und Werte setzen
                    currentProject = Main.getProjectByID(currentID);
                    if (currentProject != null)
                    {
                        //kopiere die Properties des Objekts in die Felder der Maske
                        //lblID.Text = currentProject.id;
                        txtNameProject.Text = currentProject.name;
                        //drdCustomer.Text = currentProject.customerID;
                        Session["Project"] = currentProject; //Projektobjekt in Session speichern
                        //btnDelete.Visible = true;
                    }
                    else
                    {
                        //lblError.Text = "Projekt nicht gefunden - Sie können ein neues Projekt anlegen!";
                        //btnDelete.Visible = false;
                        //PlaceHolderKommentare.Visible = false;
                        Session["Project"] = Main.newProject(); //neues leeres Kundenobjekt
                    }
                }
                else
                {
                    //leere ID? Dann ist das ein neues Projekt
                    //btnDelete.Visible = false;
                    //PlaceHolderKommentare.Visible = false;
                    currentProject = Main.newProject();
                    Session["Project"] = currentProject; //neues leeres Projektobjekt
                }
            }
            else
                currentProject = (Projects)Session["Project"];

            /*if (currentProject != null)
            {
                GridViewKommentare.DataSource = currentProject.Kommentare;
                GridViewKommentare.DataBind();
            }*/
        }

        protected void GVTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Button zur Projektübersicht
        protected void btnToDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProjectDetails.aspx"); //Redirect zur Projektdetailseite
        }
    }
}