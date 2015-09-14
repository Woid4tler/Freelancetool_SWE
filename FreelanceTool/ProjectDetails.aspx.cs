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
        string currentID;
        Projects currentProject;
        private List<Customers> allCustomers;
        private List<Tasks> allTasks;

        // In der Methode wird das Business Objekt, welches in dieser Seite 
        // visualisiert wird, geladen (wenn bestehendes Projekt) oder erzeugt (neues Projekt)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                allCustomers = Main.getCustomers();
                ddlCustomer.DataSource = allCustomers;
                try
                {
                    ddlCustomer.DataSource = allCustomers;
                    ddlCustomer.DataTextField = "name";
                    ddlCustomer.DataValueField = "id";
                    ddlCustomer.DataBind();
                }
                catch (Exception error)
                {
                    Console.Write(error.Message);
                }
                currentID = (string)Session["id"]; //wurde beim Aufruf übertragen
                if (currentID != "")
                {
                    //Objekt laden und Werte setzen
                    currentProject = Main.getProjectByID(currentID);

                    if (currentProject != null)
                    {
                        //kopiere die Properties des Objekts in die Felder der Maske
                        //lblID.Text = currentProject.id;
                        txtNameProject.Text = currentProject.name;
                        lblProjekttitle.Text = " - " + currentProject.name + " / " + currentProject.customerName;
                        ddlCustomer.SelectedValue = currentProject.customerID;
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
                    //System.Diagnostics.Debug.WriteLine("neues Projekt geklickt");
                    Session["Project"] = currentProject; //neues leeres Projektobjekt
                }
            }
            else
                currentProject = (Projects)Session["Project"];

            if (currentProject != null)
            {
                allTasks = currentProject.getTasks;
                GVTasks.DataSource = allTasks;
                GVTasks.DataBind();
            }

            
        }

        protected void GVTasks_BoundComments(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = (GridView)e.Row.FindControl("GVComments");
                gv.DataSource = allTasks[e.Row.RowIndex].getComments;
                gv.DataBind();
            }
        }

        //Button zur Projektübersicht
        protected void btnToProjectsOverview_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProjectsOverview.aspx"); //Redirect zur Projektübersichtsseite
        }

        protected void btnSaveProject_Click(object sender, EventArgs e)
        {
            if (currentProject != null)
            {
                //Feldwerte in das Objekt laden
                currentProject.name = txtNameProject.Text;
                currentProject.customerID = ddlCustomer.SelectedValue;
                if (currentProject.save()) Response.Redirect("ProjectsOverview.aspx");
            }
        }

        protected void btnDeleteProject_Click(object sender, EventArgs e)
        {
                if (currentProject.delete()) Response.Redirect("ProjectsOverview.aspx");
        }

        protected void btnNewTask_Click(object sender, EventArgs e)
        {
            if (currentProject != null)
            {
                Tasks newTask = new Tasks();
                newTask.name = txtNewTask.Text;
                newTask.addToProject(currentProject.id);
                newTask.save();
                txtNewTask.Text = "";
                //liste neu laden
                GVTasks.DataSource = currentProject.getTasks;
                GVTasks.DataBind();
            }
        }
    }
}