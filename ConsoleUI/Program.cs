using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {
            SaveDataManager saveDataManager = new();
            LoadDataManager loadDataManager = new();

            Menu menu = new();
            UserRepository userRepository = new();
            SurveyRepository surveyRepository = new();
            User_Survey_Repository usr = new();
            // Menu.MainMenu();
            userRepository.LoadUsers();
            surveyRepository.LoadSurveys();

            Console.Clear();
            Menu.WelcomeScreen();
            Menu.MainMenu(userRepository, surveyRepository, usr); // <-- Med argument in för statiska listor

            // menu.MyMenu(userRepository, surveyRepository, usr);
            // Survey survey = Admin.BuildSurvey();
            // AnswerSurvey(survey);
        }
    }
}
