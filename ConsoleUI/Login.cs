using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Login
    {
        public void LoginRun(bool isAdmin, UserRepository userRepository)
        {
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
                            foreach (User u in userRepository.GetUsers())
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
                                    if (passwordInput != password && passAttempt <= 2)
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
                                // Menu.AdminMenu(userList, surveyLibrary);
                            }
                            break;
                        }
                    case false:
                        {
                            System.Console.WriteLine("Enter the questionaire code: ");
                            string code = Console.ReadLine();

                            foreach (User user in userRepository.GetUsers())
                            {
                                // foreach (User_Survey US in user.GetUserSurveys())
                                // {
                                //     if (US.FindMatch(code) != null)
                                //     {

                                //     }
                                // }
                            }
                            break;
                        }
                }

                return;
            }



        }
    }

}