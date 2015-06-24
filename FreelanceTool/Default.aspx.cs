using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_FreelanceTool;
using System.Data.SqlClient;

namespace FreelanceTool
{
    public partial class Default : System.Web.UI.Page
    {
        private List<Projects> allProjects;

        protected void Page_Load(object sender, EventArgs e)
        {
            //GVKunden.DataSource wird auf eine Liste von BO-Objekte gesetzt
            if (!IsPostBack) {
                allProjects = Main.getProjects(); //hier stecken alle Projekte als einzelne Objekte drin!
                Session["allProjects"] = allProjects; // die heb ich mir in der Session auf
                GVProjects.DataSource = allProjects;
                try { GVProjects.DataBind(); }
                catch (SqlException error)
                {
                    Console.Write(error.Message);
                }
            }
            else {
                allProjects = (List<Projects>)Session["allProjects"];
            }
        }
    }
}