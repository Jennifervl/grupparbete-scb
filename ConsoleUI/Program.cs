using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Program
    {
        static Menu menu = new();
        static UserRepository userRepository = new();
        static SurveyRepository surveyRepository = new();
        static User_Survey_Repository usr = new();

        static void Main(string[] args)
        {
            // Menu.MainMenu();
            userRepository.LoadUsers();
            surveyRepository.LoadSurveys();

            Console.Clear();
            Menu.WelcomeScreen();
            Console.ReadLine();
            Menu.MainMenu(userRepository, surveyRepository, usr); // <-- Med argument in för statiska listor

            // menu.MyMenu(userRepository, surveyRepository, usr);
            // Survey survey = Admin.BuildSurvey();
            // AnswerSurvey(survey);
        }
    }
}
