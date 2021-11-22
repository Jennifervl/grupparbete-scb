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
            Console.WriteLine("Users Loaded");
            surveyRepository.LoadSurveys();
            Console.WriteLine("Surveys Loaded");
            usr.LoadAllUser_Surveys();
            Console.WriteLine("User_Surveys Loaded");

            Console.Clear();
            Menu.WelcomeScreen();
            Menu.MainMenu(userRepository, surveyRepository, usr); // <-- Med argument in för statiska listor

        }
    }
}
