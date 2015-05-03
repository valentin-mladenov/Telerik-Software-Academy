namespace TaskFormApp
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using TaskFormApp.Comments;

    /// <summary>
    /// Partial class for Task form.
    /// </summary>
    public partial class TaskForm : Form
    {
        private readonly Dictionary<string, int> commTypes;

        private readonly Dictionary<string, int> commTasks;

        private readonly CommentForUpdate commentForUpdate;

        private const string Server = "Server=.\\HUDSONVSM;";

        private const string Database = "Database=TaskManagment;";

        private const string Security = "Integrated Security=true";

        /// <summary>
        /// Task form initializer.
        /// </summary>
        public TaskForm()
        {
            this.InitializeComponent();
            this.commTypes = new Dictionary<string, int>();
            this.commTasks = new Dictionary<string, int>();
            this.commentForUpdate = new CommentForUpdate();
        }

        /// <summary>
        /// Main load method.
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event arguments</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SelectTaskDescription();

            this.SelectCommentType();

            this.SearchView.Visible = false;
            this.UpdateDelete.Visible = false;
        }

        /// <summary>
        /// On click "AddComment" button event sends new comment to database.
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event arguments</param>
        private void AddComment_Click(object sender, EventArgs e)
        {
            var commType = this.CommentType.Text;
            var comment = this.Comment.Text;
            var commTask = this.CommentTask.Text;
            var commDueDate = DateTime.Parse(this.ReminderDate.Text);
            var postDate = DateTime.Now;

            var taskId = this.commTasks[commTask];
            var typeId = this.commTypes[commType];

            var addQuery = "INSERT INTO [Comments] ([DateAdded], [Comment]," + " [Type], [ReminderDate], [Task]) "
                           + "VALUES ('" + postDate.ToString("yyyy-MM-dd") + "','" + comment + "'," + typeId + ",'"
                           + commDueDate.ToString("yyyy-MM-dd") + "', " + taskId + ")";

            this.ExecuteNonQuery(addQuery);
        }

        /// <summary>
        /// On click "Search" button event sends SQL query
        /// to database, which returns a list of comments
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event arguments</param>
        private void Search_Click(object sender, EventArgs e)
        {
            var searchFrase = this.SearchText.Text;
            this.SearchView.Clear();

            var query = "SELECT c.[Comment], t.[Description] AS Task "
                        + "FROM [Comments] c JOIN Task t ON t.TaskID = c.Task " + "WHERE c.Comment LIKE '%"
                        + searchFrase + "%'";
            var comments = new List<string> { "Comment", "Task" };


            var result = this.TakeDataFromDB(query, comments);
            this.SearchView.BringToFront();
            if (result.Count == 0)
            {
                this.SearchView.Items.Add("No such Item");
            }
            else
            {
                for (int i = 0; i < result.Count; i += 2)
                {
                    this.SearchView.Items.Add(result[i + 1] + ": " + result[i]);
                }
            }

            this.SearchView.Visible = true;

        }

        /// <summary>
        /// On click event that selects specific comment and task.
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event arguments</param>
        private void SearchView_DoubleClick(object sender, EventArgs e)
        {
            var comment = this.SearchView.FocusedItem.Text;
            if (comment != "No such Item")
            {
                var task = comment.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();

                this.SelectedTask.Clear();
                this.Comments.Items.Clear();
                this.UpdateDelete.Visible = false;

                this.GetTaskInfo(task);

                this.GetUsersInfo(task);

                this.GetCommentsForThisTask(task);
            }

            this.SearchView.Visible = false;
        }

        /// <summary>
        ///  On click event that selects specific task and displays his comments.
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event arguments</param>
        private void Tasks_DoubleClick(object sender, EventArgs e)
        {
            var task = this.Tasks.FocusedItem.Text;
            this.SelectedTask.Clear();
            this.Comments.Items.Clear();
            this.UpdateDelete.Visible = false;

            this.GetTaskInfo(task);

            this.GetUsersInfo(task);

            this.GetCommentsForThisTask(task);
        }



        /// <summary>
        /// On click event that opens Update/Delete comment window.
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event arguments</param>
        private void Comments_DoubleClick(object sender, EventArgs e)
        {

            var comment = Regex.Split(this.Comments.FocusedItem.Text, " \r\n");

            foreach (var items in comment.Select(item => item.Split(':')))
            {
                switch (items[0])
                {
                    case "DateAdded":
                        this.commentForUpdate.DateAdded = DateTime.Parse(items[1].Trim());
                        break;
                    case "Comment":
                        this.CommentUpDel.Text = items[1].Trim();
                        this.commentForUpdate.Comment = items[1].Trim();
                        break;
                    case "ReminderDate":
                        this.DateTimeUpDel.Text = items[1].Trim();
                        this.commentForUpdate.ReminderDate = DateTime.Parse(items[1].Trim());
                        break;
                    case "Type":
                        this.TypeUpDel.SelectedItem = items[1].Trim();
                        this.commentForUpdate.Type = items[1].Trim();
                        break;
                    case "Task":
                        this.TaskUpDel.SelectedItem = items[1].Trim();
                        this.commentForUpdate.Task = items[1].Trim();
                        break;
                    case "ID":
                        this.commentForUpdate.Id = int.Parse(items[1].Trim());
                        break;
                }
            }
            this.UpdateDelete.Visible = true;
        }

        /// <summary>
        /// On click "Delete" button event that sends delete comment query to database.
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event arguments</param>
        private void Delete_Click(object sender, EventArgs e)
        {
            var comment = this.CommentUpDel.Text;
            var reminderDate = DateTime.Parse(this.DateTimeUpDel.Text);
            var task = this.commTasks[this.TaskUpDel.Text];
            var type = this.commTypes[this.TypeUpDel.Text];

            var deleteQuery = "DELETE FROM [dbo].[Comments] " + "WHERE Task = " + task + " AND [Type] = " + type
                              + " AND [DateAdded] = '" + this.commentForUpdate.DateAdded.ToString("yyyy-MM-dd") + "' "
                              + "AND [Comment] = '" + comment + "' AND [ReminderDate] = '"
                              + reminderDate.ToString("yyyy-MM-dd") + "';";

            this.ExecuteNonQuery(deleteQuery);

            this.UpdateDelete.Visible = false;
            this.SelectedTask.Clear();
            this.Comments.Items.Clear();
        }

        /// <summary>
        /// On click "Update" button event that sends update comment query to database.
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event arguments</param>
        private void Update_Click(object sender, EventArgs e)
        {
            var comment = this.CommentUpDel.Text;
            var reminderDate = DateTime.Parse(this.DateTimeUpDel.Text);
            var task = this.commTasks[this.TaskUpDel.Text];
            var type = this.commTypes[this.TypeUpDel.Text];

            var updateQuery = "UPDATE [dbo].[Comments] SET [DateAdded] = '"
                              + this.commentForUpdate.DateAdded.ToString("yyyy-MM-dd") + "', [Comment] =  '" + comment
                              + "', [Type] = " + type + ", [ReminderDate] = '" + reminderDate.ToString("yyyy-MM-dd")
                              + "', [Task] = " + task + " WHERE Task = " + this.commTasks[this.commentForUpdate.Task]
                              + " AND [Type] = " + this.commTypes[this.commentForUpdate.Type] + " AND [DateAdded] = '"
                              + this.commentForUpdate.DateAdded.ToString("yyyy-MM-dd") + "' AND [Comment] = '"
                              + this.commentForUpdate.Comment + "' AND [ReminderDate] = '"
                              + this.commentForUpdate.ReminderDate.ToString("yyyy-MM-dd") + "' AND " + "[CommentID] = "
                              + this.commentForUpdate.Id + ";";

            this.ExecuteNonQuery(updateQuery);

            this.UpdateDelete.Visible = false;
            this.SelectedTask.Clear();
            this.Comments.Items.Clear();

        }


        /// <summary>
        /// On click "Exit" button event that closes and clears the Update/Delete window.
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event arguments</param>
        private void Exit_Click(object sender, EventArgs e)
        {
            this.UpdateDelete.Visible = false;
            this.CommentUpDel.Text = "";
        }


        /// <summary>
        /// Method that takes comment type names from the database.
        /// </summary>
        private void SelectCommentType()
        {
            const string QueryCommTypes = "SELECT Name FROM CommentType";
            var commTypesName = new List<string> { "Name" };
            var commTypesArray = this.TakeDataFromDB(QueryCommTypes, commTypesName);

            int count = 1;
            foreach (var value in commTypesArray)
            {
                this.CommentType.Items.Add(value.Trim());
                this.TypeUpDel.Items.Add(value.Trim());
                this.commTypes.Add(value.Trim(), count);
                count++;
            }

            this.CommentType.SelectedItem = commTypesArray[0].Trim();
        }

        /// <summary>
        /// Method that takes task descriptions from the database.
        /// </summary>
        private void SelectTaskDescription()
        {
            const string QueryDesc = "SELECT [Description] FROM Task";
            var descripts = new List<string> { "Description" };

            var desArray = this.TakeDataFromDB(QueryDesc, descripts);

            int count = 1;
            foreach (var value in desArray)
            {
                this.Tasks.Items.Add(value);
                this.CommentTask.Items.Add(value.Trim());
                this.TaskUpDel.Items.Add(value.Trim());
                this.commTasks.Add(value.Trim(), count);
                count++;
            }

            this.CommentTask.SelectedItem = desArray[0].Trim();
        }

        /// <summary>
        /// Method that gets and displays comments assigned to selected task from the database.
        /// </summary>
        /// <param name="task">Task Name</param>
        private void GetCommentsForThisTask(string task)
        {
            var queryComments =
                "SELECT c.[DateAdded], c.[Comment], c.[ReminderDate], ct.Name AS [Type], t.[Description] AS Task, c.[CommentID] AS ID "
                + "FROM [TaskManagment].[dbo].[Comments] c "
                + "JOIN [TaskManagment].[dbo].[Task] t ON t.TaskID = c.Task "
                + "JOIN [TaskManagment].[dbo].[CommentType] ct ON ct.TypeID = c.[Type] " + "WHERE t.[Description] = '"
                + task + "'";

            var commentsArr = new List<string> { "DateAdded", "Comment", "ReminderDate", "Type", "Task", "ID" };

            var commArray = this.TakeDataFromDB(queryComments, commentsArr);

            var count = 0;
            var sb = new List<string>();
            for (int i = 0; i < commArray.Count / commentsArr.Count; i++)
            {
                foreach (string t in commentsArr)
                {
                    if (t == "ReminderDate" && count == 2)
                    {
                        this.SelectedTask.Items.Add("NextAction: " + commArray[count]);
                    }

                    sb.Add(t + @": " + commArray[count]);

                    count++;
                }

                var strArr = string.Join(" \r\n", sb);
                this.Comments.Items.Add(new ListViewItem(strArr).Text);
                sb.Clear();
            }
            // this.Comments.View = View.LargeIcon;
        }

        /// <summary>
        /// Method that gets and displays users assigned to selected task from the database.
        /// </summary>
        /// <param name="task">Task Name</param>
        private void GetUsersInfo(string task)
        {
            var queryUser = "SELECT u.UserName AS Users " + "FROM [TaskManagment].[dbo].[TaskUsers] tu "
                            + "JOIN [TaskManagment].[dbo].[Task] t ON t.TaskID = tu.TaskID "
                            + "JOIN [TaskManagment].[dbo].[Users] u ON u.UserID = tu.UserID "
                            + "WHERE t.[Description] = '" + task + "'";
            var userArr = new List<string> { "Users" };

            var userArray = this.TakeDataFromDB(queryUser, userArr);

            this.SelectedTask.Items.Add(userArr[0] + ": ");
            foreach (string t in userArray)
            {
                this.SelectedTask.Items.Add(t);
            }
        }

        /// <summary>
        /// Method that gets and displays complete info of the selected task from the database.
        /// </summary>
        /// <param name="task"></param>
        private void GetTaskInfo(string task)
        {
            var query = "SELECT t.[Description], s.Name AS [Status], ty.Name AS [Type] "
                        + "FROM [TaskManagment].[dbo].[Task] t JOIN [TaskManagment].[dbo].[TaskStatus] s "
                        + "ON t.[Status] = s.[StatusID] JOIN [TaskManagment].[dbo].[TaskType] ty "
                        + "ON t.[Type] = ty.[TypeID] WHERE t.[Description] = '" + task + "'";
            var items = new List<string> { "Description", "Status", "Type" };

            var strArray = this.TakeDataFromDB(query, items);

            for (int index = 0; index < items.Count; index++)
            {
                this.SelectedTask.Items.Add(items[index] + ": " + strArray[index]);
            }
        }

        /// <summary>
        /// Method that takes data from the database.
        /// </summary>
        /// <param name="sqlQuery">SQL query String</param>
        /// <param name="paramList">List of strings that is used to find needed data.</param>
        /// <returns>List of string based on the paramList.</returns>
        private List<string> TakeDataFromDB(string sqlQuery, List<string> paramList)
        {
            var strArray = new List<string>();
            var dbConnection = new SqlConnection(Server + " " + Database + " " + Security);

            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand dbCommand = new SqlCommand(sqlQuery, dbConnection);

                var reader = dbCommand.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        foreach (var item in paramList)
                        {

                            if (reader[item] is DateTime)
                            {
                                var res = Convert.ToString(reader[item]);

                                res = res.Substring(0, res.Length - 8);

                                strArray.Add(res);

                                continue;
                            }

                            var result = Convert.ToString(reader[item]);

                            strArray.Add(result);
                        }

                        //strArray.AddRange(paramList.Select(item => (string)reader[item]));
                    }
                }
            }
            dbConnection.Close();

            return strArray;
        }

        /// <summary>
        /// Method for non query SQL that is used to UPDATE or DELETE comments in the database.
        /// </summary>
        /// <param name="sqlQuery">SQL string</param>
        private void ExecuteNonQuery(string sqlQuery)
        {
            var dbConnection = new SqlConnection(Server + " " + Database + " " + Security);

            dbConnection.Open();
            using (dbConnection)
            {
                var dbCommand = new SqlCommand(sqlQuery, dbConnection);

                int rows = dbCommand.ExecuteNonQuery();

                MessageBox.Show(
                    rows == 0
                        ? string.Format("Fail! Rows affected: {0}.", rows)
                        : string.Format("Sucess! Rows affected: {0}.", rows));
            }
            dbConnection.Close();
        }
    }
}