using Messenger.MVVM.DataBase;
using Microsoft.EntityFrameworkCore;
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
        public static ObservableCollection<User>? UsersCollection { get; set; }

        public static void AddUser(User user)
        {

            using (UsersContext db = new UsersContext())
            {
                db.users.Add(user);
                db.SaveChanges();   
            }
        }

        public static ObservableCollection<User> GetUsers()
        {
            using (UsersContext db = new UsersContext())
            {
                var allUsers = db.users.ToList();

                foreach (User user in allUsers)
                {
                    UsersCollection?.Add(user);
                }
            }
            return UsersCollection;
        }
    }
}