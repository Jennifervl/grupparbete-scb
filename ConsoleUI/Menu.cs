using System;
using System.Collections.Generic;

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

                string choice = Console.ReadKey().Key.ToString().ToLower();
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
            bool adminRun = true;
            Menu men = new();
            while (adminRun == true)
            {
                Console.Clear();
                System.Console.WriteLine("Welcome to the super secret admin menu");
                System.Console.WriteLine("[A] Create a questionaire");
                System.Console.WriteLine("[X] Return to main menu");
                string adminChoice = Console.ReadKey().Key.ToString().ToLower();
                switch (adminChoice)
                {
                    case "a":
                        {
                            Admin.CreateSurvey();
                            System.Console.WriteLine("Returned from creating questionaire");
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