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
                        txtNameProject.Text = currentProject.name;
                        lblProjekttitle.Text = " - " + currentProject.name + " / " + currentProject.customerName;
                        ddlCustomer.SelectedValue = currentProject.customerID;
                        Session["Project"] = currentProject; //Projektobjekt in Session speichern
                        btnDeleteProject.Visible = true;
                    }
                    else
                    {
                        lblError.Text = "Projekt nicht gefunden - Sie können ein neues Projekt anlegen!";
                        btnDeleteProject.Visible = false;
                        tblNewTask.Visible = false;
                        Session["Project"] = Main.newProject(); //neues leeres Kundenobjekt
                    }
                }
                else
                {
                    //leere ID? Dann ist das ein neues Projekt
                    btnDeleteProject.Visible = false;
                    tblNewTask.Visible = false;
                    currentProject = Main.newProject();
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
                allTasks = currentProject.getTasks;
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
                if (currentProject.save())
                {
                    lblError.Text = "Projekt wurde gespeichert!";
                    btnDeleteProject.Visible = true;
                    tblNewTask.Visible = true;
                }
                else lblError.Text = "Speichern fehlgeschlagen";
            }
            else lblError.Text = "Projekt existiert nicht mehr in der Datenbank!";
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

        protected void btnNewComment_Click(object sender, EventArgs e)
        {
            /*if (currentProject != null)
            {
                Comments newComment = new Comments();
                //newComment.text = txtNewComment.Text;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView gv = (GridView)e.Row.FindControl("GVComments");
                    allTasks = currentProject.getTasks;
                    gv.DataSource = allTasks[e.Row.RowIndex].getComments;
                    gv.DataBind();

                }
                newComment.text = "test";
                newComment.addToTask(currentProject.id);
                newComment.save();
                txtNewTask.Text = "";
                //liste neu laden
                //GVTasks.DataSource = currentProject.getTasks;
                //GVTasks.DataBind();
            }*/
        }
        
        protected void GVTasks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Tasks taskToDelete = allTasks[e.RowIndex];
            if (taskToDelete.delete())
            {
                GVTasks.DataSource = currentProject.getTasks;
                GVTasks.DataBind();
            }
        }
    }
}