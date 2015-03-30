namespace MongoDbChat.WPF
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;

    using MongoDbChat.Data;
    using MongoDbChat.Model;

    public partial class MongoDbChatWindow : Window
    {
        private Thread updatePostsThread; // XXX: bad
        MongoDbChatModule crowdChatModule;

        public MongoDbChatWindow(User user)
        {
            this.InitializeComponent();
            this.User = user;
        }

        private User User { get; set; }

        private bool IsInShowAllPostsMode { get; set; }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.updatePostsThread.Abort();
            App.Current.Shutdown();
        }

        private void OnWindowFormLoaded(object sender, RoutedEventArgs e)
        {
            this.InitializeMongoChatModule();
            this.ShowAllPostsAsync(this.GetDateTimeRange());
            this.sendMessage.Focus();
            this.UpdatePostsEachMsAsync();
        }

        private void InitializeMongoChatModule()
        {
            var mongoDbContext = new MongoDbContext();
            this.crowdChatModule = new MongoDbChatModule(mongoDbContext);
        }

        private async void ShowAllPostsAsync(Tuple<DateTime, DateTime> dateTimeRanges)
        {
            var postsAsString = await this.GetPostsAsString(dateTimeRanges);
            this.allMassages.Text = postsAsString.ToString();
            this.allMassages.ScrollToEnd();
        }

        private Task<string> GetPostsAsString(Tuple<DateTime, DateTime> dateTimeRange)
        {
            return Task.Run(() =>
            {
                return this.crowdChatModule.GenerateAllPostsAsString(dateTimeRange.Item1, dateTimeRange.Item2).ToString();
            });
        }

        private async void UpdatePostsEachMsAsync(int refreshMs = 500)
        {
            this.updatePostsThread = new Thread(async () =>
            {
                while (true)
                {
                    this.allMassages.Dispatcher.BeginInvoke((Action)(async () => this.UpdatePosts()));
                    Thread.Sleep(refreshMs);
                }
            });
            this.updatePostsThread.Start();
        }

        private async void UpdatePosts()
        {
            var haveNewPosts = await this.crowdChatModule.HaveNewPosts();
            if (!haveNewPosts)
            {
                return;
            }

            var newPostsAsString = await this.GetPostsAsString(this.GetDateTimeRange());
            this.allMassages.Text = newPostsAsString;
            this.allMassages.ScrollToEnd();
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            var postContent = this.sendTextBox.Text;
            if (string.IsNullOrEmpty(postContent))
            {
                return;
            }

            var postModel = new Message()
            {
                Text = postContent,
                PostTime = DateTime.Now,
                User = this.User
            };
            this.sendTextBox.Text = string.Empty;
            this.crowdChatModule.AddPost(postModel);
            this.allMassages.Text += (this.allMassages.Text.Length > 0 ? Environment.NewLine : string.Empty) +
            this.crowdChatModule.GenerateOnePostAsString(postModel);
            this.allMassages.ScrollToEnd();
        }

        private void OnShowAllPostsButtonClick(object sender, RoutedEventArgs e)
        {
            this.IsInShowAllPostsMode = true;
            this.ShowAllPostsAsync(this.GetDateTimeRange());
        }

        private void OnShowAllPostsFromCurrentSessionButtonClick(object sender, RoutedEventArgs e)
        {
            this.IsInShowAllPostsMode = false;
            this.ShowAllPostsAsync(this.GetDateTimeRange());
        }

        private Tuple<DateTime, DateTime> GetDateTimeRange()
        {
            if (this.IsInShowAllPostsMode)
            {
                return Tuple.Create(DateTime.MinValue, DateTime.MaxValue);
            }
            else
            {
                return Tuple.Create(this.User.LoginTime, DateTime.MaxValue);
            }
        }

        private void AllMassages_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }
    }
}
