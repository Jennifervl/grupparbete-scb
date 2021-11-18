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
            userRepository.LoadUsers();
            surveyRepository.LoadSurveys();

            menu.MyMenu(userRepository, surveyRepository, usr);
            // Survey survey = Admin.BuildSurvey();
            // AnswerSurvey(survey);
        }
    }
}
