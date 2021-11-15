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
                            foreach (User u in userList.GetUsers())
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
                                string password = "admin";
                                while (passwordInput != password && passwordInput.Length < 5 && passAttempt <= 2)
                                {
                                    System.Console.WriteLine("Enter password (5 characters): ");
                                    passwordInput = Console.ReadLine();
                                    passAttempt++;
                                    if (passwordInput != password && passAttempt <=2) 
                                    {
                                        System.Console.WriteLine("Wrong password, try again");
                                    }
                                }
                                if (passAttempt >= 3)
                                {
                                    System.Console.WriteLine("Too many attempts, you're a big fat phony");
                                    Console.ReadLine();
                                    return;
                                }
                                Menu.AdminMenu();
                            }
                            break;
                        }
                    case false:
                        {
                            // System.Console.WriteLine("Enter the questionaire code: ");
                            ServeyTest.surveyTest();
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


            //  void RollLoginRun2()

            // {
            //     User testAdminUser = new User("199001014444", UserRoles.Admin);
            //     User testParticipant = new User("198002025555", UserRoles.Participant);
            //     UserList userList = new UserList();
            //     userList.AddNewUser(testAdminUser);
            //     userList.AddNewUser(testUserUser);
            //     List<User> testList = new();
            //     userList.GetUsers(testList);

            //     Console.Clear();
            //     while(true)
            //     {
            //       string choice = Console.ReadKey().Key.ToString().ToLower();
            //       System.Console.WriteLine("Submit SSN: ");
            //       string input = Console.ReadLine();
            //        if (input.Length == 12)
            //         {

            //             Console.WriteLine("Successfully logged in.");
            //             userList.ListUsers();
            //             Console.ReadLine();
            //         }
            //         else
            //         {
            //             Console.WriteLine($"Incorrect length of personal number, you entered {input.Length} digits, try again please.");
            //             Console.ReadLine();
            //         }

            //     }




            // }

        }
    }

}