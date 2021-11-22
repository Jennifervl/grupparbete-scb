using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {
            Menu menu = new();
            UserRepository userRepository = new();
            SurveyRepository surveyRepository = new();
            User_Survey_Repository usr = new();

            userRepository.LoadUsers();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Users Loaded");
            Console.ResetColor();
            surveyRepository.LoadSurveys();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Surveys Loaded");
            Console.ResetColor();
            usr.LoadAllUser_Surveys();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("User_Surveys Loaded");
            Console.ResetColor();


            Console.Clear();
            Menu.WelcomeScreen();
            Menu.MainMenu(userRepository, surveyRepository, usr); // <-- Med argument in för statiska listor

        }
    }
}
