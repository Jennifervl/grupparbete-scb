using System;
using SurveyLib;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            User testAdminUser = new User("199001014444", UserRoles.Admin);
            User testUserUser = new User("198002025555", UserRoles.User);
            UserList userList = new UserList();
        }
    }
}
