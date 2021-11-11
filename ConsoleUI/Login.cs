using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Login
    {
        public void LoginRun()
        {

             while (true)
            {

            // User testAdminUser = new User("199001014444", UserRoles.Admin);
            // User testUserUser = new User("198002025555", UserRoles.User);
            // UserList userList = new UserList();
            // userList.AddNewUser(testAdminUser);
            // userList.AddNewUser(testUserUser);
            // userList.ListUsers();
                Console.Clear();
                Console.WriteLine("Enter personnumber to login: ");
                string input = Console.ReadLine();

                if (input.Length == 12)
                {
                    Menu newMenu = new();
                    newMenu.MyMenu();
                }
                else
                {
                    Console.WriteLine("Incorrect personnumber, try again please.");
                    Console.ReadLine();
                }
            }    
        }
    }
   
}