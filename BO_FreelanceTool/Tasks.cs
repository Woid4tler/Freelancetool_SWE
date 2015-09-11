using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BO_FreelanceTool
{
    public class Tasks
    {
        // FELDER bzw. VARIABLEN *********************************************************************************************
        
        private string _id;
        private string _name;
        private string _projectID;
        private List<Comments> comments;

        // PROPERTIES *********************************************************************************************
        public string id
        {
            get { return _id; }
            internal set { _id = value; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string projectID
        {
            get { return _projectID; }
            internal set { _projectID = value; }
        }

        public List<Comments> getComments
        {
            get
            {
                comments = Comments.LoadCommentsForTasks(this);;
                return comments;
            }

        }
        /*

        public Boolean save()
        {

        }

        public Boolean delete()
        {

        }*/

        // Laden aller Tasks als Liste von Objekten für ein Projekct - Funktion wird von Projects aufgerufen!
        internal static List<Tasks> LoadTasksForProject(Projects theProject)
        {
            SqlCommand cmd = new SqlCommand("select id, name, projectID from Tasks where projectID = @projectID", Main.GetConnection());
            cmd.Parameters.Add(new SqlParameter("projectID", theProject.id));
            SqlDataReader reader = cmd.ExecuteReader();
            List<Tasks> allTasks = new List<Tasks>(); //initialisiere lehre Liste von Tasks
            while (reader.Read())
            {
                Tasks oneTask = new Tasks();
                oneTask.id = reader.GetString(0);
                oneTask.name = reader.GetString(1);
                oneTask.projectID = reader.GetString(2);
                oneTask.comments = oneTask.getComments;
                allTasks.Add(oneTask);
            }
            return allTasks;
        }
    }
}
