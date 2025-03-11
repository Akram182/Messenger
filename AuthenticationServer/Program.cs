using AuthenticationServer.DataBase;

using static System.Console;

using (ApplicationContext db = new ApplicationContext())
{
    User Tom = new User { UserName = "Tom", Login = "Tom@mail.ru", Password = "Tom123" };

    db.Add(Tom);
    db.SaveChanges();   

    var Users = db.Users.ToList();   

    foreach(User user in Users)
    {
        WriteLine($"Id:{user.Id}\tUserName:{user.UserName}\tLogin:{user.Login}\tPassword:{user.Password}");
    }
}


