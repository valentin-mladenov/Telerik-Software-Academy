namespace TaskFormApp.Comments
{
    using System;

    /// <summary>
    /// Base comment to be updateed
    /// </summary>
    public class CommentForUpdate
    {
        /// <summary>
        /// Comment's date add.
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// The actual comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Due date for the task is assigned.
        /// </summary>
        public DateTime ReminderDate { get; set; }

        /// <summary>
        /// Type of the comment.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Comment's task.
        /// </summary>
        public string Task { get; set; }

        /// <summary>
        /// Comment id number in the database.
        /// </summary>
        public int Id { get; set; }
    }
}