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
        private string _dateString;

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
        public string dateString
        {
            get { return _dateString; }
            set { _dateString = value; }
        }

        public void addToTask(string task_id)
        {
            _taskID = task_id;
        }

        public Boolean save()
        {
            string SQL = "insert into Comments (id, taskID, text, date) values (@id, @task_id, @comment, CURRENT_TIMESTAMP)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            _id = Guid.NewGuid().ToString();
            cmd.Parameters.Add(new SqlParameter("id", _id));
            cmd.Parameters.Add(new SqlParameter("task_id", _taskID));
            cmd.Parameters.Add(new SqlParameter("comment", _text));
            return (cmd.ExecuteNonQuery() > 0);
        }

       public Boolean delete()
       {
           if (_id != "")
           {
               SqlCommand cmd = new SqlCommand("delete Comments where id = @id", Main.GetConnection());
               cmd.Parameters.Add(new SqlParameter("id", _id));
               if (cmd.ExecuteNonQuery() > 0)
               {
                   _id = "";
                   return true;
               }
               else return false; //Löschen aus DB klappt nicht
           }
           else return true;
       }

        // Laden aller Comments als Liste von Objekten für einen Task - Funktion wird von Tasks aufgerufen!
        internal static List<Comments> LoadCommentsForTasks(Tasks theTask)
        {
            SqlCommand cmd = new SqlCommand("select id, text, taskID, date from Comments where taskID = @taskID", Main.GetConnection());
            cmd.Parameters.Add(new SqlParameter("taskID", theTask.id));
            SqlDataReader reader = cmd.ExecuteReader();
            List<Comments> allComments = new List<Comments>(); //initialisiere leere Liste von Tasks
            while (reader.Read())
            {
                Comments oneComment = new Comments();
                oneComment.id = reader.GetString(0);
                oneComment.text = reader.GetString(1);
                oneComment.taskID = reader.GetString(2);
                oneComment.dateString = reader.GetDateTime(3).ToString("dd.MM.yyyy - HH:mm")+" Uhr";
                allComments.Add(oneComment);
            }
            return allComments;
        }
    }
}
