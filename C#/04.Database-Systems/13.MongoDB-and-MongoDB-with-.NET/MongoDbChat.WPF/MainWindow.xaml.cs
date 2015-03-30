namespace MongoDbChat.WPF
{
    using System.Windows;

    using MongoDbChat.Data;
    using MongoDbChat.Model;


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(User user)
        {
            this.InitializeComponent();
            this.User = user;
        }

        private User User { get; set; }

        private void LogInClick(object sender, RoutedEventArgs e)
        {
            var username = this.LogNameTextBox.Text;
            if (!MongoDbChatValidation.IsValidUsername(username))
            {
                return;
            }

            this.Hide();
            this.OpenMongoDbChatWindow(username);
            this.Close();
        }

        private void OpenMongoDbChatWindow(string username)
        {
            var user = new User(username);
            var mainWindow = new MongoDbChatWindow(user);
            mainWindow.Show();
        }
    }
}