using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.MVVM.Models
{
    public class UserManager
    {
        public static ObservableCollection<User> UsersCollection = new ObservableCollection<User>
        {
            new User{ UserName="Akram",Login ="Akram@mail.ru",Password="Hello" },
            new User{UserName = "Jack", Login="Jack@mail.ru",Password="qwerty" }
        };

        public static void AddUser(User user)
        {
            UsersCollection.Add(user);
        }

        public static ObservableCollection<User> GetUsers()
        {
            return UsersCollection;
        }
    }
}
