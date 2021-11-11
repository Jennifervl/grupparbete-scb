using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Login
    {
        public void LoginRun(bool isAdmin)
        {
            User testAdminUser = new User("199001014444", UserRoles.Admin);
            User testUserUser = new User("198002025555", UserRoles.Participant);
            UserList userList = new UserList();
            userList.AddNewUser(testAdminUser);
            userList.AddNewUser(testUserUser);
            List<User> testList = new();
            userList.GetUsers(testList);
            bool confirmedAdmin = false;
            while (true)
            {
                // userList.ListUsers();            
                Console.Clear();
                switch (isAdmin)
                {
                    case true:
                        {
                            System.Console.WriteLine("Submit SSN: ");
                            string ssnInput = Console.ReadLine();
                            foreach (User u in testList)
                            {
                                if (ssnInput == u.Ssn)
                                {
                                    confirmedAdmin = true;
                                }
                            }
                            if (confirmedAdmin == true)
                            {
                                int passAttempt = 0;
                                string passwordInput = "";
                                while (passwordInput != "hej" && passAttempt <= 2)
                                {
                                    System.Console.WriteLine("Enter password: ");
                                    passwordInput = Console.ReadLine();
                                    System.Console.WriteLine("Wrong password, try again");
                                    passAttempt++;
                                }
                                if (passAttempt >= 3)
                                {
                                    System.Console.WriteLine("Too many attempts, now you die");
                                    Console.ReadLine();
                                    return;
                                }
                                System.Console.WriteLine("You pass the test");

                            }
                            break;
                        }
                    case false:
                        {
                            // System.Console.WriteLine("Enter the questionaire code: ");
                            Program.surveyTest();
                            break;
                        }
                }
                // string input = Console.ReadLine();
                // if (input.Length == 12)
                // {
                //     // Console.WriteLine("Successfully logged in.");
                //     // userList.ListUsers();
                //     Console.ReadLine();
                // }
                // else
                // {
                //     Console.WriteLine($"Incorrect length of personal number, you entered {input.Length} digits, try again please.");
                //     Console.ReadLine();
                // }
                return;
            }
        }
    }

}