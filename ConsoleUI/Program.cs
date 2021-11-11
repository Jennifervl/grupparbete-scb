using System;
using SurveyLib;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            User testAdminUser = new User("1990-01-01-4444", UserRoles.Admin);
            User testUserUser = new User("1980-02-02-5555", UserRoles.User);
            UserList userList = new UserList();
            userList.AddNewUser(testAdminUser);
            userList.AddNewUser(testUserUser);
            userList.ListUsers();
        }
    }
}
