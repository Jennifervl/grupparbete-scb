using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Menu
    {
        public void MyMenu()
        {
            List<string> mymenu = new();
            bool isAdmin;
            mymenu.Add(@"
 ██████╗ ██╗   ██╗███████╗███████╗████████╗██╗ ██████╗ ███╗   ██╗███████╗
██╔═══██╗██║   ██║██╔════╝██╔════╝╚══██╔══╝██║██╔═══██╗████╗  ██║██╔════╝
██║   ██║██║   ██║█████╗  ███████╗   ██║   ██║██║   ██║██╔██╗ ██║███████╗
██║▄▄ ██║██║   ██║██╔══╝  ╚════██║   ██║   ██║██║   ██║██║╚██╗██║╚════██║
╚██████╔╝╚██████╔╝███████╗███████║   ██║   ██║╚██████╔╝██║ ╚████║███████║
 ╚══▀▀═╝  ╚═════╝ ╚══════╝╚══════╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════                                                                                                   
");
            mymenu.Add("[A] Admin");
            mymenu.Add("[B] User");
            mymenu.Add("[X] Log out");

            while (true)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                for (int i = 0; i < mymenu.Count; i++)
                {
                    Console.WriteLine(mymenu[i]);
                }

                string choice = Console.ReadKey(true).Key.ToString().ToLower();
                Login login = new();

                if (choice == "a")
                {
                    isAdmin = true;
                    login.LoginRun(isAdmin);
                }

                else if (choice == "b")
                {
                    isAdmin = false;
                    login.LoginRun(isAdmin);
                }
                else if (choice == "x")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\nMake a new menu choice please.\nPress any key to continue.");
                    Console.ReadLine();
                }
                Console.ResetColor();
            }

        }
        public static void AdminMenu()
        {
            SurveyLibrary surveyLibrary = new();
            bool adminRun = true;
            Menu men = new();
            while (adminRun == true)
            {
                Console.Clear();
                System.Console.WriteLine("Welcome to the super secret admin menu");
                System.Console.WriteLine("[A] Create a survey");
                System.Console.WriteLine("[L] List all surveys");
                System.Console.WriteLine("[X] Return to main menu");
                string adminChoice = Console.ReadKey(true).Key.ToString().ToLower();
                switch (adminChoice)
                {
                    case "a":
                        {
                            surveyLibrary.AddSurvey(Admin.BuildSurvey());
                            break;
                        }
                    case "l":
                        {
                            Admin.AdminListAllSurveys(surveyLibrary);
                            Console.ReadLine();
                            break;
                        }

                    case "x":
                        {
                            adminRun = false;
                            break;
                        }
                }

            }
            men.MyMenu();
        }
    }
}