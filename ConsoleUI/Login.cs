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
                            Menu.WriteCentered("Submit SSN: ");
                            Console.CursorLeft = (Console.WindowWidth / 2) - 5;
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
                                    Menu.WriteCentered("Enter password: ");
                                    Console.CursorLeft = (Console.WindowWidth / 2) - 5;
                                    passwordInput = Console.ReadLine();
                                    passAttempt++;
                                    if (passwordInput != password && passAttempt <= 2)
                                    {
                                        Menu.WriteCentered("Wrong password, try again");
                                    }
                                }
                                if (passAttempt >= 3)
                                {
                                    Menu.WriteCentered("Too many attempts, you're a big fat phony");
                                    Console.ReadLine();
                                    return;
                                }
                                // Menu.AdminMenu(userList, surveyLibrary);
                            }
                            break;
                        }
                    case false:
                        {
                            Menu.WriteCentered("Enter the questionaire code: ");
                                        Console.CursorLeft=(Console.WindowWidth/2);
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