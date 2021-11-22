using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Menu
    {
        public static void MainMenu(UserRepository userRepository, SurveyRepository surveyRepository, User_Survey_Repository usr)
        {
            while (true)
            {
                Console.Clear();
                DrawMenu();
                var choice = Console.ReadKey(true).Key;
                switch (choice)
                {
                    case ConsoleKey.D1:
                        {
                            Console.Clear();
                            UserMenu.Questionaire(userRepository, surveyRepository, usr);
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Console.Clear();
                            AdminMenu(userRepository, surveyRepository, usr);

                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            WriteCentered("Shutting down");
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }
        private static void DrawMenu()
        {
            List<string> menuRows = new();
            menuRows.Add("╔═════════════════════╗");
            menuRows.Add("║     SCB Surveys     ║");
            menuRows.Add("╠═════════════════════╣");
            menuRows.Add("║  1 - Take survey    ║");
            menuRows.Add("║  2 - Admin login    ║");
            menuRows.Add("║                     ║");
            menuRows.Add("║  ESC - Quit         ║");
            menuRows.Add("╚═════════════════════╝");
            foreach (string row in menuRows)
            {
                WriteCentered(row);
            }
        }
        public static void AdminMenu(UserRepository userRepository, SurveyRepository surveyRepository, User_Survey_Repository usr)
        {
            // TODO:Enabla när vi slutar testa!!!!!!!!!!
            // if (AdminCommands.ConfirmAdmin(userRepository))  
            // {
            bool adminMenuLoop = true;
            while (adminMenuLoop == true)
            {
                Console.Clear();
                DrawAdminMenu();
                var choice = Console.ReadKey(true).Key;
                switch (choice)
                {
                    case ConsoleKey.D1:
                        {
                            Console.Clear();
                            // Create Survey
                            Survey newSurvey = AdminCommands.BuildSurvey(surveyRepository);
                            surveyRepository.AddSurvey(newSurvey);
                            surveyRepository.SaveSurvey(newSurvey);
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Console.Clear();
                            // List all surveys
                            AdminCommands.ListAllSurveys(surveyRepository);
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            Console.Clear();
                            // Distribute Survey
                            AdminCommands.DistributeSurvey(userRepository, surveyRepository, usr);
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            Console.Clear();
                            // List distributions
                            AdminCommands.ListDistributions(usr);
                            break;
                        }
                    case ConsoleKey.D5:
                        {
                            Console.Clear();
                            // List users
                            AdminCommands.ListAllUsers(userRepository);
                            break;
                        }
                    case ConsoleKey.D6:
                        {
                            Console.Clear();
                            // Add user
                            AdminCommands.AddUser(userRepository);
                            break;
                        }
                    case ConsoleKey.D7:
                        {
                            Console.Clear();
                            // Skriv ut lista av alla surveys, välj en survey att visa statistik på
                            AdminCommands.ShowSurveyStatistics(surveyRepository);

                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            adminMenuLoop = false;
                            break;
                        }
                }
                if (adminMenuLoop == true)
                {
                    ReturnToAdminMenu();
                }
                // }
            }
        }
        private static void DrawAdminMenu()
        {
            List<string> menuRows = new();
            menuRows.Add("╔══════════════════════════════╗");
            menuRows.Add("║        Admin commands        ║");
            menuRows.Add("╠══════════════════════════════╣");
            menuRows.Add("║  1 - Create a survey         ║");
            menuRows.Add("║  2 - List all surveys        ║");
            menuRows.Add("║  3 - Distribute survey       ║");
            menuRows.Add("║  4 - List distributions      ║");
            menuRows.Add("╠══════════════════════════════╣");
            menuRows.Add("║  5 - List all users          ║");
            menuRows.Add("║  6 - Add a new user          ║");
            menuRows.Add("╠══════════════════════════════╣");
            menuRows.Add("║  7 - View survey statistics  ║");
            menuRows.Add("╠══════════════════════════════╣");
            menuRows.Add("║  ESC - Return to main menu   ║");
            menuRows.Add("╚══════════════════════════════╝");
            foreach (string row in menuRows)
            {
                WriteCentered(row);
            }
        }
        public static void WelcomeScreen()
        {
            WriteCentered("███████╗ ██████╗██████╗ ");
            WriteCentered("██╔════╝██╔════╝██╔══██╗");
            WriteCentered("███████╗██║     ██████╔╝");
            WriteCentered("╚════██║██║     ██╔══██╗");
            WriteCentered("███████║╚██████╗██████╔╝");
            WriteCentered("╚══════╝ ╚═════╝╚═════╝ ");
            WriteCentered("The Swedish Statistical CentralBureau\n\n");
            Console.ResetColor();
            Console.ReadLine();
        }
        public static void ReturnToAdminMenu()
        {
            Console.WriteLine("\nPress ENTER to return to admin menu...");
            Console.ReadLine();
        }
        public static void WriteCentered(string s)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (s.Length / 2)) + "}", s));
        }
    }
}