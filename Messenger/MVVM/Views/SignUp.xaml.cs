using Messenger.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            foreach (User user in Users)
            {
                if (user.Login == LoginTextBox.Text && user.Password == PasswordTextBox.Password)
                {
                    this.Close();
                    MainWindow main = new MainWindow();
                    main.Show();
                }
                else
                {
                    ErrorTextBlock.Text = "Incorrect Data";
                }
            }
        }
    }
}
