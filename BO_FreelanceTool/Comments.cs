using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BO_FreelanceTool
{
    public class Comments
    {
        // FELDER bzw. VARIABLEN *********************************************************************************************
        private string _id;
        private string _text;
        private string _taskID;

        // PROPERTIES *********************************************************************************************
        public string id
        {
            get { return _id; }
            internal set { _id = value; }
        }
        public string text
        {
            get { return _text; }
            set { _text = value; }
        }
        public string taskID
        {
            get { return _taskID; }
            set { _taskID = value; }
        }
        /*
        public Boolean save()
        {

        }

        public Boolean delete()
        {

        }*/

        // Laden aller Comments als Liste von Objekten für einen Task - Funktion wird von Tasks aufgerufen!
        internal static List<Comments> LoadCommentsForTasks(Tasks theTask)
        {
            SqlCommand cmd = new SqlCommand("select id, text, taskID from Comments where taskID = @taskID", Main.GetConnection());
            cmd.Parameters.Add(new SqlParameter("taskID", theTask.id));
            SqlDataReader reader = cmd.ExecuteReader();
            List<Comments> allComments = new List<Comments>(); //initialisiere leere Liste von Tasks
            while (reader.Read())
            {
                Comments oneComment = new Comments();
                oneComment.id = reader.GetString(0);
                oneComment.text = reader.GetString(1);
                oneComment.taskID = reader.GetString(2);
                allComments.Add(oneComment);
            }
            return allComments;
        }
    }
}
