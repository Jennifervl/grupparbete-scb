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
                    login.LoginRun(isAdmin = true);
                }

                else if (choice == "b")
                {
                    login.LoginRun(isAdmin = false);
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
    }
}