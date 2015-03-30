namespace _11.Users_And_Groups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static Group FindAdminGroup(UsersAndAdminsEntities userDb)
        {
            List<Group> adminGroup = userDb.Groups.Where(g => g.GroupName == "Admins").ToList();
            return adminGroup[0];
        }

        public static void AddUserInAdmins(UsersAndAdminsEntities userDb, User user)
        {
            using (var transaction = userDb.Database.BeginTransaction())
            {
                try
                {
                    bool userInDb = userDb.Users.Select(g => g.UserName == user.UserName).First();
                    Console.WriteLine(userInDb);
                    if (userInDb)
                    {
                        throw new ArgumentException("User allready exists.");
                    }

                    bool adminGroupExists = userDb.Groups.Select(g => g.GroupName == "Admins").First();

                    if (adminGroupExists)
                    {
                        var admin = FindAdminGroup(userDb);
                        Console.WriteLine(admin);
                        user.GroupID = admin.GroupID;
                        userDb.Users.Add(user);
                    }
                    else
                    {
                        var group = new Group { GroupName = "Admins" };

                        userDb.Groups.Add(group);
                        userDb.SaveChanges();
                        var admin = FindAdminGroup(userDb);

                        Console.WriteLine(admin);
                        user.GroupID = admin.GroupID;
                        userDb.Users.Add(user);
                    }
                    
                    userDb.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        static void Main()
        {
            using (var userDb = new UsersAndAdminsEntities())
            {
                var user = new User { UserName = "Glavcho" };

                AddUserInAdmins(userDb, user);
            }
        }
    }
}
