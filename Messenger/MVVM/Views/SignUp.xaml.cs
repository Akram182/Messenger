using Messenger.MVVM.DataBase;
using Messenger.MVVM.Models;
using Messenger.Network;
using System.Collections.ObjectModel;
using System.Windows;

namespace Messenger.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        ObservableCollection<User> Users = UserManager.GetUsers();
        public SignUp()
        {
            InitializeComponent();
        }
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {

            
            using (UsersContext db = new UsersContext())
            {
                Client ServerClient = new Client(new User {Login = LoginTextBox.Text, Password = PasswordTextBox.Password });
                var AuthUser = db.users.Where(u => u.Password == PasswordTextBox.Password.ToString() && u.Login == LoginTextBox.Text).FirstOrDefault();

                if (AuthUser != null)
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                else
                {
                    ErrorTextBlock.Text = "Incorrect Data";
                }
            }
        }
    }
}