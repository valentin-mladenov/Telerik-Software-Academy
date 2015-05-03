namespace TaskFormApp
{
    partial class TaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tasks = new System.Windows.Forms.ListView();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.SelectedTask = new System.Windows.Forms.ListView();
            this.ReminderDate = new System.Windows.Forms.DateTimePicker();
            this.CommentType = new System.Windows.Forms.ComboBox();
            this.AddComment = new System.Windows.Forms.Button();
            this.Comment = new System.Windows.Forms.TextBox();
            this.CommentTask = new System.Windows.Forms.ComboBox();
            this.CommentLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SearchView = new System.Windows.Forms.ListView();
            this.Comments = new System.Windows.Forms.ListView();
            this.UpdateDelete = new System.Windows.Forms.GroupBox();
            this.Delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TaskUpDel = new System.Windows.Forms.ComboBox();
            this.CommentUpDel = new System.Windows.Forms.TextBox();
            this.Update = new System.Windows.Forms.Button();
            this.TypeUpDel = new System.Windows.Forms.ComboBox();
            this.DateTimeUpDel = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.UpdateDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tasks
            // 
            this.Tasks.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.Tasks.BackColor = System.Drawing.SystemColors.Control;
            this.Tasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Tasks.Location = new System.Drawing.Point(12, 63);
            this.Tasks.Name = "Tasks";
            this.Tasks.Size = new System.Drawing.Size(131, 99);
            this.Tasks.TabIndex = 0;
            this.Tasks.UseCompatibleStateImageBehavior = false;
            this.Tasks.View = System.Windows.Forms.View.List;
            this.Tasks.DoubleClick += new System.EventHandler(this.Tasks_DoubleClick);
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(347, 12);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(100, 20);
            this.SearchText.TabIndex = 2;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(470, 12);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(62, 20);
            this.Search.TabIndex = 3;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // SelectedTask
            // 
            this.SelectedTask.BackColor = System.Drawing.SystemColors.Control;
            this.SelectedTask.Location = new System.Drawing.Point(12, 180);
            this.SelectedTask.Name = "SelectedTask";
            this.SelectedTask.Size = new System.Drawing.Size(131, 120);
            this.SelectedTask.TabIndex = 4;
            this.SelectedTask.UseCompatibleStateImageBehavior = false;
            this.SelectedTask.View = System.Windows.Forms.View.List;
            // 
            // ReminderDate
            // 
            this.ReminderDate.Location = new System.Drawing.Point(486, 127);
            this.ReminderDate.Name = "ReminderDate";
            this.ReminderDate.Size = new System.Drawing.Size(133, 20);
            this.ReminderDate.TabIndex = 7;
            // 
            // CommentType
            // 
            this.CommentType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CommentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CommentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CommentType.FormattingEnabled = true;
            this.CommentType.IntegralHeight = false;
            this.CommentType.Location = new System.Drawing.Point(487, 153);
            this.CommentType.Name = "CommentType";
            this.CommentType.Size = new System.Drawing.Size(133, 21);
            this.CommentType.Sorted = true;
            this.CommentType.TabIndex = 8;
            // 
            // AddComment
            // 
            this.AddComment.Location = new System.Drawing.Point(487, 180);
            this.AddComment.Name = "AddComment";
            this.AddComment.Size = new System.Drawing.Size(132, 23);
            this.AddComment.TabIndex = 9;
            this.AddComment.Text = "Add Comment";
            this.AddComment.UseVisualStyleBackColor = true;
            this.AddComment.Click += new System.EventHandler(this.AddComment_Click);
            // 
            // Comment
            // 
            this.Comment.Location = new System.Drawing.Point(487, 101);
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(132, 20);
            this.Comment.TabIndex = 10;
            // 
            // CommentTask
            // 
            this.CommentTask.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CommentTask.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CommentTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CommentTask.FormattingEnabled = true;
            this.CommentTask.Location = new System.Drawing.Point(486, 74);
            this.CommentTask.Name = "CommentTask";
            this.CommentTask.Size = new System.Drawing.Size(133, 21);
            this.CommentTask.TabIndex = 11;
            // 
            // CommentLabel
            // 
            this.CommentLabel.AutoSize = true;
            this.CommentLabel.Location = new System.Drawing.Point(449, 82);
            this.CommentLabel.Name = "CommentLabel";
            this.CommentLabel.Size = new System.Drawing.Size(31, 13);
            this.CommentLabel.TabIndex = 12;
            this.CommentLabel.Text = "Task";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Comment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Due Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(449, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Type";
            // 
            // SearchView
            // 
            this.SearchView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.SearchView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.SearchView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchView.Location = new System.Drawing.Point(10, 38);
            this.SearchView.Name = "SearchView";
            this.SearchView.Size = new System.Drawing.Size(609, 262);
            this.SearchView.TabIndex = 17;
            this.SearchView.UseCompatibleStateImageBehavior = false;
            this.SearchView.View = System.Windows.Forms.View.List;
            this.SearchView.DoubleClick += new System.EventHandler(this.SearchView_DoubleClick);
            // 
            // Comments
            // 
            this.Comments.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.Comments.BackColor = System.Drawing.SystemColors.Control;
            this.Comments.Location = new System.Drawing.Point(149, 62);
            this.Comments.Name = "Comments";
            this.Comments.Size = new System.Drawing.Size(272, 237);
            this.Comments.TabIndex = 18;
            this.Comments.TileSize = new System.Drawing.Size(150, 50);
            this.Comments.UseCompatibleStateImageBehavior = false;
            this.Comments.View = System.Windows.Forms.View.Tile;
            this.Comments.DoubleClick += new System.EventHandler(this.Comments_DoubleClick);
            // 
            // UpdateDelete
            // 
            this.UpdateDelete.Controls.Add(this.Exit);
            this.UpdateDelete.Controls.Add(this.Delete);
            this.UpdateDelete.Controls.Add(this.label1);
            this.UpdateDelete.Controls.Add(this.label5);
            this.UpdateDelete.Controls.Add(this.label6);
            this.UpdateDelete.Controls.Add(this.label7);
            this.UpdateDelete.Controls.Add(this.TaskUpDel);
            this.UpdateDelete.Controls.Add(this.CommentUpDel);
            this.UpdateDelete.Controls.Add(this.Update);
            this.UpdateDelete.Controls.Add(this.TypeUpDel);
            this.UpdateDelete.Controls.Add(this.DateTimeUpDel);
            this.UpdateDelete.Location = new System.Drawing.Point(266, 38);
            this.UpdateDelete.Name = "UpdateDelete";
            this.UpdateDelete.Size = new System.Drawing.Size(354, 261);
            this.UpdateDelete.TabIndex = 19;
            this.UpdateDelete.TabStop = false;
            this.UpdateDelete.Text = "UpdateDelete";
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(47, 195);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(104, 23);
            this.Delete.TabIndex = 35;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(96, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Due Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Comment";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(96, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Task";
            // 
            // TaskUpDel
            // 
            this.TaskUpDel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TaskUpDel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TaskUpDel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TaskUpDel.FormattingEnabled = true;
            this.TaskUpDel.Location = new System.Drawing.Point(133, 44);
            this.TaskUpDel.Name = "TaskUpDel";
            this.TaskUpDel.Size = new System.Drawing.Size(133, 21);
            this.TaskUpDel.TabIndex = 30;
            // 
            // CommentUpDel
            // 
            this.CommentUpDel.Location = new System.Drawing.Point(134, 71);
            this.CommentUpDel.Name = "CommentUpDel";
            this.CommentUpDel.Size = new System.Drawing.Size(132, 20);
            this.CommentUpDel.TabIndex = 29;
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(205, 195);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(102, 23);
            this.Update.TabIndex = 28;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // TypeUpDel
            // 
            this.TypeUpDel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TypeUpDel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TypeUpDel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeUpDel.FormattingEnabled = true;
            this.TypeUpDel.IntegralHeight = false;
            this.TypeUpDel.Location = new System.Drawing.Point(134, 123);
            this.TypeUpDel.Name = "TypeUpDel";
            this.TypeUpDel.Size = new System.Drawing.Size(133, 21);
            this.TypeUpDel.Sorted = true;
            this.TypeUpDel.TabIndex = 27;
            // 
            // DateTimeUpDel
            // 
            this.DateTimeUpDel.Location = new System.Drawing.Point(133, 97);
            this.DateTimeUpDel.Name = "DateTimeUpDel";
            this.DateTimeUpDel.Size = new System.Drawing.Size(133, 20);
            this.DateTimeUpDel.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(157, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Comments";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Tasks";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Selected Task";
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(304, 19);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(34, 23);
            this.Exit.TabIndex = 36;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 311);
            this.Controls.Add(this.UpdateDelete);
            this.Controls.Add(this.SearchView);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Comments);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CommentLabel);
            this.Controls.Add(this.CommentTask);
            this.Controls.Add(this.Comment);
            this.Controls.Add(this.AddComment);
            this.Controls.Add(this.CommentType);
            this.Controls.Add(this.ReminderDate);
            this.Controls.Add(this.SelectedTask);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.Tasks);
            this.Name = "TaskForm";
            this.Text = "Tasks And Comments";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.UpdateDelete.ResumeLayout(false);
            this.UpdateDelete.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView Tasks;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.ListView SelectedTask;
        private System.Windows.Forms.DateTimePicker ReminderDate;
        private System.Windows.Forms.ComboBox CommentType;
        private System.Windows.Forms.Button AddComment;
        private System.Windows.Forms.TextBox Comment;
        private System.Windows.Forms.ComboBox CommentTask;
        private System.Windows.Forms.Label CommentLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView SearchView;
        private System.Windows.Forms.ListView Comments;
        private System.Windows.Forms.GroupBox UpdateDelete;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox TaskUpDel;
        private System.Windows.Forms.TextBox CommentUpDel;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.ComboBox TypeUpDel;
        private System.Windows.Forms.DateTimePicker DateTimeUpDel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Exit;
    }
}

