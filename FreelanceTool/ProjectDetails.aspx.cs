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
            lblError.Text = "";
            if (!IsPostBack)
            {
                allCustomers = Main.getCustomers();
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
                        txtDateEnd.Text = currentProject.dateEnd;
                        lblDateCreate.Text = currentProject.dateCreate;
                        Session["Project"] = currentProject; //Projektobjekt in Session speichern
                        btnDeleteProject.Visible = true;
                        lblDateCreate.Visible = true;
                        tblNewComment.Visible = false;
                        updateTasks();
                    }
                    else
                    {
                        lblError.Text = "Projekt nicht gefunden - Sie können ein neues Projekt anlegen!";
                        btnDeleteProject.Visible = false;
                        tblNewTask.Visible = false;
                        tblNewComment.Visible = false;
                        lblDateCreate.Visible = false;
                        Session["Project"] = Main.newProject(); //neues leeres Kundenobjekt
                    }
                }
                else
                {
                    //leere ID? Dann ist das ein neues Projekt
                    btnDeleteProject.Visible = false;
                    tblNewTask.Visible = false;
                    lblDateCreate.Visible = false;

                    currentProject = Main.newProject();
                    Session["Project"] = currentProject; //neues leeres Projektobjekt
                }
            }
            else
                currentProject = (Projects)Session["Project"];
            
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
            lblError.Text = "";
            if (currentProject != null && dateValidator(txtDateEnd.Text))
            {
                //Feldwerte in das Objekt laden
                currentProject.name = txtNameProject.Text;
                currentProject.customerID = ddlCustomer.SelectedValue;
                currentProject.dateEnd = txtDateEnd.Text;
                if (currentProject.save())
                {
                    currentProject.setCustomer();
                    lblError.Text = "Projekt wurde gespeichert!";
                    btnDeleteProject.Visible = true;
                    tblNewTask.Visible = true;
                    lblDateCreate.Visible = true;
                    lblDateCreate.Text = currentProject.dateCreate;
                    lblProjekttitle.Text = " - " + currentProject.name + " / " + currentProject.customerName;
                }
                else lblError.Text = "Speichern fehlgeschlagen";
            }
            else if(dateValidator(txtDateEnd.Text)) lblError.Text = "Projekt existiert nicht mehr in der Datenbank!";
            else lblDateNotValid.Text = "kein gültiges Datum (z.B.: 11.11.2015)";
        }

        protected void btnDeleteProject_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (currentProject.delete()) Response.Redirect("ProjectsOverview.aspx");
            else lblError.Text = "Löschen nicht möglich!";
        }

        protected void btnNewTask_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (currentProject != null && txtNewTask.Text != "")
            {
                Tasks newTask = new Tasks();
                newTask.name = txtNewTask.Text;
                newTask.addToProject(currentProject.id);
                newTask.save();
                txtNewTask.Text = "";
                //liste neu laden
                updateTasks();
            }
            else lblError.Text = "Task kann nicht gespeichert werden!";
        }

        protected void btnNewComment_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (currentProject != null && txtNewComment.Text != "")
            {
                Comments newComment = new Comments();
                newComment.text = txtNewComment.Text;
                newComment.addToTask(ddlTask.SelectedItem.Value);
                newComment.save();
                txtNewComment.Text = "";
                //liste neu laden
                updateTasks();
            }
            else lblError.Text = "Kommentar kann nicht gespeichert werden!";
        }
        
        protected void GVTasks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Text = "";
            allTasks = currentProject.getTasks;
            Tasks taskToDelete = allTasks[e.RowIndex];
            if (taskToDelete.delete())
            {
                updateTasks();
            }
            else lblError.Text = "Task kann nicht gelöscht werden!";
        }

        protected void updateTasks()
        {
            allTasks = currentProject.getTasks;
            GVTasks.DataSource = allTasks;
            GVTasks.DataBind();

            try
            {
                ddlTask.DataSource = allTasks;
                ddlTask.DataTextField = "name";
                ddlTask.DataValueField = "id";
                ddlTask.DataBind();
                if(allTasks.Count > 0) tblNewComment.Visible = true;
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
            }
        }

        protected Boolean dateValidator(String date)
        {
            DateTime minDate = DateTime.Parse("1000/12/28");
            DateTime maxDate = DateTime.Parse("9999/12/28");
            DateTime dt;

            if (DateTime.TryParse(date, out dt) && dt <= maxDate && dt >= minDate)
            {
                return true;
            }
            else return false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProjectsOverview.aspx"); //ohne Speichern zur Projektübersicht
        }
    }
}